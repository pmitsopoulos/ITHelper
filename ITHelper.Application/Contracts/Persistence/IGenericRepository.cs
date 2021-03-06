using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence
{
    public interface IGenericRepository <T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync (int id);
        Task UpdateAsync (T entity);
        Task<T> CreateAsync (T entity);
        Task <bool> Exists(int id);

        Task <IEnumerable<T>> GetBySearchTermAsync(string searchTerm);
    }
}
