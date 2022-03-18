using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using ITHelper.Domain.NetworkPortInfoEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.Network
{
    [Route("api/NetworkTools/[controller]")]
    [ApiController]
    public class NetworkPortsInformationController : ControllerBase
    {
        private readonly IMediator mediator;

        public NetworkPortsInformationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllPorts")]
        public async Task<ActionResult<List<NetworkPortInformationDto>>> Get()
        {
            var query = new GenericGetAllRequest<NetworkPortInformationDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<NetworkPortInformationDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllPorts");
            }

            var query = new GenericGetBySearchTermRequest<NetworkPortInformationDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<NetworkPortInformationDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<NetworkPortInformationDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateNetworkPortInformationDto networkPortInformation)
        {
            var command = new GenericCreateRequest<CreateNetworkPortInformationDto> { EntityTBC = networkPortInformation };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateNetworkPortInformationDto networkPortInformation)
        {
            var command = new GenericUpdateRequest<UpdateNetworkPortInformationDto> { EntityTBU = networkPortInformation };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<NetworkPortInformation> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
