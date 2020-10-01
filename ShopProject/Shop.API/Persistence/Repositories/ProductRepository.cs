using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;
using Shop.API.Domain.Persistence.Contexts;
using Shop.API.Domain.Repositories;

namespace Shop.API.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Product category)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.Include(x => x.Category).ToListAsync();
        }

        public void Remove(Product category)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product category)
        {
            throw new System.NotImplementedException();
        }
    }
}