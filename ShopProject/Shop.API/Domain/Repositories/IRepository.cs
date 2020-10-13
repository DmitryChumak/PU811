using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.API.Domain.Repositories
{
    public interface IRepository<T> where T: class, new()
    {
         Task<IEnumerable<T>> ListAsync();
         Task AddAsync(T entity);
         Task<T> FindByIdAsync(int id);
         void Update(T entity);
         void Remove(T entity);
    }
}