using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services;
using Yol.Services.DTOs.ApplicationDtos;
using Yol.Services.DTOs.CompanyDtos;
using Yol.Services.DTOs.RoadDtos;

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

            CreateMap<Application, ApplicationForCreationDto>().ReverseMap();
            CreateMap<Application, ApplicationDto>().ForMember(dto => dto.AdditionalFileName,
                src => src.MapFrom(source => !string.IsNullOrEmpty(source.AdditionalFileName)
                ? $"{CustomServices.GetBaseUrl()}/Others/{source.AdditionalFileName}" : null)).ReverseMap();

            CreateMap<Road, RoadForCreationDTO>().ReverseMap();
        }
    }
}
