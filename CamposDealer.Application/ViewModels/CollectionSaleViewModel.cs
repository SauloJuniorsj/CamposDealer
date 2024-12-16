using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.ViewModels
{
    public class CollectionSaleViewModel
    {
        public List<SaleViewModel> CollectionSale { get; set; }

        public CollectionSaleViewModel(List<SalesEntity> collection)
        {
            CollectionSale = new List<SaleViewModel>();

            CollectionSale = collection.Select(x => new SaleViewModel(x)).ToList();
        }
    }
}
