using AutoMapper;
using ITHelper.Application.DTOs.AssetInventoryDTOs.ContactDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Profiles.AssetInventoryProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ContactMappings
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            #endregion

            #region DepartmentMappings
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            #endregion

            #region HardwareMappings
            CreateMap<Hardware, HardwareDto>().ReverseMap();
            CreateMap<Hardware, CreateHardwareDto>().ReverseMap();
            CreateMap<Hardware, UpdateHardwareDto>().ReverseMap();
            CreateMap<Hardware, AssignHardwareDto>().ReverseMap();
            #endregion

            #region HardwareTypeMappings
            CreateMap<HardwareType, HardwareTypeDto>().ReverseMap();
            CreateMap<HardwareType, CreateHardwareTypeDto>().ReverseMap();
            CreateMap<Hardware, UpdateHardwareTypeDto>().ReverseMap();
            #endregion

            #region SiteMappings
            CreateMap<Site, SiteDto>().ReverseMap();
            CreateMap<Site, CreateSiteDto>().ReverseMap();
            CreateMap<Site, UpdateSiteDto>().ReverseMap();
            #endregion

            #region UserMappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            #endregion

            #region VendorMappings
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<Vendor, CreateVendorDto>().ReverseMap();
            CreateMap<Vendor, UpdateVendorDto>().ReverseMap();
            #endregion
        }
    }
}
