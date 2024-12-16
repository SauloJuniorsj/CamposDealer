using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateClientInputModel
    {
        [JsonPropertyName("idCliente")]
        public required int Id { get; set; }
        [JsonPropertyName("nmCliente")]
        public required string Name { get; set; }
        [JsonPropertyName("Cidade")]
        public required string City { get; set; }
    }
}
