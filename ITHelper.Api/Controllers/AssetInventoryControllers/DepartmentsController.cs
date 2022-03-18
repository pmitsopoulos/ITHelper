using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
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
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllDepartments")]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {
            var query = new GenericGetAllRequest<DepartmentDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<DepartmentDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllDepartments");
            }

            var query = new GenericGetBySearchTermRequest<DepartmentDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DepartmentDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<DepartmentDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateDepartmentDto department)
        {
            var command = new GenericCreateRequest<CreateDepartmentDto> { EntityTBC = department };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateDepartmentDto department)
        {
            var command = new GenericUpdateRequest<UpdateDepartmentDto> { EntityTBU = department };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<Department> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
