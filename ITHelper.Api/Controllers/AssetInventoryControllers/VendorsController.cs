using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.AssetInventoryControllers
{
    [Route("AssetInventory/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public VendorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ContactDto>>> Get(int id)
        {
            var contacts = await mediator.Send(new GetVendorRequest() {Id = id });
            return Ok(contacts);
        }

    }
}
