using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public static class ApiService
{
    private static readonly HttpClient client = new HttpClient();
    private const string BaseUrl = "https://makeup-api.herokuapp.com/api/v1/products.json";

    public static async Task<List<Product>> SearchProducts(string query)
    {
        try
        {
            var response = await client.GetAsync($"{BaseUrl}?brand={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products ?? new List<Product>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization error: {ex.Message}");
            // Možete ovdje dodati logiku za prikazivanje poruke korisniku
            return new List<Product>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP request error: {ex.Message}");
            // Možete ovdje dodati logiku za prikazivanje poruke korisniku
            return new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            // Možete ovdje dodati logiku za prikazivanje poruke korisniku
            return new List<Product>();
        }
    }
}