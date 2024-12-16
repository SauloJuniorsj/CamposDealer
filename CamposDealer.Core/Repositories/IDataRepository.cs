using CamposDealer.Domain.Entities;

namespace CamposDealer.Domain.Repositories
{
    public interface IDataRepository
    {
        Task SaveVendasAsync(IEnumerable<SalesEntity> vendas);
        Task SaveProdutosAsync(IEnumerable<ProductEntity> produtos);
        Task SaveClientesAsync(IEnumerable<ClientEntity> clientes);

    }
}
