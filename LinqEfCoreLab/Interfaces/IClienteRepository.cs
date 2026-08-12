using LinqEfCoreLab.DTOs;
using LinqEfCoreLab.Entities;

namespace LinqEfCoreLab.Interfaces;

public interface IClienteRepository
{
    // ---------- CRUD ----------
    Task<Cliente?> GetByIdAsync(Guid id);                       // busca 1 cliente pelo Id (ou null)
    Task<List<Cliente>> GetAllAsync();                           // lista todos os clientes
    Task AddAsync(Cliente cliente);                              // insere um novo cliente
    Task UpdateAsync(Cliente cliente);                           // atualiza um cliente existente
    Task DeleteAsync(Cliente cliente);                           // remove um cliente

    // ---------- Pesquisa ----------
    Task<List<Cliente>> SearchByNameAsync(string term);          // clientes cujo Nome contém "term"
    Task<List<Cliente>> SearchByEmailAsync(string term);         // clientes cujo Email contém "term"

    // ---------- Ordenação ----------
    Task<List<Cliente>> GetOrderByNameAsync();                   // ordena por Nome (A-Z)
    Task<List<Cliente>> GetOrderByDataCadastroDescendingAsync(); // mais recentes primeiro

    // ---------- Filtros ----------
    Task<List<Cliente>> GetAtivosAsync();                        // apenas clientes com Ativo == true
    Task<List<Cliente>> GetInativosAsync();                      // apenas clientes com Ativo == false
    Task<List<Cliente>> GetByDataCadastroRangeAsync(DateTime inicio, DateTime fim); // cadastrados no período

    // ---------- Estatísticas ----------
    Task<int> CountAsync();                                      // total de clientes
    Task<int> CountAtivosAsync();                                // total de clientes ativos
    Task<int> CountPedidosByClienteAsync(Guid clienteId);        // quantos pedidos o cliente tem

    // ---------- Existência ----------
    Task<bool> ExistsAsync(Guid id);                             // cliente existe?
    Task<bool> ExistsByEmailAsync(string email);                 // já existe cliente com esse email?

    // ---------- Paginação ----------
    Task<List<Cliente>> GetPagedAsync(int page, int pageSize);   // página de clientes

    // ---------- Projeções ----------
    Task<List<string>> GetNomesAsync();                          // apenas os nomes (sem trazer entidade inteira)
    Task<List<ClienteResumoDto>> GetResumoAsync();                // projeção leve (Id, Nome, Email)

    // ---------- Atualização (parcial) ----------
    Task UpdateEmailAsync(Guid id, string novoEmail);            // atualiza só o email
    Task AtivarClienteAsync(Guid id);                            // seta Ativo = true
    Task DesativarClienteAsync(Guid id);                         // seta Ativo = false

    // ---------- Outros ----------
    Task<List<Cliente>> GetClientesComPedidosAsync();             // clientes que já fizeram pelo menos 1 pedido
    Task<List<Cliente>> GetClientesSemPedidosAsync();              // clientes que nunca compraram
    Task<List<Cliente>> GetTopClientesByValorComprasAsync(int quantity); // maiores compradores (soma dos pedidos)
}