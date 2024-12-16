using CamposDealer.Application.Services.Interfaces;
using System.Text.Json;

namespace CamposDealer.Application.Services.Implementations
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (content.StartsWith("\"") && content.EndsWith("\""))
            {
                content = JsonSerializer.Deserialize<string>(content); // Remove o nível extra de escapamento
            }

            try
            {
                // Tenta desserializar como lista
                return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (JsonException)
            {
                throw new InvalidOperationException($"Erro ao desserializar o JSON retornado: {content}");
            }
        }

        public DateTime ParseDate(string jsonDate)
        {
            if (jsonDate.StartsWith("/Date(") && jsonDate.EndsWith(")/"))
            {
                // Extraia o timestamp
                var timestamp = long.Parse(jsonDate[6..^2]);
                // Converta para DateTime
                return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
            }

            throw new FormatException("Formato de data inválido.");
        }
    }
}
