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

            Id = model.Id;
            IdClient = model.IdClient;
            IdProduct = model.IdProduct;
            SalesQtd = model.SalesQtd;
            ValueUnitValue = model.ValueUnitValue;
            SaleDatetime = model.SaleDatetime;
            TotalSaleValue = model.TotalSaleValue;
            Client = new ClientViewModel(model.Client);
            Product = new ProductViewModel(model.Product);
        }

        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int SalesQtd { get; set; }
        public float ValueUnitValue { get; set; }
        public DateTime SaleDatetime { get; set; }
        public float TotalSaleValue { get; set; }
        public ClientViewModel Client { get; set; }
        public ProductViewModel Product { get; set; }

    }
}
