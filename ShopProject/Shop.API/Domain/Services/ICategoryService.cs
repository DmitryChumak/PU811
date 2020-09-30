using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Controllers;
using Shop.API.Domain.Models;
using Shop.API.Resources;

namespace Shop.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}