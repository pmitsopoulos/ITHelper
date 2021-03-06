using FluentValidation;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs.Validators
{
    public class UpdateNetworkPortInformationDtoValidator : AbstractValidator<UpdateNetworkPortInformationDto>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;

        public UpdateNetworkPortInformationDtoValidator(INetworkPortInformationRepository networkPortInformationRepository)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            Include(new GenericNetworkPortInformationDtoValidator(this.networkPortInformationRepository));
        }
    }
}
