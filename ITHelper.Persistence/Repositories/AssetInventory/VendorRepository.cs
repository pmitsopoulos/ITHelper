using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.AssetInventory
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public VendorRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
