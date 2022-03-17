
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Commands
{
    public class DeleteIssueRequestHandler : GenericDeleteRequestHandler<IIssueUnitOfWork, IIssueRepository, Issue>
    {
        public DeleteIssueRequestHandler(IIssueUnitOfWork genericUnitOfWork, IMapper mapper, IIssueRepository repository) 
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
