using ITHelper.Application.Models.FilterModels.AssetInventoryFilterModels;
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
        Task<IEnumerable<Hardware>> FilteredSearch(HardwareFilterModel filterModel);
    }
}
