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
    public class GetApplicationSystemRequestHandler : IRequestHandler<GetApplicationSystemRequest, ApplicationSystemDto>
    {
        private readonly IApplicationSystemRepository applicationSystemRepository;
        private readonly IMapper mapper;

        public GetApplicationSystemRequestHandler(IApplicationSystemRepository applicationSystemRepository, IMapper mapper)
        {
            this.applicationSystemRepository = applicationSystemRepository;
            this.mapper = mapper;
        }
        public async Task<ApplicationSystemDto> Handle(GetApplicationSystemRequest request, CancellationToken cancellationToken)
        {
            var appSystem = await applicationSystemRepository.GetByIdAsync(request.Id);

            if(appSystem == null)
            {
                throw new NotFoundException(nameof(ApplicationSystem), request.Id);
            }
            else
            {
                return mapper.Map<ApplicationSystemDto>(appSystem);
            }
        }
    }
}
