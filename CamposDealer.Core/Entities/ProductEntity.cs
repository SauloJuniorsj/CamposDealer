
namespace CamposDealer.Domain.Entities
{
    public class ProductEntity
    {
        public ProductEntity(string description, float productValue)
        {
            Description = description;
            ProductValue = productValue;
        }

        public ProductEntity(int id, string description, float productValue)
        {
            Id = id;
            Description = description;
            ProductValue = productValue;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public float ProductValue { get; set; }
    }
}
