using System.Net.Http.Json;
using ConfortAssistant.Api.Dtos;

namespace ConfortAssistant.Api.Services;

public class DummyJsonProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public DummyJsonProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        DummyJsonResponseDto? response =
            await _httpClient.GetFromJsonAsync<DummyJsonResponseDto>(
                "products?limit=10&select=id,title,price,stock,category");

        if (response is null)
        {
            return new List<ProductDto>();
        }

        return response.Products
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Title,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                ProductUrl =
                    $"https://dummyjson.com/products/{product.Id}"
            })
            .ToList();
    }

    public async Task<List<ProductDto>> SearchProductsAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new List<ProductDto>();
        }

        string safeQuery = Uri.EscapeDataString(query);

        DummyJsonResponseDto? response =
            await _httpClient.GetFromJsonAsync<DummyJsonResponseDto>(
                $"products/search?q={safeQuery}&limit=10&select=id,title,price,stock,category");

        if (response is null)
        {
            return new List<ProductDto>();
        }

        return response.Products
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Title,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                ProductUrl =
                    $"https://dummyjson.com/products/{product.Id}"
            })
            .ToList();
    }
}