using CamposDealer.Application.InputModels;
using CamposDealer.Application.ViewModels;

namespace CamposDealer.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<CollectionProductViewModel> GetAll(string query);
        Task<int> Create(CreateProductInputModel model);
        Task<int> Update(UpdateProductInputModel model);
        Task<int> Delete(int ProductId);
        Task<ProductViewModel> GetById(int id);
    }
}
