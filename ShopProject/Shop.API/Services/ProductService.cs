using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Domain.Services;
using Shop.API.Domain.Services.Communication;

namespace Shop.API.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;
        private IUnitOfWork unitOfWork;
        public ProductService(IProductRepository productRepository,
                               IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public Task<SaveProductResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await productRepository.ListAsync();
        }

        public Task<SaveProductResponse> SaveAsync(Product category)
        {
            throw new System.NotImplementedException();
        }

        public Task<SaveProductResponse> UpdateAsync(int id, Product category)
        {
            throw new System.NotImplementedException();
        }
    }
}