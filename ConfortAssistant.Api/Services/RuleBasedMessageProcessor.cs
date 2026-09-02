namespace ConfortAssistant.Api.Services;

public class RuleBasedMessageProcessor : IMessageProcessor
{
    private readonly IProductService _productService;

    public RuleBasedMessageProcessor(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<string> GenerateReplyAsync(string message)
    {
        if (message.Contains(
            "perfume",
            StringComparison.OrdinalIgnoreCase))
        {
            var products =
                await _productService.GetProductsAsync();

            var fragrances = products
                .Where(product =>
                    product.Stock > 0 &&
                    product.Category.Equals(
                        "fragrances",
                        StringComparison.OrdinalIgnoreCase))
                .OrderBy(product => product.Price)
                .Take(3)
                .ToList();

            if (fragrances.Count == 0)
            {
                return "En este momento no encontré perfumes disponibles.";
            }

            string options = string.Join(
                Environment.NewLine,
                fragrances.Select(product =>
                    $"- {product.Name}: " +
                    $"${product.Price:0.00} " +
                    $"{product.ProductUrl}"));

            return "Encontré estas opciones:" +
                   Environment.NewLine +
                   options;
        }

        if (message.Contains(
            "lavarropas",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Sí, tenemos lavarropas disponibles. " +
                   "¿Qué presupuesto manejás?";
        }

        return "Gracias por comunicarte con Confort del Hogar. " +
               "¿En qué podemos ayudarte?";
    }
}