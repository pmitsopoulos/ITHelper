using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Features.CommonFeatures.Requests.Commands;
using ITHelper.Application.Features.CommonFeatures.Requests.Queries;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.AssetInventoryControllers
{
    [Route("AssetInventory/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllContacts")]
        public async Task<ActionResult<List<ContactDto>>> Get()
        {
            var query = new GenericGetAllRequest<ContactDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<ContactDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty )
            {
                return RedirectToAction("GetAllContacts");
            }
        
            var query = new GenericGetBySearchTermRequest<ContactDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ContactDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<ContactDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<Contact> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
