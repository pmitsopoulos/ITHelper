using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.AssetInventory
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
