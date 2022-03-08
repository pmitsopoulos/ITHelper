using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Queries
{
    public class GetContactRequest : IRequest<ContactDto>
    {
        public int Id { get; set; }

    }
}
