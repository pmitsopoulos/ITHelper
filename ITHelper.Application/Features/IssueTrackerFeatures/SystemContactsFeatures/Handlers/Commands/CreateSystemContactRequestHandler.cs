
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Commands
{
    public class CreateSystemContactRequestHandler : GenericCreateRequestHandler<IIssueUnitOfWork, CreateSystemContactDto, SystemContact, ISystemContactRepository, CreateSystemContactDtoValidator>
    {
        public CreateSystemContactRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper,
            ISystemContactRepository repository, CreateSystemContactDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
