using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators;
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
    public class CreateSystemContactRequestHandler : IRequestHandler<CreateSystemContactRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateSystemContactRequestHandler(IUnitOfWork unitOfWork
             ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateSystemContactRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateSystemContactDtoValidator(unitOfWork.SystemContactRepository);

            var validationResult = await validator.ValidateAsync(request.SystemContactDto);

            if(!validationResult.IsValid)
            {
                response.Message = "System Contact creation failed.";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var systemContactTBC = mapper.Map<SystemContact>(request.SystemContactDto);
                await unitOfWork.SystemContactRepository.CreateAsync(systemContactTBC);
                await unitOfWork.Save();
                response.Message = "System Contact created successfully";
                response.Success=true;
            }


            return response;
        }
    }
}
