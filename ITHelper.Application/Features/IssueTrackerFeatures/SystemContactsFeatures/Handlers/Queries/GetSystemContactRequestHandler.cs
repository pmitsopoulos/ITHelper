
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Queries
{
    public class GetSystemContactRequestHandler : GenericGetByIdRequestHandler<ISystemContactRepository, SystemContactDto, SystemContact>
    {
        public GetSystemContactRequestHandler(ISystemContactRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
