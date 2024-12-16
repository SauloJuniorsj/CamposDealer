using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Context;

namespace CamposDealer.Persistence.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly CamposDealerContext _context;

        public DataRepository(CamposDealerContext context)
        {
            _context = context;
        }

        public async Task SaveClientesAsync(IEnumerable<ClientEntity> clientes)
        {
            _context.Clients.AddRange(clientes);
            await _context.SaveChangesAsync();
        }

        public async Task SaveProdutosAsync(IEnumerable<ProductEntity> produtos)
        {
            _context.Products.AddRange(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task SaveVendasAsync(IEnumerable<SalesEntity> vendas)
        {
            _context.Sales.AddRange(vendas);
            await _context.SaveChangesAsync();
        }
    }
}
