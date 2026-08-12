using LinqEfCoreLab.DTOs;
using LinqEfCoreLab.Entities;
using LinqEfCoreLab.Enums;

namespace LinqEfCoreLab.Interfaces;

public interface IPedidoRepository
{
    // ---------- CRUD ----------
    Task<Pedido?> GetByIdAsync(Guid id);                          // busca 1 pedido (traga os Itens junto, use Include)
    Task<List<Pedido>> GetAllAsync();                              // lista todos os pedidos
    Task AddAsync(Pedido pedido);                                  // insere um novo pedido (com itens)
    Task UpdateAsync(Pedido pedido);                               // atualiza um pedido existente
    Task DeleteAsync(Pedido pedido);                               // remove um pedido

    // ---------- Pesquisa ----------
    Task<List<Pedido>> SearchByClienteNomeAsync(string term);      // pedidos cujo Cliente.Nome contém "term"

    // ---------- Ordenação ----------
    Task<List<Pedido>> GetOrderByDataDescendingAsync();             // mais recentes primeiro
    Task<List<Pedido>> GetOrderByValorTotalDescendingAsync();       // do maior valor pro menor

    // ---------- Filtros ----------
    Task<List<Pedido>> GetByStatusAsync(StatusPedido status);       // pedidos com determinado status
    Task<List<Pedido>> GetByClienteIdAsync(Guid clienteId);         // pedidos de um cliente específico
    Task<List<Pedido>> GetByPeriodoAsync(DateTime inicio, DateTime fim); // pedidos feitos no período
    Task<List<Pedido>> GetByValorMinimoAsync(decimal valorMinimo);  // pedidos cujo total >= valorMinimo

    // ---------- Estatísticas ----------
    Task<int> CountAsync();                                        // total de pedidos
    Task<int> CountByStatusAsync(StatusPedido status);              // total de pedidos por status
    Task<decimal> GetValorTotalVendidoAsync();                      // soma de todos os pedidos (faturamento)
    Task<decimal> GetTicketMedioAsync();                            // valor médio por pedido

    // ---------- Existência ----------
    Task<bool> ExistsAsync(Guid id);                                // pedido existe?
    Task<bool> ClienteTemPedidosAsync(Guid clienteId);              // cliente possui algum pedido?

    // ---------- Paginação ----------
    Task<List<Pedido>> GetPagedAsync(int page, int pageSize);       // página de pedidos

    // ---------- Projeções ----------
    Task<List<PedidoResumoDto>> GetResumoAsync();                    // projeção leve (Id, Cliente, Data, Total)
    Task<List<Guid>> GetIdsAsync();                                  // apenas os Ids de todos os pedidos

    // ---------- Atualização (parcial) ----------
    Task UpdateStatusAsync(Guid id, StatusPedido novoStatus);        // troca só o status
    Task CancelarPedidoAsync(Guid id);                               // atalho: status = Cancelado

    // ---------- Outros ----------
    Task<List<Pedido>> GetPedidosComItensAsync();                    // Include + ThenInclude (Itens + Product)
    Task<List<Pedido>> GetUltimosPedidosAsync(int quantity);         // os N pedidos mais recentes
    Task<List<ProdutoMaisVendidoDto>> GetProdutosMaisVendidosAsync(int quantity); // GroupBy por produto
}