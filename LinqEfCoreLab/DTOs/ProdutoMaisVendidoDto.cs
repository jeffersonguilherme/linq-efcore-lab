namespace LinqEfCoreLab.DTOs;

public record ProdutoMaisVendidoDto(
    Guid ProductId,
    string ProductName,
    int QuantidadeVendida);