using ConfortAssistan.IntegrationLab.Dtos;
using ConfortAssistant.IntegrationLab.Dtos;
using System.Net.Http.Json;

namespace ConfortAssistant.IntegrationLab.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        try
        {
            Console.WriteLine("Consultando productos desde una API real...");

            string url =
                "https://dummyjson.com/products" +
                "?limit=10&select=id,title,price,stock,category";

            DummyJsonResponseDto? response =
                await _httpClient.GetFromJsonAsync<DummyJsonResponseDto>(url);

            if (response is null)
            {
                Console.WriteLine("La API respondió sin información.");
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
        catch (HttpRequestException exception)
        {
            Console.WriteLine("No se pudo consultar la API.");
            Console.WriteLine($"Detalle técnico: {exception.Message}");

            return new List<ProductDto>();
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("La API demoró demasiado en responder.");

            return new List<ProductDto>();
        }
    }

}