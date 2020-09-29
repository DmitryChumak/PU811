using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Domain.Services;

namespace Shop.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await categoryRepository.ListAsync();
        }
    }
}