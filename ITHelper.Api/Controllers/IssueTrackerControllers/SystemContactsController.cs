using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.IssueTrackerControllers
{
    [Route("api/IssueTracker/[controller]")]
    [ApiController]
    public class SystemContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SystemContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllSContacts")]
        public async Task<ActionResult<List<SystemContactDto>>> Get()
        {
            var query = new GenericGetAllRequest<SystemContactDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<SystemContactDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllSContacts");
            }

            var query = new GenericGetBySearchTermRequest<SystemContactDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SystemContactDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<SystemContactDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateSystemContactDto systemContact)
        {
            var command = new GenericCreateRequest<CreateSystemContactDto> { EntityTBC = systemContact };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateSystemContactDto systemContact)
        {
            var command = new GenericUpdateRequest<UpdateSystemContactDto> { EntityTBU = systemContact };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<SystemContact> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
