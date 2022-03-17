
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.NetworkPortInfoEntities;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Handlers.Commands
{
    public class CreateNetworkPortInformationRequestHandler
        : GenericCreateRequestHandler<INetworkPortInformationRepository, CreateNetworkPortInformationDto, NetworkPortInformation, INetworkPortInformationRepository, CreateNetworkPortInformationDtoValidator>
    {
        public CreateNetworkPortInformationRequestHandler(INetworkPortInformationRepository unitOfWork, IMapper mapper,
            INetworkPortInformationRepository repository, CreateNetworkPortInformationDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
