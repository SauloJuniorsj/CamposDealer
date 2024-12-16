using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateProductInputModel
    {
        [JsonPropertyName("idProduto")]
        public required int Id { get; set; }
        [JsonPropertyName("dscProduto")]
        public required string Description { get; set; }
        [JsonPropertyName("vlrUnitario")]
        public required float ProductValue { get; set; }
    }
}
