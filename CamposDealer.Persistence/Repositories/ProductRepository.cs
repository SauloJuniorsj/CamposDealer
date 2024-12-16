using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Exceptions;
using CamposDealer.Domain.Repositories;
using CamposDealer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CamposDealer.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CamposDealerContext _db;
        public ProductRepository(CamposDealerContext context)
        {
            _db = context;
        }
        public async Task<int> Create(ProductEntity model)
        {
            try
            {
                _db.Products.Add(model);

                await _db.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar Produto", ex);
            }
        }

        public async Task<int> Delete(int ProductId)
        {
            try
            {
                var product = await GetById(ProductId);

                if (product == null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotGetProduct);

                }

                _db.Products.Remove(product);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            try
            {
                var product = await _db.Products
                    .FirstOrDefaultAsync();

                if (product is null)
                {
                    throw new DomainLogicException(ErrorConstants.CannotGetProduct + id);
                }

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> Update(ProductEntity model)
        {
            try
            {
                var trackedEntity = _db.Sales.Local.FirstOrDefault(x => x.Id == model.Id);

                _db.Products.Update(model);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
