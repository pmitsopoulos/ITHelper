using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Commands
{
    public class DeleteSystemContactRequestHandler : IRequestHandler<DeleteSystemContactRequest, BaseResponse>
    {
        private readonly IIssueUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteSystemContactRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteSystemContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var systemContactTBDExists = await unitOfWork.SystemContactRepository.Exists(request.Id);

            if(!systemContactTBDExists)
            {
                //throw new NotFoundException(nameof(SystemContact),request.Id);
                response.Message = "The system contact could not be deleted";
                response.Success = false;
            }
            else
            {
                try
                {
                    await unitOfWork.SystemContactRepository.DeleteAsync(request.Id);
                    await unitOfWork.Save();
                    response.Message = "The System Contact deleted successfully";
                    response.Success= true;

                }
                catch (Exception ex)
                {
                    response.Message = "The system contact could not be deleted";
                    response.Errors.Add(ex.Message);
                    response.Success = false;
                }
            }
            return response;
        }
    }
}
