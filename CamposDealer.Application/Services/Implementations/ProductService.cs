using CamposDealer.Application.InputModels;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Application.ViewModels;
using CamposDealer.Domain.Entities;
using CamposDealer.Domain.Repositories;

namespace CamposDealer.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Create(CreateProductInputModel model)
        {
            ProductEntity product = new ProductEntity(model.Description, model.ProductValue);

            await _productRepository.Create(product);

            return product.Id;
        }

        public async Task<int> Delete(int ProductId)
        {
            return await _productRepository.Delete(ProductId);
        }

        public async Task<CollectionProductViewModel> GetAll(string query)
        {
            var products = await _productRepository.GetAll(query);
            var productsViewModels = new CollectionProductViewModel(products);
            return productsViewModels;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            return new ProductViewModel(product);
        }

        public async Task<int> Update(UpdateProductInputModel model)
        {
            var oldModel = await GetById(model.Id);

            ProductEntity product = new ProductEntity(model.Id, model.Description, model.ProductValue);
            
            return await _productRepository.Update(product);
        }
    }
}
