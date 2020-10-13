using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Persistence.Contexts;

namespace Shop.API.Persistence.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await context.Users 
                                    .Include(x => x.UserRoles)
                                        .ThenInclude(x => x.Role)
                                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await context.Users.Include(x => x.UserRoles)
                                        .ThenInclude(x => x.Role)
                                            .ToListAsync();
        }

        public void Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}