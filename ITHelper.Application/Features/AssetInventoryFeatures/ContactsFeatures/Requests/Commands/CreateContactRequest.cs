using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Commands
{
    public class CreateContactRequest : IRequest<BaseResponse>
    {
        public CreateContactDto ContactDto { get; set; }
    }
}
