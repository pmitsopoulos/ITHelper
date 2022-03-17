

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Queries
{
    public class GetIssueBySearchTermRequestHandler : GenericGetBySearchTermRequestHandler<IIssueRepository, IssueDto, Issue>
    {
        public GetIssueBySearchTermRequestHandler(IIssueRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
