
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Commands
{
    public class DeleteApplicationSystemRequestHandler : GenericDeleteRequestHandler<IIssueUnitOfWork, IApplicationSystemRepository, ApplicationSystem>
    {
        public DeleteApplicationSystemRequestHandler(IIssueUnitOfWork genericUnitOfWork, IMapper mapper, IApplicationSystemRepository repository) 
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
