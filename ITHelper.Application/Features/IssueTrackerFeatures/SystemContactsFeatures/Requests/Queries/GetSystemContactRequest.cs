using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Queries
{
    public class GetSystemContactRequest  : IRequest<SystemContactDto>
    {
        public int Id { get; set; }
    }
}
