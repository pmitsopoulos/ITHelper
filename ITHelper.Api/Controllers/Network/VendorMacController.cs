using ITHelper.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.Network
{
    [ApiController]
    [Route("NetworkTools/[controller]")]
    public class VendorMacController : ControllerBase
    {
        private readonly IApiMethodHelper client;

        public VendorMacController(IApiMethodHelper client)
        {
            this.client = client;
        }
        
        [HttpGet("{mac}")]
        public async Task<IActionResult> Get(string mac)
        {
            var response = await client.http.GetStringAsync($"https://api.macvendors.com/{mac}");
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
