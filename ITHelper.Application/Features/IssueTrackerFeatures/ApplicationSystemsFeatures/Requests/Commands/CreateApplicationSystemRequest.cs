using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Requests.Commands
{
    public class CreateApplicationSystemRequest : IRequest<BaseResponse>
    {
        public CreateApplicationSystemDto ApplicationSystemDto { get; set; }
    }
}
