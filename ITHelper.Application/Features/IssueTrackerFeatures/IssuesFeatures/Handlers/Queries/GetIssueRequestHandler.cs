using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class GetIssueRequestHandler : IRequestHandler<GetIssueRequest, IssueDto>
    {
        private readonly IIssueRepository issueRepository;
        private readonly IMapper mapper;

        public GetIssueRequestHandler(IIssueRepository issueRepository , IMapper mapper)
        {
            this.issueRepository = issueRepository;
            this.mapper = mapper;
        }
        public async Task<IssueDto> Handle(GetIssueRequest request, CancellationToken cancellationToken)
        {
            var issue = await issueRepository.GetByIdAsync(request.Id); 

            if(issue == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            return mapper.Map<IssueDto>(issue);
        }
    }
}
