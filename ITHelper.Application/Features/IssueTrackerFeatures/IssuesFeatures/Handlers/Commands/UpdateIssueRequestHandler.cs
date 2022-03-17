

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.IssueTrackerEntities;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Commands
{
    public class UpdateIssueRequestHandler 
        : GenericUpdateRequestHandler<IIssueUnitOfWork, IIssueRepository, UpdateIssueDto, Issue, UpdateIssueDtoValidator>
    {
        public UpdateIssueRequestHandler(IIssueUnitOfWork unitOfWork, IMapper mapper,
            IIssueRepository repository, UpdateIssueDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
