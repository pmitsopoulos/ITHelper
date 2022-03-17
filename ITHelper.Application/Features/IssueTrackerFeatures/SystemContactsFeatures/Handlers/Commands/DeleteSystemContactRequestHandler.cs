

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Commands
{
    public class DeleteSystemContactRequestHandler : GenericDeleteRequestHandler<IIssueUnitOfWork, ISystemContactRepository, SystemContact>
    {
        public DeleteSystemContactRequestHandler(IIssueUnitOfWork genericUnitOfWork, IMapper mapper, ISystemContactRepository repository) 
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
