using System.Text.Json;

// get some fake data
List<Product> products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("./Data/products.json"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer() { Url = "https://r2bcgg47-7070.usw2.devtunnels.ms/" });
    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer() { Url = "https://localhost:7070" });
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Contoso Product Search", Version = "v1", Description = "Search through Contoso's wide range of outdoor and recreational products." });
});
builder.Services.AddCors();

var app = builder.Build();

app.UseStaticFiles();
app.UseSwagger(c =>
{
    c.RouteTemplate = "/api-docs/{documentName}/openapi.yaml";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/api-docs/v1/openapi.yaml", "Contoso Product Search");
    });
}

app.UseHttpsRedirection();
app.UseCors(policy => policy
    .WithOrigins("https://chat.openai.com")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapGet("/.well-known/ai-plugin.json", async (HttpRequest http) =>
{
    // get any forwarded host from the HttpRequest
    var forwardedHost = http.Headers["X-Forwarded-Host"].FirstOrDefault() ?? http.Headers["Host"];
    var protocol = http.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? http.Scheme;
    var hostUri = $"{protocol}://{forwardedHost}";

    // open the .well-known/ai-plugin.json file
    var aiPlugin = await File.ReadAllTextAsync("./Data/ai-plugin.json");

    // return the aiPlugin value as application/json response
    return JsonDocument.Parse(aiPlugin.Replace("$host", hostUri)).RootElement;
});

app.MapGet("/products", (string? query = null) =>
{
    if (query != null) { 
        return products?.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || 
        p.Description.Contains(query, StringComparison.OrdinalIgnoreCase) || 
        p.Category.Contains(query, StringComparison.OrdinalIgnoreCase) ); 
    }

    return products;
})
.WithName("GetProducts")
.WithDescription("Get a list of products")
.WithOpenApi();

app.Run();
