using System.Threading.Tasks;
using Shop.API.Domain.Persistence.Contexts;
using Shop.API.Domain.Repositories;

namespace Shop.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}