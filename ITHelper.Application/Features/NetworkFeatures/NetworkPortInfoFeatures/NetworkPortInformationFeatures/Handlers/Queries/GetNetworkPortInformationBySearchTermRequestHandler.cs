

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.NetworkPortInfoEntities;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Queries
{
    public class GetNetworkPortInformationBySearchTermRequestHandler
        : GenericGetBySearchTermRequestHandler<INetworkPortInformationRepository, NetworkPortInformationDto, NetworkPortInformation>
    {
        public GetNetworkPortInformationBySearchTermRequestHandler(INetworkPortInformationRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
