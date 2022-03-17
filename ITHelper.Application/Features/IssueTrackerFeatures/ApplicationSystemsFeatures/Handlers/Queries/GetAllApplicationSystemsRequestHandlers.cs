using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Queries
{
    public class GetAllApplicationSystemsRequestHandlers : GenericGetAllRequestHandler<IApplicationSystemRepository, ApplicationSystemDto, ApplicationSystem>
    {
        public GetAllApplicationSystemsRequestHandlers(IApplicationSystemRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
