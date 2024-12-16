using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Application.ViewModels;
using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;

namespace CamposDealer.Application.Services.Implementations
{
    public class SalesService : ISaleService
    {
        private readonly ISalesRepository _salesRepository;
        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<int> Create(CreateSaleInputModel model)
        {
            SalesEntity sales = new SalesEntity(
                model.IdClient,
                model.IdProduct,
                model.SalesQtd,
                model.ValueUnitValue,
                model.SaleDatetime,
                model.TotalSaleValue
                );

            return await _salesRepository.Create(sales);
        }

        public async Task<int> Delete(int saleId)
        {
            return await _salesRepository.Delete(saleId);
        }

        public async Task<CollectionSaleViewModel> GetAll(string query)
        {
            var clients = await _salesRepository.GetAll(query);
            var clientsViewModels = new CollectionSaleViewModel(clients);
            return clientsViewModels;
        }

        public async Task<SaleViewModel> GetById(int id)
        {
            var sale = await _salesRepository.GetById(id);

            if (sale == null)
            {
                return null;
            }

            return new SaleViewModel(sale);
        }

        public async Task<int> Update(UpdateSaleInputModel model)
        {
            var oldModel = await GetById(model.Id);

            SalesEntity sale = new SalesEntity(model.Id, model.IdClient, model.IdProduct, model.SalesQtd, model.ValueUnitValue, model.TotalSaleValue);

            return await _salesRepository.Update(sale);
        }
    }
}
