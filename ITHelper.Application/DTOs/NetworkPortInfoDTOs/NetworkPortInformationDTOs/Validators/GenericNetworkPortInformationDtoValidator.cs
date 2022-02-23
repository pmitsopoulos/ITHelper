using FluentValidation;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs.Validators
{
    public class GenericNetworkPortInformationDtoValidator : AbstractValidator<INetworkPortInformationDto>
    {
        private readonly INetworkPortInformationRepository networkPortInformationRepository;

        public GenericNetworkPortInformationDtoValidator(INetworkPortInformationRepository networkPortInformationRepository)
        {
            this.networkPortInformationRepository = networkPortInformationRepository;
            RuleFor(p => p.PortNumber).NotNull().NotEmpty().WithMessage("The port number is required.");
            RuleFor(p => p.Protocol).NotNull().NotEmpty().WithMessage("The port number is required.");
            RuleFor(p => p.UseDescription).NotNull().NotEmpty().WithMessage("The port number is required.");
        }
    }
}
