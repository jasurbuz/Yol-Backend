using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services;
using Yol.Services.DTOs.CompanyDtos;

namespace Yol.API.Configurations
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Company, CompanyForCreationDto>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ForMember(dto => dto.LicenseFileName, 
                src => src.MapFrom(source => !string.IsNullOrEmpty(source.LicenseFileName)
                    ? $"{CustomServices.GetBaseUrl()}/License/{source.LicenseFileName}"
                                : null)).ForMember(dto => dto.SucessfullPlansFileName,
                src => src.MapFrom(source => !string.IsNullOrEmpty(source.SucessfullPlansFileName)
                    ? $"{CustomServices.GetBaseUrl()}/Plans/{source.SucessfullPlansFileName}"
                                : null)).ReverseMap();
        }
    }
}
