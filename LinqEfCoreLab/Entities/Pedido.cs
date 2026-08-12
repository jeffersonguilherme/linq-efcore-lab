using LinqEfCoreLab.Enums;

namespace LinqEfCoreLab.Entities;

public class Pedido
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public DateTime DataPedido { get; set; }
    public StatusPedido Status { get; set; }

    public ICollection<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
}