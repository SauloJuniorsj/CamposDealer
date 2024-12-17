namespace CamposDealer.Presentation.Models
{
    public class SalesForm
    {
        public required int IdClient { get; set; }
        public required int IdProduct { get; set; }
        public required int SalesQtd { get; set; }
        public required int ValueUnitValue { get; set; }
        public required float TotalSaleValue { get; set; }
    }
}
