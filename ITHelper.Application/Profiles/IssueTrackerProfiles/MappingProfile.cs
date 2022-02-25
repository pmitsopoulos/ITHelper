using AutoMapper;
using ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.IssueDTOs;
using ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs;
using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Profiles.IssueTrackerProfiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region ApplicationSystemMappings
            CreateMap<ApplicationSystem, ApplicationSystemDto>().ReverseMap();
            CreateMap<ApplicationSystem, CreateApplicationSystemDto>().ReverseMap();
            CreateMap<ApplicationSystem, UpdateApplicationSystemDto>().ReverseMap();
            #endregion

            #region IssueMappings
            CreateMap<Issue, IssueDto>().ReverseMap();
            CreateMap<Issue,CreateIssueDto>().ReverseMap();
            CreateMap<Issue,UpdateIssueDto>().ReverseMap();
            #endregion
            
            #region SystemContactMappings
            CreateMap<SystemContact, SystemContactDto>().ReverseMap();
            CreateMap<SystemContact, CreateSystemContactDto>().ReverseMap();
            CreateMap<SystemContact, UpdateSystemContactDto>().ReverseMap();
            #endregion
        }
    }
}
