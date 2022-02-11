using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Models.NetworkModels
{
    public class HostInformation
    {
        [JsonProperty("ip")]
        [Display(Name = "IP Address")]
        public string? Ip { get; set; }

        [JsonProperty("hostname")]
        [Display(Name = "Host Name")]
        public string? HostName { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("loc")]
        [Display(Name = "Coordinates")]
        public string? Loc { get; set; }

        [JsonProperty("org")]
        [Display(Name = "Organization")]
        public string? Org { get; set; }

    }
}
