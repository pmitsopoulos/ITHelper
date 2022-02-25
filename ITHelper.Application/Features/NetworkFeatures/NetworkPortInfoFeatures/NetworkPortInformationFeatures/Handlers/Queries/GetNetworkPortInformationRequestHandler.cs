
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
    public class GetNetworkPortInformationRequestHandler : IRequestHandler<GetNetworkPortInformationRequest, NetworkPortInformationDto>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;
        private readonly IMapper mapper;

        public GetNetworkPortInformationRequestHandler(INetworkPortInformationRepository networkPortInformationRepository ,IMapper mapper)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            this.mapper = mapper;
        }

        public async Task<NetworkPortInformationDto> Handle(GetNetworkPortInformationRequest request, CancellationToken cancellationToken)
        {
            var networkPortInfo = await networkPortInformationRepository.GetByIdAsync(request.Id);
            if (networkPortInfo == null)
            {
                throw new NotFoundException(nameof(NetworkPortInformation),request);
            }
            else
            {
                return mapper.Map<NetworkPortInformationDto>(networkPortInfo);
            }
        }
    }
}
