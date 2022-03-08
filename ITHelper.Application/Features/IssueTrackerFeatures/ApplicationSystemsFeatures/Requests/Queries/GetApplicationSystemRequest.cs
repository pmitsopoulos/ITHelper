using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Requests.Queries
{
    public class GetApplicationSystemRequest : IRequest<ApplicationSystemDto>
    {
        public int Id { get; set; }
    }
}
