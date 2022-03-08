using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators;
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
    public class UpdateIssueRequestHandler : IRequestHandler<UpdateIssueRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateIssueRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)  
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateIssueRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var issueTBUExists = await unitOfWork.IssuesRepository.Exists(request.IssueDto.Id);

            if(!issueTBUExists)
            {
                response.Errors.Add(new NotFoundException(nameof(Issue), request.IssueDto.Id).Message);
                response.Message = "The selected Issue was not found";
                response.Success = false;
            }
            else
            {
                var validator = new UpdateIssueDtoValidator(unitOfWork.IssuesRepository);

                var validationResult = await validator.ValidateAsync(request.IssueDto);

                if(validationResult.IsValid)
                {
                    var issueTBU = await unitOfWork.IssuesRepository.GetByIdAsync(request.IssueDto.Id);

                    mapper.Map(request.IssueDto, issueTBU);

                    await unitOfWork.IssuesRepository.UpdateAsync(issueTBU);
                    await unitOfWork.Save();

                    response.Success = true;
                    response.Message = "Issue updated successfully.";
                    response.Id = issueTBU.Id;

                }
                else
                {
                    response.Message = "Issue could not be updated.";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }

            }

            return response;
        }
    }
}
