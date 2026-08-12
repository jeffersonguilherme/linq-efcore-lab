namespace LinqEfCoreLab.Entities;

public class PedidoItem
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}