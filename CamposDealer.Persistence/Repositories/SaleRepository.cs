using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Exceptions;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CamposDealer.Persistence.Repositories
{
    public class SaleRepository : ISalesRepository
    {
        private readonly CamposDealerContext _db;
        public SaleRepository(CamposDealerContext context)
        {
            _db = context;
        }

        public async Task<int> Create(SalesEntity createModel)
        {
            try
            {
                _db.Sales.Add(createModel);

                await _db.SaveChangesAsync();

                return createModel.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar venda", ex);
            }
        }

        public async Task<int> Delete(int saleId)
        {
            try
            {
                var sale = await GetById(saleId);

                if (sale == null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotDeleteSale);

                }

                _db.Sales.Remove(sale);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<List<SalesEntity>> GetAll(string query)
        {
            var querySales = _db.Sales
                .Include(x => x.Client)
                .Include(x => x.Product)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                querySales.Where(x => x.Client.Name.Contains(query) || x.Product.Description.Contains(query));
            }

            return await querySales.ToListAsync();
        }

        public async Task<SalesEntity> GetById(int saleId)
        {
            try
            {
                var sale = await _db.Sales
                    .Include(x => x.Client)
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync();

                if (sale is null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotGetSale + saleId);
                }

                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> Update(SalesEntity updateModel)
        {
            try
            {
                var trackedEntity = _db.Sales.Local.FirstOrDefault(x => x.Id == updateModel.Id);

                _db.Sales.Update(updateModel);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
