using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs.Validators;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Commands
{
    public class UpdateNetworkPortInformationRequestHandler : IRequestHandler<UpdateNetworkPortInformationRequest, BaseResponse>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;
        private readonly IMapper mapper;

        public UpdateNetworkPortInformationRequestHandler(INetworkPortInformationRepository networkPortInformationRepository, IMapper mapper)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateNetworkPortInformationRequest request, CancellationToken cancellationToken)
        {
            var networkPortTBU = await networkPortInformationRepository.GetByIdAsync(request.Id);


            if (networkPortTBU == null)
            {
                throw new NotFoundException(nameof(networkPortTBU), request.Id);
            }
            
            var response = new BaseResponse();
            
            if(request.NetworkPortInformationDto != null)
            {
                var validator = new UpdateNetworkPortInformationDtoValidator(networkPortInformationRepository);

                var validationResult = await validator.ValidateAsync(request.NetworkPortInformationDto);


                if(!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult);
                }

                mapper.Map(request.NetworkPortInformationDto, networkPortTBU);

                try
                {
                    await networkPortInformationRepository.UpdateAsync(networkPortTBU);
                    await networkPortInformationRepository.Save();
                    response.Success = true;
                    response.Message = "The Network Port Information was updated successfully";
                    response.Id = request.Id;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "There was a problem during the attempt to update the Network Port Information";
                    response.Errors.Add (ex.Message);
                }
            }
            
            return response;
        }
    }
}
