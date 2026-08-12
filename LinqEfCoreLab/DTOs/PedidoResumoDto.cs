using LinqEfCoreLab.Enums;

namespace LinqEfCoreLab.DTOs;

public record PedidoResumoDto(
    Guid Id,
    string ClienteNome,
    DateTime DataPedido,
    decimal ValorTotal,
    StatusPedido Status);