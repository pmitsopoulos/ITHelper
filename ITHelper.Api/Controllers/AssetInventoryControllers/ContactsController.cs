using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.AssetInventoryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateContactDto contact)
        {
            var command = new GenericCreateRequest<CreateContactDto> { EntityTBC = contact };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateContactDto contact)
        {
            var command = new GenericUpdateRequest<UpdateContactDto> { EntityTBU = contact };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
