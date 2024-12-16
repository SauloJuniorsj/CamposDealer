using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateSaleInputModel
    {
        [JsonPropertyName("idVenda")]
        public int Id { get; set; }
        [JsonPropertyName("dthVenda")]
        public DateTime SaleDatetime { get; set; }
        [JsonPropertyName("idCliente")]
        public int IdClient { get; set; }
        [JsonPropertyName("idProduto")]
        public int IdProduct { get; set; }
        [JsonPropertyName("qdtVenda")]
        public int SalesQtd { get; set; }
        [JsonPropertyName("vlrUnitarioVenda")]
        public int ValueUnitValue { get; set; }
        public float TotalSaleValue { get; set; }
    }
}
