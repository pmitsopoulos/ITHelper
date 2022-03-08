using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Queries
{
    public class GetContactsBySearchTermRequest : IRequest<List<ContactDto>>
    {
        public string SearchTerm { get; set; }
    }
}
