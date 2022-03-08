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
    public class GetIssueBySearchTermRequestHandler : IRequestHandler<GetIssueBySearchTermRequest, List<IssueDto>>
    {
        private readonly IIssueRepository issueRepository;
        private readonly IMapper mapper;

        public GetIssueBySearchTermRequestHandler(IIssueRepository issueRepository, IMapper mapper)
        {
            this.issueRepository = issueRepository;
            this.mapper = mapper;
        }
        public async Task<List<IssueDto>> Handle(GetIssueBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.GetBySearchTermAsync(request.SearchTerm);

            if(issues==null)
            {
                throw new NotFoundException(nameof(IssueDto), request.SearchTerm);
            }
            return mapper.Map<List<IssueDto>>(issues);
        }
    }
}
