using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services.DTOs.CompanyDtos;

namespace Yol.API.Configurations
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Company, CompanyForCreationDto>().ReverseMap();
        }
    }
}
