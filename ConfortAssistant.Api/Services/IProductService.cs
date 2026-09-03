using ConfortAssistant.Api.Dtos;

namespace ConfortAssistant.Api.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();

        Task<List<ProductDto>> SearchProductsAsync(string query); 
    }
}
