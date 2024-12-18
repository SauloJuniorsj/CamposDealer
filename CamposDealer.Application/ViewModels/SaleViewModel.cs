using CamposDealer.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Cliente")]
        public int IdClient { get; set; }
        [DisplayName("Produto")]
        public int IdProduct { get; set; }
        [DisplayName("Quantidade")]
        public int SalesQtd { get; set; }
        [DisplayName("Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float ValueUnitValue { get; set; }
        [DisplayName("Data da Venda")]
        public DateTime SaleDatetime { get; set; }
        [DisplayName("Valor Total")]
        public float TotalSaleValue { get; set; }
        public ClientViewModel Client { get; set; }
        public ProductViewModel Product { get; set; }

    }
}
