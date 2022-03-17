using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.SystemContactsFeatures.Handlers.Queries
{
    public class GetAllSystemContactsRequestHandler : GenericGetAllRequestHandler<ISystemContactRepository, SystemContactDto, SystemContact>
    {
        public GetAllSystemContactsRequestHandler(ISystemContactRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
