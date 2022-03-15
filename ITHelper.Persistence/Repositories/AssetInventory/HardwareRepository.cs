using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Models.FilterModels.AssetInventoryFilterModels;
using ITHelper.Domain.AssetInventoryEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.AssetInventory
{
    public class HardwareRepository : GenericRepository<Hardware>, IHardwareRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public HardwareRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<Hardware>> FilteredSearch(HardwareFilterModel filterModel)
        {
            var result = await applicationDbContext.Hardware
                .Where(h => filterModel.HardwareTypeId != default ? h.HardwareTypeId == filterModel.HardwareTypeId : h.HardwareTypeId != default)
                .Where(h => filterModel.UserId != default ? h.UserId == filterModel.UserId : h.UserId != default)
                .Where(h => filterModel.DepartmentId != default ? h.DepartmentId == filterModel.DepartmentId : h.DepartmentId != default)
                .Where(h => h.IsOperational == filterModel.IsOperational)
                .Where(h => filterModel.IsAssigned ? h.DateAssigned != default : (h.DateAssigned == default))
                .ToListAsync();
      
            return result;
        }
    }
}
