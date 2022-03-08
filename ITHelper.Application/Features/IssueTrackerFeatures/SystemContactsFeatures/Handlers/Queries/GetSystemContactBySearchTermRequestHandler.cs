using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Requests.Queries;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Queries
{
    public class GetSystemContactBySearchTermRequestHandler : IRequestHandler<GetSystemContactBySearchTermRequest, List<SystemContactDto>>
    {
        private readonly ISystemContactRepository systemContactRepository;
        private readonly IMapper mapper;

        public GetSystemContactBySearchTermRequestHandler(ISystemContactRepository systemContactRepository, IMapper mapper)
        {
            this.systemContactRepository = systemContactRepository;
            this.mapper = mapper;
        }

        public async Task<List<SystemContactDto>> Handle(GetSystemContactBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var sysContacts = await systemContactRepository.GetBySearchTermAsync(request.SearchTerm);

            if(sysContacts == null)
            {
                throw new NotFoundException(nameof(SystemContact), request.SearchTerm);
            }
            else
            {
                return mapper.Map<List<SystemContactDto>>(sysContacts);
            }
        }
    }
}
