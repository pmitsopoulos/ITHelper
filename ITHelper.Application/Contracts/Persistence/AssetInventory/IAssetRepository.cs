using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.AssetInventory
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        Task <IEnumerable<Asset>> GetUserAssets(int userId);
        Task<IEnumerable<Asset>> GetSiteAssets(int siteId);
        Task<IEnumerable <Asset>> GetDepartmentAssets(int? siteId, int departmentId);
    }
}
