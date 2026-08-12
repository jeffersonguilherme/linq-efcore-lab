

using LinqEfCoreLab.Entities;
using LinqEfCoreLab.Enums;
using Microsoft.EntityFrameworkCore;

namespace LinqEfCoreLab.Data.Seed;

/// <summary>
/// Popula o banco SQLite com dados de teste:
/// 30 produtos, 6 clientes e 10 pedidos (relacionados a clientes e produtos).
/// Chame DbSeeder.SeedAsync(context) uma vez na inicialização (ex: Program.cs em ambiente Development).
/// </summary>
public static class DbSeeder
{
    public static async Task SeedAsync(DbContext context)
    {
        // Evita duplicar dados se o seed já rodou antes
        if (await context.Set<Product>().AnyAsync())
            return;

        // ---------- 30 Produtos ----------
        var categorias = new[] { "Eletrônico", "Livro", "Roupa", "Casa", "Esporte", "Beleza" };
        var products = new List<Product>();
        for (int i = 1; i <= 30; i++)
        {
            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = $"{categorias[i % categorias.Length]} Modelo {i:D2}",
                Description = $"Descrição do produto número {i}, categoria {categorias[i % categorias.Length]}.",
                Price = Math.Round((decimal)(10 + (i * 7.35) % 490), 2), // valores variados entre ~10 e ~500
                StockQuantity = (i * 3) % 100 + 1,
                CreatedAt = DateTime.UtcNow.AddDays(-i * 2),
                UpdatedAt = i % 4 == 0 ? DateTime.UtcNow.AddDays(-i) : null
            });
        }
        await context.Set<Product>().AddRangeAsync(products);

        // ---------- 6 Clientes ----------
        var nomesClientes = new[]
        {
            "Ana Beatriz Souza", "Carlos Eduardo Lima", "Fernanda Oliveira",
            "João Pedro Santos", "Mariana Costa", "Rafael Almeida"
        };
        var clientes = new List<Cliente>();
        for (int i = 0; i < nomesClientes.Length; i++)
        {
            clientes.Add(new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = nomesClientes[i],
                Email = $"{nomesClientes[i].Split(' ')[0].ToLower()}.{i}@email.com",
                Cpf = $"{100000000 + i * 1111111}",
                DataCadastro = DateTime.UtcNow.AddMonths(-(i + 1)),
                Ativo = i != 4 // um cliente inativo, só para ter variação nos filtros
            });
        }
        await context.Set<Cliente>().AddRangeAsync(clientes);

        // ---------- 10 Pedidos (com itens ligados a produtos e clientes) ----------
        var statusPossiveis = new[]
        {
            StatusPedido.Pendente, StatusPedido.Pago, StatusPedido.Enviado,
            StatusPedido.Entregue, StatusPedido.Cancelado
        };

        var rnd = new Random(42); // seed fixa -> resultado sempre igual entre execuções
        var pedidos = new List<Pedido>();

        for (int i = 0; i < 10; i++)
        {
            var cliente = clientes[i % clientes.Count];
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                ClienteId = cliente.Id,
                DataPedido = DateTime.UtcNow.AddDays(-rnd.Next(1, 60)),
                Status = statusPossiveis[i % statusPossiveis.Length],
                Itens = new List<PedidoItem>()
            };

            // cada pedido tem entre 1 e 4 itens, com produtos aleatórios
            int qtdItens = rnd.Next(1, 5);
            var produtosEscolhidos = products.OrderBy(_ => rnd.Next()).Take(qtdItens);

            foreach (var produto in produtosEscolhidos)
            {
                pedido.Itens.Add(new PedidoItem
                {
                    Id = Guid.NewGuid(),
                    PedidoId = pedido.Id,
                    ProductId = produto.Id,
                    Quantidade = rnd.Next(1, 6),
                    PrecoUnitario = produto.Price // "congela" o preço no momento da compra
                });
            }

            pedidos.Add(pedido);
        }

        await context.Set<Pedido>().AddRangeAsync(pedidos);

        await context.SaveChangesAsync();
    }
}
