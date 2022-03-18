using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Queries;
using ITHelper.Application.Models.FilterModels.AssetInventoryFilterModels;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Commands;

namespace ITHelper.Api.Controllers.AssetInventoryControllers
{
    [Route("api/AssetInventory/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        private readonly IMediator mediator;

        public HardwareController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllHardware")]
        public async Task<ActionResult<List<HardwareDto>>> Get()
        {
            var query = new GenericGetAllRequest<HardwareDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<HardwareDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllHardware");
            }

            var query = new GenericGetBySearchTermRequest<HardwareDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<HardwareDto>>> Get([FromBody] HardwareFilterModel? filter)
        {
            if (filter == null)
            {
                return RedirectToAction("GetAllHardware");
            }

            var query = new GetHardwareByFilteredSearchRequest() { HardwareFilter = filter };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<HardwareDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<HardwareDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateHardwareDto hardware)
        {
            var command = new GenericCreateRequest<CreateHardwareDto> { EntityTBC = hardware };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateHardwareDto hardware)
        {
            var command = new GenericUpdateRequest<UpdateHardwareDto> { EntityTBU = hardware };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpPatch("assign/{id}")]

        public async Task<ActionResult<BaseResponse>> Patch([FromBody]AssignHardwareDto hardwareDto,int? id)
        {
            
            var command = new AssignHardwareRequest() { HardwareDto = hardwareDto };
            id = hardwareDto.Id;
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<Hardware> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
