using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators;
using ITHelper.Application.Exceptions;
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
    public class UpdateApplicationSystemRequestHandler : IRequestHandler<UpdateApplicationSystemRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateApplicationSystemRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateApplicationSystemRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();


            var appSystemExists = await unitOfWork.ApplicationSystemRepository.Exists(request.ApplicationSystemDto.Id);

            if(!appSystemExists)
            {
                response.Message = "Application System was not found.";
                response.Errors.Add(new NotFoundException(nameof(Application), request.ApplicationSystemDto.Id).Message);
            }
            else
            {
                var validator = new UpdateApplicationSystemDtoValidator(unitOfWork.ApplicationSystemRepository);

                var validationResult = await validator.ValidateAsync(request.ApplicationSystemDto);

                if(!validationResult.IsValid)
                {
                    response.Message = "Application System update request failed.";
                    response.Errors = validationResult.Errors
                        .Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var appSystemTBU = await unitOfWork.ApplicationSystemRepository.GetByIdAsync(request.ApplicationSystemDto.Id);

                    mapper.Map(request.ApplicationSystemDto, appSystemTBU);

                    await unitOfWork.ApplicationSystemRepository.UpdateAsync(appSystemTBU);
                    await unitOfWork.Save();

                    response.Success = true;
                    response.Id = appSystemTBU.Id;
                    response.Message = "Application System was updated successfully";
                }
                
            }
            return response;

        }
    }
}
