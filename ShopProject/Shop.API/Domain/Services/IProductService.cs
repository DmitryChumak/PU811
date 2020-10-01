using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services.Communication;

namespace Shop.API.Domain.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
         Task<SaveProductResponse> SaveAsync(Product category);
         Task<SaveProductResponse> UpdateAsync(int id, Product category);
         Task<SaveProductResponse> DeleteAsync(int id);
    }
}