

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Commands
{
    public class CreateApplicationSystemRequestHandler : GenericCreateRequestHandler<IIssueUnitOfWork, CreateApplicationSystemDto, ApplicationSystem, IApplicationSystemRepository, CreateApplicationSystemDtoValidator>
    {
        public CreateApplicationSystemRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper,
            IApplicationSystemRepository repository, CreateApplicationSystemDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
