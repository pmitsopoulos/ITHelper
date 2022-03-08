using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Queries
{
    public class GetSystemContactBySearchTermRequest : IRequest<List<SystemContactDto>>
    {
        public string SearchTerm { get; set; }
    }
}
