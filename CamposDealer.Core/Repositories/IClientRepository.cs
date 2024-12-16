using CamposDealer.Domain.Entities;

namespace CamposDealer.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<List<ClientEntity>> GetAll();
        Task<int> Create(ClientEntity model);
        Task<int> Update(ClientEntity model);
        Task<int> Delete(int ProductId);
        Task<ClientEntity> GetById(int id);
    }
}
