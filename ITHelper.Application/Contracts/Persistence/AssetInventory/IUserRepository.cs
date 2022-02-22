using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.AssetInventory
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetUsersPerSite(int siteId);
        Task<IEnumerable<User>> GetUsersPerDepartment(int? siteId, int departmentId);
    }
}
