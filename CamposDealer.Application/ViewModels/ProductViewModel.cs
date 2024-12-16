using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(ProductEntity model)
        {
            if (model == null)
            {
                return;
            }

            Id = model.Id;
            Description = model.Description;
            ProductValue = model.ProductValue;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public float ProductValue { get; set; }
    }
}
