using ITHelper.Domain.NetworkPortInfoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.NetworkPortInfo
{
    public interface INetworkPortInformationRepository : IGenericRepository<NetworkPortInformation>
    {
        Task Save();
    }
}
