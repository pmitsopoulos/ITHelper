
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Commands
{
    public class UpdateSystemContactRequestHandler
        : GenericUpdateRequestHandler<IIssueUnitOfWork, ISystemContactRepository, UpdateSystemContactDto, SystemContact, UpdateSystemContactDtoValidator>
    {
        public UpdateSystemContactRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper, 
            ISystemContactRepository repository, UpdateSystemContactDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
