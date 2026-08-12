using Microsoft.EntityFrameworkCore;
using LinqEfCoreLab.Entities; // Ajuste para o namespace correto do seu projeto

namespace LinqEfCoreLab.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoItem> PedidoItems => Set<PedidoItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}