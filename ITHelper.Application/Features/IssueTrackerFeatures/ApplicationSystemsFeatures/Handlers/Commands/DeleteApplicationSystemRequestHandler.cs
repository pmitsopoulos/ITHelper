using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators;
using ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Commands
{
    public class DeleteApplicationSystemRequestHandler : IRequestHandler<DeleteApplicationSystemRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteApplicationSystemRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteApplicationSystemRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var tbdItemExists = await unitOfWork.ApplicationSystemRepository.Exists(request.Id);

            if(!tbdItemExists)
            {
                response.Success = false;
                response.Message = "The deletion was unsuccessful, no Application System with the given Id was found in the the database.";
            }
            else
            {
                try
                {
                    await unitOfWork.ApplicationSystemRepository.DeleteAsync(request.Id);
                    await unitOfWork.Save();
                    response.Success = true;
                    response.Message = "The specified Application System was deleted successfully.";
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Errors.Add(ex.Message);
                    response.Message = "There was a problem during the deletion of the Application System.";
                }
            }

            return response;
        }
    }
}
