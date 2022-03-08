using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators;
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
    public class UpdateSystemContactRequestHandler : IRequestHandler<UpdateSystemContactRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateSystemContactRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateSystemContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();


            var sysContactExists = await unitOfWork.SystemContactRepository.Exists(request.SystemContactDto.Id);


            if (!sysContactExists)
            {
                response.Message = "Application System was not found.";
                response.Errors.Add(new NotFoundException(nameof(Application), request.SystemContactDto.Id).Message);
            }
            else
            {
                var validator = new UpdateSystemContactDtoValidator(unitOfWork.SystemContactRepository);

                var validationResult = await validator.ValidateAsync(request.SystemContactDto);

                if (!validationResult.IsValid)
                {
                    response.Message = "The Model is not valid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    try
                    {
                        var sysContactTBU = mapper.Map<SystemContact>(request.SystemContactDto);
                        await unitOfWork.SystemContactRepository.UpdateAsync(sysContactTBU);
                        await unitOfWork.Save();

                        response.Message = "The System Contact was updated successfully.";
                        response.Success=true;
                        response.Id = sysContactTBU.Id;   
                    }
                    catch (Exception ex)
                    {
                        response.Success = false;
                        response.Message = "The update on the System Contact failed.";
                        response.Errors.Add(ex.Message);
                    }
                }
                
            }
            return response;
        }
    }
}
