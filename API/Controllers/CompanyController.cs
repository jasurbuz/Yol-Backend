using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services.DTOs.CompanyDtos;
using Yol.Services.IRepository;

namespace Yol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm]CompanyForCreationDto creationDto)
        {
            var company = _mapper.Map<Company>(creationDto);
            if (creationDto.LicenseFile is not null)
                company.LicenseFileName = await _unitOfWork.SaveFileAsync(creationDto.LicenseFile, "License");
            if (creationDto.SucessfullPlansFile is not null)
                company.SucessfullPlansFileName = await _unitOfWork.SaveFileAsync(creationDto.SucessfullPlansFile, "Plans");
            await _unitOfWork.Companies.Insert(company);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}
