

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Queries
{
    public class GetApplicationSystemBySearchTermRequestHandler : GenericGetBySearchTermRequestHandler<IApplicationSystemRepository, ApplicationSystemDto, ApplicationSystem>
    {
        public GetApplicationSystemBySearchTermRequestHandler(IApplicationSystemRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
