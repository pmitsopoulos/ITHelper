using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Queries
{
    public class GetContactsBySearchTermRequestHandler : IRequestHandler<GetContactsBySearchTermRequest, List<ContactDto>>
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public GetContactsBySearchTermRequestHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<List<ContactDto>> Handle(GetContactsBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var contacts = await contactRepository.GetBySearchTermAsync(request.SearchTerm);
            if (contacts is null)
            {
                throw new NotFoundException(nameof(Contact), request.SearchTerm);
            }
            return mapper.Map<List<ContactDto>>(contacts);
        }
    }
}
