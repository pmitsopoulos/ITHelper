using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var query = new GenericGetAllRequest<UserDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<UserDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllUsers");
            }

            var query = new GenericGetBySearchTermRequest<UserDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<UserDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateUserDto user)
        {
            var command = new GenericCreateRequest<CreateUserDto> { EntityTBC = user };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateUserDto user)
        {
            var command = new GenericUpdateRequest<UpdateUserDto> { EntityTBU = user };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<User> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
