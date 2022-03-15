using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Domain.NetworkPortInfoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.NetworkPortInfo
{
    public class NetworkPortInformationRepository : GenericRepository<NetworkPortInformation>, INetworkPortInformationRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public NetworkPortInformationRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task Save()
        {
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
