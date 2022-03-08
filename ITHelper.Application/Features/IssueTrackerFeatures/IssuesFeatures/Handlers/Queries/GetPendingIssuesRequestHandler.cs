using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Handlers.Queries
{
    public class GetPendingIssuesRequestHandler : IRequestHandler<GetPendingIssuesRequest, List<IssueDto>>
    {
        private readonly IIssueRepository issueRepository;
        private readonly IMapper mapper;

        public GetPendingIssuesRequestHandler(IIssueRepository issueRepository
            ,IMapper mapper)
        {
            this.issueRepository = issueRepository;
            this.mapper = mapper;
        }
        public async Task<List<IssueDto>> Handle(GetPendingIssuesRequest request, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.GetExpiredAndPendingIssues();

            if(issues == null)
            {
                throw new NotFoundException(nameof(IssueDto), "");
            }
            return mapper.Map<List<IssueDto>>(issues);
        }
    }
}
