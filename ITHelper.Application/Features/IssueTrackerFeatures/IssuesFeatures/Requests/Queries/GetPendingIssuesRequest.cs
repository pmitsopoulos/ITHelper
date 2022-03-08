using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Queries
{
    public class GetPendingIssuesRequest : IRequest<List<IssueDto>>
    {
       
    }
}
