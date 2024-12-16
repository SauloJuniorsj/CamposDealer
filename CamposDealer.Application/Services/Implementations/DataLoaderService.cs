using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Repositories;

namespace CamposDealer.Application.Services.Implementations
{
    public class DataLoaderService : IDataLoaderService
    {
        private readonly IApiService _apiService;
        private readonly IDataRepository _repository;

        public DataLoaderService(IApiService apiService, IDataRepository repository)
        {
            _apiService = apiService;
            _repository = repository;
        }

        public async Task LoadDataAsync()
        {
            var clientes = await _apiService.GetAsync<UpdateClientInputModel>("https://camposdealer.dev/Sites/TesteAPI/cliente");
            IEnumerable<ClientEntity> convertedClient = clientes.Select(x => new ClientEntity(x.Id, x.Name, x.City));
            await _repository.SaveClientesAsync(convertedClient);

            var produtos = await _apiService.GetAsync<UpdateProductInputModel>("https://camposdealer.dev/Sites/TesteAPI/produto");
            IEnumerable<ProductEntity> convertedProduct = produtos.Select(x => new ProductEntity(x.Id, x.Description, x.ProductValue));
            await _repository.SaveProdutosAsync(convertedProduct);

            var vendas = await _apiService.GetAsync<UpdateSaleInputModel>("https://camposdealer.dev/Sites/TesteAPI/venda");
            IEnumerable<SalesEntity> convertedVenda = vendas.Select(x => new SalesEntity(x.Id, x.IdClient, x.IdProduct, x.SalesQtd, x.ValueUnitValue, x.SaleDatetime, x.TotalSaleValue));
            await _repository.SaveVendasAsync(convertedVenda);
        }
    }
}
