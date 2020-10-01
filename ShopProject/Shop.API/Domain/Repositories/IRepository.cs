using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.API.Domain.Repositories
{
    public interface IRepository<T> where T: class, new()
    {
         Task<IEnumerable<T>> ListAsync();
         Task AddAsync(T category);
         Task<T> FindByIdAsync(int id);
         void Update(T category);
         void Remove(T category);
    }
}