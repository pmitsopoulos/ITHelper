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
    public class UpdateNetworkPortInformationRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateNetworkPortInformationDto NetworkPortInformationDto { get; set; }
    }
}
