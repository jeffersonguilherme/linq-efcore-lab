using LinqEfCoreLab.DTOs;
using LinqEfCoreLab.Entities;

namespace LinqEfCoreLab.Interfaces;

public interface IProductRepository
{
    // CRUD
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    // Pesquisa
    Task<List<Product>> SearchByNameAsync(string term);
    Task<List<Product>> SearchByDescriptionAsync(string term);
    // Ordenação
    Task<List<Product>> GetOrderByNameAsync();
    Task<List<Product>> GetOrderByPriceAscendingAsync();
    Task<List<Product>> GetOrderByPriceDescendingAsync();
    Task<List<Product>> GetNewestProductsAsync();
    // Filtros
    Task<List<Product>> GetProductsMoreExpensiveThanAsync(decimal price);
    Task<List<Product>> GetProductsCheaperThanAsync(decimal price);
    Task<List<Product>> GetProductsBetweenPricesAsync(decimal min, decimal max);
    // Estatísticas
    Task<int> CountAsync();
    Task<int> CountMoreExpensiveThanAsync(decimal price);
    Task<decimal> GetAveragePriceAsync();
    Task<decimal> GetHighestPriceAsync();
    Task<decimal> GetLowestPriceAsync();
    Task<decimal> GetTotalPriceAsync();
    // Existência
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsAsync(Guid id);
    // Paginação
    Task<List<Product>> GetPagedAsync(int page, int pageSize);
    // Projeções
    Task<List<string>> GetNamesAsync();
    Task<List<ProductPriceDto>> GetProductPricesAsync();
    // Atualizações
    Task UpdatePriceAsync(Guid id, decimal newPrice);
    Task UpdateNameAsync(Guid id, string newName);
    // Outros
    Task<List<Product>> GetCreatedAfterAsync(DateTime date);
    Task<List<Product>> GetUpdatedProductsAsync();
    Task<List<Product>> GetWithoutUpdateAsync();
    Task<List<Product>> GetTopMostExpensiveAsync(int quantity);
    Task<List<Product>> GetTopCheapestAsync(int quantity);
}