using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators;
using ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Commands
{
    public class CreateApplicationSystemRequestHandler : IRequestHandler<CreateApplicationSystemRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateApplicationSystemRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateApplicationSystemRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateApplicationSystemDtoValidator(unitOfWork.ApplicationSystemRepository);

            var validationResult = await validator.ValidateAsync(request.ApplicationSystemDto);

            if(!validationResult.IsValid)
            {
                response.Message = "Application System creation request failed.";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var appSystemTBC = mapper.Map<ApplicationSystem>(request.ApplicationSystemDto);

                await unitOfWork.ApplicationSystemRepository.CreateAsync(appSystemTBC);
                await unitOfWork.Save();

                response.Message = "Application System Created Successfully";
                response.Success=true;
                response.Id = appSystemTBC.Id;
            }

            return response;
        }
    }
}
