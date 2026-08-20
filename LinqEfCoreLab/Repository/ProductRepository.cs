using LinqEfCoreLab.Data;
using LinqEfCoreLab.DTOs;
using LinqEfCoreLab.Entities;
using LinqEfCoreLab.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinqEfCoreLab.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProductCreateDto product)
    {
        var productDto = Product.Create(
            product.Name,
            product.Description,
            product.Price,
            product.StockQuantity
        );

        await _context.Products.AddAsync(productDto);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task<int> CountMoreExpensiveThanAsync(decimal price)
    {
        var valor = await _context.Products.Where(p => p.Price > price).CountAsync();
        return valor;
    }

    public Task DeleteAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();         
    }

    public Task<decimal> GetAveragePriceAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetCreatedAfterAsync(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetHighestPriceAsync()
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetLowestPriceAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetNamesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetNewestProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderByNameAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderByPriceAscendingAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderByPriceDescendingAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetPagedAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductPriceDto>> GetProductPricesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetProductsBetweenPricesAsync(decimal min, decimal max)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetProductsCheaperThanAsync(decimal price)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductsMoreExpensiveThanAsync(decimal price)
    {
        return await _context.Products.Where(p=> p.Price > price).ToListAsync();
    }

    public Task<List<Product>> GetTopCheapestAsync(int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetTopMostExpensiveAsync(int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetTotalPriceAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetUpdatedProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetWithoutUpdateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> SearchByDescriptionAsync(string term)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> SearchByNameAsync(string term)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNameAsync(Guid id, string newName)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePriceAsync(Guid id, decimal newPrice)
    {
        throw new NotImplementedException();
    }
}