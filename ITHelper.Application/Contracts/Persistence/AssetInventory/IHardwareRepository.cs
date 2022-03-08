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
        Task AssignHardware(int? userId, int? departmentId); 
        Task<IEnumerable<Hardware>> GetHardwareByType(int hardwareTypeId);
        Task<IEnumerable<Hardware>> GetHardwareByOperation(bool? operational);
        Task<IEnumerable<Hardware>> GetHardwareByAssignment(bool? assigned=false, bool? operational=true);
        Task<IEnumerable<Hardware>> GetUnassignedAndOperationalHardware();
        Task<IEnumerable<Hardware>> GetUserAssets(int userId);
        Task<IEnumerable<Hardware>> GetDepartmentAssets( int departmentId);
        /*int? siteId,*/
        
        //Task<IEnumerable<Hardware>> GetSiteAssets(int siteId);
    }
}
