using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Application.ViewModels;
using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Repositories;

namespace CamposDealer.Application.Services.Implementations
{
    public class SalesService : ISaleService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        public SalesService(ISalesRepository salesRepository, IProductRepository productRepository)
        {
            _salesRepository = salesRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Create(CreateSaleInputModel model)
        {
            var product = await _productRepository.GetById(model.IdProduct);
            
            if (product == null)
            {
                return 0;
            }

            SalesEntity sales = new SalesEntity(
                model.IdClient,
                model.IdProduct,
                model.SalesQtd,
                product.ProductValue,
                DateTime.Now,
                product.ProductValue * model.SalesQtd
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
            var sale = await _salesRepository.GetById(model.Id);

            if (sale == null)
            {
                return 0;
            }

            sale.TotalSaleValue = model.TotalSaleValue;
            sale.SalesQtd = model.SalesQtd;
            sale.ValueUnitValue = model.ValueUnitValue;
            sale.IdClient = model.IdClient;
            sale.IdProduct = model.IdProduct;
            sale.Id = model.Id;
            sale.TotalSaleValue = model.SalesQtd * sale.Product.ProductValue;
            sale.SalesQtd = model.SalesQtd;

            return await _salesRepository.Update(sale);

        }
    }
}
