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
}