using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
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
    public class ApplicationSystemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicationSystemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllApplicationSystems")]
        public async Task<ActionResult<List<ApplicationSystemDto>>> Get()
        {
            var query = new GenericGetAllRequest<ApplicationSystemDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<ApplicationSystemDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllApplicationSystems");
            }

            var query = new GenericGetBySearchTermRequest<ApplicationSystemDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ApplicationSystemDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<ApplicationSystemDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateApplicationSystemDto applicationSystem)
        {
            var command = new GenericCreateRequest<CreateApplicationSystemDto> { EntityTBC = applicationSystem };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateApplicationSystemDto applicationSystem)
        {
            var command = new GenericUpdateRequest<UpdateApplicationSystemDto> { EntityTBU = applicationSystem };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<ApplicationSystem> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
