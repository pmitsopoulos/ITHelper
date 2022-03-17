
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Commands
{
    public class UpdateApplicationSystemRequestHandler 
        : GenericUpdateRequestHandler<IIssueUnitOfWork, IApplicationSystemRepository, UpdateApplicationSystemDto, ApplicationSystem, UpdateApplicationSystemDtoValidator>
    {
        public UpdateApplicationSystemRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper, 
            IApplicationSystemRepository repository, UpdateApplicationSystemDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
