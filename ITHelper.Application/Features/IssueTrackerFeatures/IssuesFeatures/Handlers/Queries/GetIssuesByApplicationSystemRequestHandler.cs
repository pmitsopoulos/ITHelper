using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Queries;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Queries
{
    public class GetIssuesByApplicationSystemRequestHandler : IRequestHandler<GetIssuesByApplicationSystemRequest, List<IssueDto>>
    {
        private readonly IIssueRepository issueRepository;
        private readonly IMapper mapper;

        public GetIssuesByApplicationSystemRequestHandler(IIssueRepository issueRepository, IMapper mapper)
        {
            this.issueRepository = issueRepository;
            this.mapper = mapper;
        }
        public async Task<List<IssueDto>> Handle(GetIssuesByApplicationSystemRequest request, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.GetIssuesByApplicationSystem(request.ApplicationSystemId);

            if(issues == null)
            {
                throw new NotFoundException(nameof(Issue), request.ApplicationSystemId);
            }
            return mapper.Map<List<IssueDto>>(issues);
        }
    }
}
