using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.AssetInventoryControllers
{
    [Route("api/AssetInventory/[controller]")]
    [ApiController]
    public class HardwareTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public HardwareTypesController(IMediator  mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllHardwareTypes")]
        public async Task<ActionResult<List<HardwareTypeDto>>> Get()
        {
            var query = new GenericGetAllRequest<HardwareTypeDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<HardwareTypeDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllHardwareTypes");
            }

            var query = new GenericGetBySearchTermRequest<HardwareTypeDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<HardwareTypeDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<HardwareTypeDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateHardwareTypeDto hardwareType)
        {
            var command = new GenericCreateRequest<CreateHardwareTypeDto> { EntityTBC = hardwareType };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateHardwareTypeDto hardwareType)
        {
            var command = new GenericUpdateRequest<UpdateHardwareTypeDto> { EntityTBU = hardwareType };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<HardwareType> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
