using ConfortAssistant.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IMessageProcessor, RuleBasedMessageProcessor>();

builder.Services.AddHttpClient<
    IProductService,
    DummyJsonProductService>(httpClient =>
    {
        httpClient.BaseAddress =
            new Uri("https://dummyjson.com/");

        httpClient.Timeout =
            TimeSpan.FromSeconds(10);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
