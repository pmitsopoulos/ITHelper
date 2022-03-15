using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Commands
{
    public class DeleteIssueRequestHandler : IRequestHandler<DeleteIssueRequest, BaseResponse>
    {
        private readonly IIssueUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteIssueRequestHandler( IIssueUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteIssueRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var issueTBDExists = await unitOfWork.IssuesRepository.Exists(request.Id);

            if(!issueTBDExists)
            {
                response.Message = "Issue could not be deleted";
                response.Success = false;
                response.Errors.Add(new NotFoundException(nameof(Issue), request.Id).Message);
                return response;
            }
            else
            {
                try
                {
                    await unitOfWork.IssuesRepository.DeleteAsync(request.Id);
                    await unitOfWork.Save();
                    response.Message = "Issue was deleted successfully";
                    response.Success = true;
                }
                catch (Exception ex)
                {
                    response.Message = "Issue could not be deleted";
                    response.Success = false;
                    response.Errors.Add(ex.Message);
                }
            }
            return response;
        }
    }
}
