using System;
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
        public async Task<SaveProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new SaveProductResponse("Product not found");

            try 
            {
                productRepository.Remove(existingProduct);
                await unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"Error when deleting product: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await productRepository.ListAsync();
        }

        public async Task<SaveProductResponse> SaveAsync(Product product)
        {
            try 
            {
                await productRepository.AddAsync(product);
                await unitOfWork.CompleteAsync();

                return new SaveProductResponse(product);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"Save product error: {ex.Message}");
            }
        }

        public async Task<SaveProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new SaveProductResponse("Product not found");
            
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.ProductCount = product.ProductCount;
            existingProduct.ProductName = product.ProductName;

            try
            {
                productRepository.Update(existingProduct);
                await unitOfWork.CompleteAsync();

                return new SaveProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"Error when updating product: {ex.Message}");
            }
        }
    }
}