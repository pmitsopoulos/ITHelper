﻿using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
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
    public class VendorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public VendorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllVendors")]
        public async Task<ActionResult<List<VendorDto>>> Get()
        {
            var query = new GenericGetAllRequest<VendorDto>();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("search/{search?}")]
        public async Task<ActionResult<List<VendorDto>>> Get(string? search)
        {
            if (string.IsNullOrWhiteSpace(search) || search == string.Empty)
            {
                return RedirectToAction("GetAllVendors");
            }

            var query = new GenericGetBySearchTermRequest<VendorDto>() { SearchTerm = search };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<VendorDto>>> Get(int id)
        {
            var query = new GenericGetByIdRequest<VendorDto>() { Id = id };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateVendorDto vendor)
        {
            var command = new GenericCreateRequest<CreateVendorDto> { EntityTBC = vendor };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Put([FromBody] UpdateVendorDto vendor)
        {
            var command = new GenericUpdateRequest<UpdateVendorDto> { EntityTBU = vendor };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var command = new GenericDeleteRequest<Vendor> { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }

    }
}
