using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators;
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
    public class CreateIssueRequestHandler : IRequestHandler<CreateIssueRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateIssueRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateIssueRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new CreateIssueDtoValidator(unitOfWork.IssuesRepository);
            var validationResult = await validator.ValidateAsync(request.IssueDto);

            if(!validationResult.IsValid)
            {
                response.Message = "Issue creation failed.";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var issueTBC = mapper.Map<Issue>(request.IssueDto);
                
                await unitOfWork.IssuesRepository.CreateAsync(issueTBC);
                await unitOfWork.Save();
                
                response.Message = "Issue creation was successful";
                response.Success = true;
            }

            return response;
        }
    }
}
