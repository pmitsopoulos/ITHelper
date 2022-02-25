using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs.Validators;

using ITHelper.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using ITHelper.Domain.NetworkPortInfoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Commands;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Commands
{
    public class CreateNetworkPortInformationRequestHandler : IRequestHandler<CreateNetworkPortInformationRequest, BaseResponse>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateNetworkPortInformationRequestHandler(
            INetworkPortInformationRepository networkPortInformationRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        async Task<BaseResponse> IRequestHandler<CreateNetworkPortInformationRequest, BaseResponse>.Handle(CreateNetworkPortInformationRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new CreateNetworkPortInformationDtoValidator(networkPortInformationRepository);
            var validationResult = await validator.ValidateAsync(request.NetworkPortInformationDto);
            
            if(!validationResult.IsValid)
            {
                response.Message = "Network Port Creation Request failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var networkPortInfoTBC = mapper.Map<NetworkPortInformation>(request.NetworkPortInformationDto);
                await networkPortInformationRepository.CreateAsync(networkPortInfoTBC);
                await networkPortInformationRepository.Save();

                response.Message = "Network Port Created Succesfully";
                response.Success = true;
                response.Id = networkPortInfoTBC.Id;
            }
            //TODO Add user Authentication and Authorization in order
            //to request another Function or Endpoint
            //var userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
            //        q => q.Type == CustomClaimTypes.Uid)?.Value;
            return response;
        }
    }
}
