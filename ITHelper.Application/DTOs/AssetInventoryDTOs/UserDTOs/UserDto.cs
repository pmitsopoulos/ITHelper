﻿
using ITHelper.Application.DTOs.AssetInventoryDTOs.AssetDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs
{
    public class UserDto
    {

        public UserDto()
        {
            Assets = new List<AssetDto>();
        }
        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        public virtual DepartmentDto Department { get; set; }

        public int SiteId { get; set; }
        public virtual SiteDto Site { get; set; }

        public ICollection<AssetDto> Assets { get; set; }
    }
}