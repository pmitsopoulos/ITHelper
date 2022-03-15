using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.AssetInventory
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DepartmentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
