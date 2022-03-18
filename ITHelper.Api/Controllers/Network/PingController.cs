using ITHelper.Application.Features.NetworkFeatures;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers
{
    [ApiController]
    [Route("api/NetworkTools/[controller]")]
    public class PingController : ControllerBase
    {
        private readonly PingNetwork ping;

        public PingController(PingNetwork ping)
        {
            this.ping = ping;
        }

        [HttpGet("{subnet}")]
        public async Task<IActionResult> Get(string subnet)
        {
            ping.Subnet = subnet;
            ping.InitiateSubnetScan();
            return Ok(ping.Hosts);
        }
    }
}
