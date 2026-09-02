namespace ConfortAssistant.Api.Dtos;

    public class DummyJsonProductDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string Category { get; set; } = string.Empty;
}