

using AutoMapper;
using ITHelper.Application.DTOs.NetworkPortInfoDTOs.NetworkPortInformationDTOs;
using ITHelper.Domain.NetworkPortInfoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Profiles.NetworkPortInfoProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NetworkPortInformation, NetworkPortInformationDto>().ReverseMap();
            CreateMap<NetworkPortInformation, CreateNetworkPortInformationDto>().ReverseMap();
            CreateMap<NetworkPortInformation, UpdateNetworkPortInformationDto>().ReverseMap();
        }
    }
}
