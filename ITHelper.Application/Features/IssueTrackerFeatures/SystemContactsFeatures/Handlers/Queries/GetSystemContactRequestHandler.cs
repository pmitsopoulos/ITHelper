using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Queries
{
    public class GetSystemContactRequestHandler : IRequestHandler<GetSystemContactRequest, SystemContactDto>
    {
        private readonly ISystemContactRepository systemContactRepository;
        private readonly IMapper mapper;

        public GetSystemContactRequestHandler(ISystemContactRepository systemContactRepository, IMapper mapper)
        {
            this.systemContactRepository = systemContactRepository;
            this.mapper = mapper;
        }
        public async Task<SystemContactDto> Handle(GetSystemContactRequest request, CancellationToken cancellationToken)
        {
            var sysContact = await systemContactRepository.GetByIdAsync(request.Id);

            if(sysContact == null)
            {
                throw new NotFoundException(nameof(SystemContactDto),request.Id);
            }
            else
            {
                return mapper.Map<SystemContactDto>(sysContact);
            }
        }
    }
}
