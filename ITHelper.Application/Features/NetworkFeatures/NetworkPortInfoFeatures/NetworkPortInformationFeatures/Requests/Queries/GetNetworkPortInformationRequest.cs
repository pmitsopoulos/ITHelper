using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Queries
{
    public class GetNetworkPortInformationRequest : IRequest<NetworkPortInformationDto>
    {
        public int Id { get; set; }
    }
}
