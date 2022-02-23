using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.AssetInventory
{
    public interface IHardwareRepository: IGenericRepository<Hardware>
    {
        Task<IEnumerable<Hardware>> GetHardwareByType(int hardwareTypeId);
        Task<IEnumerable<Hardware>> GetHardwareByOperation(bool IsOperational);
        Task<IEnumerable<Hardware>> GetHardwareByAssignment(bool IsAssigned);
        Task<IEnumerable<Hardware>> GetUserAssets(int userId);
        Task<IEnumerable<Hardware>> GetSiteAssets(int siteId);
        Task<IEnumerable<Hardware>> GetDepartmentAssets(int? siteId, int departmentId);
    }
}
