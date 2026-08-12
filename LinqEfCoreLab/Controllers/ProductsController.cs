using LinqEfCoreLab.Entities;
using LinqEfCoreLab.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinqEfCoreLab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        await _repository.AddAsync(product);
        return Ok(product);
    }
}