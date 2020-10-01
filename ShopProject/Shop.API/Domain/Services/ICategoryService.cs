using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Controllers;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services.Communication;
using Shop.API.Resources;

namespace Shop.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<SaveCategoryResponse> SaveAsync(Category category);
         Task<SaveCategoryResponse> UpdateAsync(int id, Category category);
         Task<SaveCategoryResponse> DeleteAsync(int id);
    }
}