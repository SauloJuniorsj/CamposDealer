using CamposDealer.Domain.Entities;
using System.ComponentModel;

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
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Valor do Produto")]
        public float ProductValue { get; set; }
    }
}
