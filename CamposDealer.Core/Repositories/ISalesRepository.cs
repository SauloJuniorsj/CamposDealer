using CamposDealer.Domain.Entities;

namespace CamposDealer.Domain.Repositories
{
    public interface ISalesRepository
    {
        Task<List<SalesEntity>> GetAll(string query);
        Task<int> Create(SalesEntity createModel);
        Task<int> Update(SalesEntity updateModel);
        Task<int> Delete(int saleId);
        Task<SalesEntity> GetById(int saleId);
    }
}
