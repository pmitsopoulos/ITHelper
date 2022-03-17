

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Queries
{
    public class GetApplicationSystemRequestHandler : GenericGetByIdRequestHandler<IApplicationSystemRepository, ApplicationSystemDto, ApplicationSystem>
    {
        public GetApplicationSystemRequestHandler(IApplicationSystemRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
