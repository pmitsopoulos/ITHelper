using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Commands
{
    public class CreateNetworkPortInformationRequest : IRequest<BaseResponse>
    {
        public CreateNetworkPortInformationDto NetworkPortInformationDto { get; set; }
    }
}
