using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("category")]
    public string? Category { get; set; }
    [JsonPropertyName("size")]
    public string? Size { get; set; }
    [JsonPropertyName("price")]
    public float Price { get; set; }
}
