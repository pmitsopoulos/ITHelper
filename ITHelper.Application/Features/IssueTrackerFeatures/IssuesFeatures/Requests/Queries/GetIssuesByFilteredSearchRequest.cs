using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Models.FilterModels.IssueTrackerFilterModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Queries
{
    public class GetIssuesByFilteredSearchRequest : IRequest<List<IssueDto>>
    {
        public IssueFilterModel IssueFilter { get; set; }
    }
}
