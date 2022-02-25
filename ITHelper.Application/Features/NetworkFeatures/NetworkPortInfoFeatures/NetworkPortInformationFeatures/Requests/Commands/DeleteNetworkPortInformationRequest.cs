using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures.NetworkPortInfoFeatures.NetworkPortInformationFeatures.Requests.Commands
{
    public class DeleteNetworkPortInformationRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
