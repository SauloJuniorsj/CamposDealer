using CamposDealer.Application.InputModels;
using CamposDealer.Application.ViewModels;
using CamposDealer.Domain.Entities;

namespace CamposDealer.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<CollectionClientViewModel> GetAll(string query);
        Task<int> Create(CreateClientInputModel model);
        Task<int> Update(UpdateClientInputModel model);
        Task<int> Delete(int ProductId);
        Task<ClientViewModel> GetById(int id);
    }
}
