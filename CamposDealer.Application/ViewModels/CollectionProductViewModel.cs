using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.ViewModels
{
    public class CollectionProductViewModel
    {
        public List<ProductViewModel> CollectionProduct { get; set; }

        public CollectionProductViewModel(List<ProductEntity> collection)
        {
            CollectionProduct = new List<ProductViewModel>();

            CollectionProduct = collection.Select(x => new ProductViewModel(x)).ToList();
        }
    }
}
