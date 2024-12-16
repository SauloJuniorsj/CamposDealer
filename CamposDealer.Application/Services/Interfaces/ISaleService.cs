using CamposDealer.Application.InputModels;
using CamposDealer.Application.ViewModels;

namespace CamposDealer.Application.Services.Interfaces
{
    public interface ISaleService
    {
        Task<CollectionSaleViewModel> GetAll(string query);
        Task<int> Create(CreateSaleInputModel model);
        Task<int> Update(UpdateSaleInputModel model);
        Task<int> Delete(int saleId);
        Task<SaleViewModel> GetById(int id);
    }
}
