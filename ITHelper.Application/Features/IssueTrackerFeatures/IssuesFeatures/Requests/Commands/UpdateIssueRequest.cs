using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Commands
{
    public class UpdateIssueRequest : IRequest<BaseResponse>
    { 
        public UpdateIssueDto  IssueDto { get; set; }
    }
}