//Define las operaciones CRUD básicas para cualquier entidad.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
