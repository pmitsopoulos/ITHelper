using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.NetworkPortInfoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Queries
{
    public class GetAllNetworkPortInformationRequestHandler : GenericGetAllRequestHandler<INetworkPortInformationRepository, NetworkPortInformationDto, NetworkPortInformation>
    {
        public GetAllNetworkPortInformationRequestHandler(INetworkPortInformationRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
