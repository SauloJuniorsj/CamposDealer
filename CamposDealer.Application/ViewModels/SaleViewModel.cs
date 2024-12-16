using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.ViewModels
{
    public class SaleViewModel
    {
        public SaleViewModel(SalesEntity model)
        {
            if (model == null)
            {
                return;
            }

            Id = model.IdProduct;
            IdClient = model.IdClient;
            IdProduct = model.IdProduct;
            SalesQtd = model.SalesQtd;
            ValueUnitValue = model.ValueUnitValue;
            SaleDatetime = model.SaleDatetime;
            TotalSaleValue = model.TotalSaleValue;
        }

        int Id { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int SalesQtd { get; set; }
        public int ValueUnitValue { get; set; }
        public DateTime SaleDatetime { get; set; }
        public float TotalSaleValue { get; set; }

    }
}
