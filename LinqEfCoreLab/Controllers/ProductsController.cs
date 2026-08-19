using LinqEfCoreLab.DTOs;
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
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto product)
    {
        await _repository.AddAsync(product);
        return Ok(product);
    }
    [HttpGet("count")]
    public async Task<IActionResult> Count()
    {
        return Ok(await _repository.CountAsync());
        
    }
    [HttpGet("countMaxValue")]
    public async Task<IActionResult> CountMoreExpensiveThanAsync([FromQuery] decimal price)
    {
        var result = await _repository.CountMoreExpensiveThanAsync(price);
        return Ok(result);
    }
}