namespace CamposDealer.Application.InputModels
{
    public class CreateSaleInputModel
    {
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int SalesQtd { get; set; }
        public int ValueUnitValue { get; set; }
        public DateTime SaleDatetime { get; set; }
        public float TotalSaleValue { get; set; }
    }
}
