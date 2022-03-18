using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Features.IssueTrackerFeatures.IssuesFeatures.Requests.Queries;
using ITHelper.Application.Models.FilterModels.IssueTrackerFilterModels;
using ITHelper.Application.Responses;
using ITHelper.Domain.IssueTrackerEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.IssueTrackerControllers
{
    [Route("api/IssueTracker/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IMediator mediator;

        public IssuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllIssues")]
        public async Task<ActionResult<List<IssueDto>>> Get()
        {
            var query = new GenericGetAllRequest<IssueDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<IssueDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllIssues");
            }

            var query = new GenericGetBySearchTermRequest<IssueDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<IssueDto>>> Get([FromBody] IssueFilterModel? filter)
        {
            if (filter == null)
            {
                return RedirectToAction("GetAllIssues");
            }

            var query = new GetIssuesByFilteredSearchRequest() { IssueFilter = filter };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<IssueDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<IssueDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateIssueDto issue)
        {
            var command = new GenericCreateRequest<CreateIssueDto> { EntityTBC = issue };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateIssueDto issue)
        {
            var command = new GenericUpdateRequest<UpdateIssueDto> { EntityTBU = issue };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<Issue> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
