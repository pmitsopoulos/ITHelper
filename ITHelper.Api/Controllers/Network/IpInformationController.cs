using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Models.NetworkModels;
using Microsoft.AspNetCore.Mvc;

namespace ITHelper.Api.Controllers.Network
{
    [ApiController]
    [Route("NetworkTools/[controller]")]
    public class IpInformationController : ControllerBase
    {
        private readonly IApiMethodHelper client;
       

        public IpInformationController(IApiMethodHelper client)
        {
           
            this.client = client;
            client.SetUrl($"https://ipinfo.io");
            client.SetApiKey("?token=ab8f8317f6fcef");
        }

        [HttpGet]
        [Route("MyExternalIp")]
        public async Task<IActionResult> Get()
        {
            var myIp = await client.http.GetStringAsync("https://ipinfo.io/ip");

            var response =  await client.InvokeGet<HostInformation>(myIp);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{ip}")]
        public async Task<IActionResult> Get(string? ip)
        {
            
            var response = await client.InvokeGet<HostInformation>(ip);
            if(response != null)
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
