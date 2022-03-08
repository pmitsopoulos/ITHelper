using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
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
    public class DeleteNetworkPortInformationRequestHandler : IRequestHandler<DeleteNetworkPortInformationRequest, BaseResponse>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;
       

        public DeleteNetworkPortInformationRequestHandler(INetworkPortInformationRepository networkPortInformationRepository)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
           
        }
        public async Task<BaseResponse> Handle(DeleteNetworkPortInformationRequest request, CancellationToken cancellationToken)
        {
            var tbdItemExists = await networkPortInformationRepository.Exists(request.Id);
            var response = new BaseResponse();
            if(!tbdItemExists)
            {
                response.Success = false;
                response.Message = "The deletion was unsuccessful, no Network Port with the given Id was found in the the database.";
            }
            else
            {
                try
                {
                    await networkPortInformationRepository.DeleteAsync(request.Id);
                    await networkPortInformationRepository.Save();
                    response.Success = true;
                    response.Message = "The specified network port was deleted successfully";
                }
                catch (Exception ex)
                {
                    response.Success=false;
                    response.Errors.Add(ex.Message);
                    response.Message = "There was a problem during the deletion of the Network Port.";
                }
            }
            return response;
        }
    }
}
