

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.NetworkPortInfoEntities;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Commands
{
    public class DeleteNetworkPortInformationRequestHandler : GenericDeleteRequestHandler<INetworkPortInformationRepository, INetworkPortInformationRepository, NetworkPortInformation>
    {
        public DeleteNetworkPortInformationRequestHandler(INetworkPortInformationRepository genericUnitOfWork, IMapper mapper, 
            INetworkPortInformationRepository repository) 
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
