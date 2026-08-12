namespace LinqEfCoreLab.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}