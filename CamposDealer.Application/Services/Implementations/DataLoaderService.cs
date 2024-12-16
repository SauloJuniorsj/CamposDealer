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
            var clientes = await _apiService.GetAsync<List<ClientJsonViewModel>>("https://camposdealer.dev/Sites/TesteAPI/cliente");
            IEnumerable<ClientEntity> convertedClient = clientes.Select(x => new ClientEntity(x.nmCliente, x.Cidade));
            await _repository.SaveClientesAsync(convertedClient);

            var produtos = await _apiService.GetAsync<List<ProductJsonInputModel>>("https://camposdealer.dev/Sites/TesteAPI/produto");
            IEnumerable<ProductEntity> convertedProduct = produtos.Select(x => new ProductEntity(x.dscProduto, x.vlrUnitario));
            await _repository.SaveProdutosAsync(convertedProduct);

            var vendas = await _apiService.GetAsync<List<SaleJsonInputModel>>("https://camposdealer.dev/Sites/TesteAPI/venda");
            IEnumerable<SalesEntity> convertedVenda = vendas.Select(x => new SalesEntity(x.idCliente, x.idProduto, x.qtdVenda, x.vlrUnitarioVenda, _apiService.ParseDate(x.dthVenda)));
            await _repository.SaveVendasAsync(convertedVenda);
        }
    }
}
