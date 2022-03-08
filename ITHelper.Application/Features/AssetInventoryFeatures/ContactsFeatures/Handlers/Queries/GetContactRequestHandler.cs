using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.ContactsFeatures.Handlers.Queries
{
    public class GetContactRequestHandler : IRequestHandler<GetContactRequest, ContactDto>
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public GetContactRequestHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<ContactDto> Handle(GetContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await contactRepository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }
            return mapper.Map<ContactDto>(contact);
        }
    }
}
