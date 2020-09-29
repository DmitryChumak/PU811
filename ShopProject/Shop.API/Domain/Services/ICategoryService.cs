using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;

namespace Shop.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
    }
}