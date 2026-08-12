namespace LinqEfCoreLab.DTOs;

public record PedidoCreateDto(Guid ClienteId, List<PedidoItemCreateDto> Itens);
