using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateSaleInputModel
    {
        public int Id { get; set; }
        public DateTime SaleDatetime { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int SalesQtd { get; set; }
        public int ValueUnitValue { get; set; }
        public float TotalSaleValue { get; set; }
    }
}
