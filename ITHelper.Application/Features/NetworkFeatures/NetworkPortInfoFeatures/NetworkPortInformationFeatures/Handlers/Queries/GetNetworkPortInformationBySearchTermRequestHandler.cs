using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Queries;
using ITHelper.Domain.NetworkPortInfoEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Queries
{
    public class GetNetworkPortInformationBySearchTermRequestHandler 
        : IRequestHandler<GetNetworkPortInformationBySearchTermRequest, List<NetworkPortInformationDto>>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;
        private readonly IMapper mapper;

        public GetNetworkPortInformationBySearchTermRequestHandler
            (INetworkPortInformationRepository networkPortInformationRepository, IMapper mapper)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            this.mapper = mapper;
        }
        public async Task<List<NetworkPortInformationDto>> Handle(GetNetworkPortInformationBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var netoworkPortInfo = await networkPortInformationRepository
                .GetBySearchTermAsync(request.SearchTerm);

            if(netoworkPortInfo == null)
            {
                throw new NotFoundException(nameof(NetworkPortInformation),request.SearchTerm);
            }
            else 
            {
                return mapper.Map<List<NetworkPortInformationDto>>(netoworkPortInfo);
            }
        }
    }
}
