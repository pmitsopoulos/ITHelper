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
    public class UpdateContactRequest : IRequest<BaseResponse>
    {
        public UpdateContactDto ContactDto { get; set; }
    }
}
