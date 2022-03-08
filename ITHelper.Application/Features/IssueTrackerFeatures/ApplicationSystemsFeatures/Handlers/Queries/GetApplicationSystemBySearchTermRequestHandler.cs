using AutoMapper;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Requests.Queries;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.IssueTrackerFeatures.ApplicationSystemsFeatures.Handlers.Queries
{
    public class GetApplicationSystemBySearchTermRequestHandler : IRequestHandler<GetApplicationSystemBySearchTermRequest, List<ApplicationSystemDto>>
    {
        private readonly IApplicationSystemRepository applicationSystemRepository;
        private readonly IMapper mapper;

        public GetApplicationSystemBySearchTermRequestHandler(IApplicationSystemRepository applicationSystemRepository
             ,IMapper mapper)
        {
            this.applicationSystemRepository = applicationSystemRepository;
            this.mapper = mapper;
        }
        public async Task<List<ApplicationSystemDto>> Handle(GetApplicationSystemBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var appSystems = await applicationSystemRepository.GetBySearchTermAsync(request.SearchTerm);

            if(appSystems==null)
            {
                throw new NotFoundException(nameof(ApplicationSystem), request.SearchTerm);
            }
            else
            {
                return  mapper.Map<List<ApplicationSystemDto>>(appSystems);
            }
           
        }
    }
}
