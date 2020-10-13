using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;
using Shop.API.Persistence.Contexts;
using Shop.API.Domain.Repositories;

namespace Shop.API.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Product product)
        {
            await context.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
             return await context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.Include(x => x.Category).ToListAsync();
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
        }
    }
}