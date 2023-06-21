using System.Text.Json;
using OpenAIPluginMiddleware;

// get some fake data
var products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("./Data/products.json"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Contoso Product Search", Version = "v1", Description = "Search through Contoso's wide range of outdoor and recreational products." });
});

builder.Services.AddAiPluginGen(options =>
{
    options.NameForHuman = "Contoso Product Search";
    options.NameForModel = "contosoproducts";
    options.LegalInfoUrl = "https://www.microsoft.com/en-us/legal/";
    options.ContactEmail = "noreply@microsoft.com";
    options.RelativeLogoUrl = "/logo.png";
    options.DescriptionForHuman = "Search through Contoso's wide range of outdoor and recreational products.";
    options.DescriptionForModel = "Plugin for searching through Contoso's outdoor and recreational products. Use it whenever a user asks about products or activities related to camping, hiking, climbing or camping.";
    options.ApiDefinition = new() { RelativeUrl = "/swagger/v1/swagger.yaml" };
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSwagger();
app.UseAiPluginGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", (string? query = null) =>
{
    if (query is not null) { 
        return products?.Where(p => p.Name?.Contains(query, StringComparison.OrdinalIgnoreCase) == true ||
            p.Description?.Contains(query, StringComparison.OrdinalIgnoreCase) == true || 
            p.Category?.Contains(query, StringComparison.OrdinalIgnoreCase) == true); 
    }

    return products;
})
.WithName("GetProducts")
.WithDescription("Get a list of products")
.WithOpenApi();

app.Run();
