using ConfortAssistant.Api.Dtos;
using ConfortAssistant.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfortAssistant.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        List<ProductDto> products =
            await _productService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts([FromQuery] string? query)
    {
       if(string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Debe ingresar un texto para buscar productos.");
        }

       var products = await _productService.SearchProductsAsync(query);

        return Ok(products);
    }
}