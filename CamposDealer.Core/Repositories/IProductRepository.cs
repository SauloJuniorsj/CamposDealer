using CamposDealer.Domain.Entities;

namespace CamposDealer.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAll(string query);
        Task<int> Create(ProductEntity model);
        Task<int> Update(ProductEntity model);
        Task<int> Delete(int ProductId);
        Task<ProductEntity> GetById(int id);
    }
}
