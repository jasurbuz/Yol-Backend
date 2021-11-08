using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services.DTOs;
using Yol.Services.DTOs.CompanyDtos;
using Yol.Services.IRepository;
using Yol.API.Extensions;

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
        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery] RequestParams requestParams)
        {
            if (requestParams.OrderBy is null)
                requestParams.OrderBy = "Fullname";

            var companies = await _unitOfWork.Companies.GetPagedList(requestParams, order => order.OrderBy(requestParams.OrderBy),
                includes: new List<string> { "Roads" });

            var response = new ResponseDto
            {
                PageCount = companies.PageCount,
                Total = companies.TotalItemCount,
                Current = companies.PageNumber,
                PageSize = companies.PageSize,
                HasPreviousPage = companies.HasPreviousPage,
                HasNextPage = companies.HasNextPage,
                FirstItemOnPage = companies.FirstItemOnPage,
                LastItemOnPage = companies.LastItemOnPage,
                Data = _mapper.Map<IEnumerable<CompanyDTO>>(companies)
            };

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCompany(Guid Id)
        {
            var company = await _unitOfWork.Companies.Get(p => p.Id == Id);
            if(company is null)
                return NotFound("Company not found");
            return Ok(company);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCompany(Guid Id)
        {
            var company = await _unitOfWork.Companies.Get(p => p.Id == Id);
            if (company is null)
                return NotFound("Company not found");
            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.Save();
            return NoContent();
        }
        
    }
}
