using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Commands
{
    public class CreateSystemContactRequest : IRequest<BaseResponse>
    {
        public CreateSystemContactDto SystemContactDto { get; set; }
    }
}
