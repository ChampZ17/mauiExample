// Product.cs
using System.Text.Json;
using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("price_sign")]
    public string PriceSign { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("image_link")]
    public string ImageLink { get; set; }

    [JsonPropertyName("product_link")]
    public string ProductLink { get; set; }

    [JsonPropertyName("website_link")]
    public string WebsiteLink { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("product_type")]
    public string ProductType { get; set; }

    [JsonPropertyName("tag_list")]
    public List<string> TagList { get; set; }

    public string PriceDisplay => $"{PriceSign}{Price} {Currency}";
}