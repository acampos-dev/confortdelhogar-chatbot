using ConfortAssistan.IntegrationLab.Dtos;
using System.Text.Json;
using ConfortAssistant.IntegrationLab.Services;
using HttpClient httpClient = new();
ProductService productService = new(httpClient);

List<ProductDto> products =
    await productService.GetProductsAsync();


JsonSerializerOptions options = new() // Configuración de serialización JSON
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
};

string productsJson = JsonSerializer.Serialize(products, options); // Convertir la lista de productos a JSON

Console.WriteLine("Lista convertida a JSON:");
Console.WriteLine(productsJson);

List<ProductDto>? deserializedProducts =
    JsonSerializer.Deserialize<List<ProductDto>>(productsJson, options);

if (deserializedProducts is null)
{
    Console.WriteLine("No se pudieron recuperar los productos.");
    return;
}

Console.WriteLine("\nProductos recuperados:");

foreach (ProductDto product in deserializedProducts)
{
    Console.WriteLine(
        $"- {product.Name} | Precio: ${product.Price} | Stock: {product.Stock}"
    );
}

Console.WriteLine($"\nCantidad total: {deserializedProducts.Count}");

decimal maximumBudget;

while (true)
{
    Console.Write("\nIngresá tu presupuesto máximo: $");

    string? input = Console.ReadLine();

    bool isValidBudget =
        decimal.TryParse(input, out maximumBudget) &&
        maximumBudget > 0;

    if (isValidBudget)
    {
        break;
    }

    Console.WriteLine(
        "El presupuesto no es válido. Ingresá un número mayor que cero."
    );
}

List<ProductDto> aviableProducts = deserializedProducts
    .Where(product =>
        product.Stock > 0 &&
        product.Price <= maximumBudget)
    .OrderBy(product => product.Price)
    .ToList();

Console.WriteLine(
    $"\nProductos disponibles con un presupuesto máximo de ${maximumBudget}:"
    );

if ( aviableProducts.Count == 0)
{
    Console.WriteLine("No se encontraron productos.");
}
else
{
    foreach (ProductDto product in aviableProducts)
    {
        Console.WriteLine(
            $"- {product.Name} | Precio: ${product.Price} | Stock: {product.Stock}"
        );
    }
}