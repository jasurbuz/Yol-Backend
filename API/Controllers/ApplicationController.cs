using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yol.API.Extensions;
using Yol.Data.Models;
using Yol.Services.DTOs;
using Yol.Services.DTOs.ApplicationDtos;
using Yol.Services.IRepository;

namespace Yol.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromForm] ApplicationForCreationDto creationDto)
        {
            var application = _mapper.Map<Application>(creationDto);
            if(creationDto.AdditionalFile != null)
                application.AdditionalFileName = await _unitOfWork.SaveFileAsync(creationDto.AdditionalFile, "Others");
            await _unitOfWork.Applications.Insert(application);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetApplications([FromForm] RequestParams requestParams)
        {
            if(requestParams.OrderBy is null)
            {
                requestParams.OrderBy = "CreatedTime";
            }

            var applications = await _unitOfWork.Applications.GetPagedList(requestParams, order => order.OrderBy(requestParams.OrderBy));

            var response = new ResponseDto
            {
                PageCount = applications.PageCount,
                Total = applications.TotalItemCount,
                Current = applications.PageNumber,
                PageSize = applications.PageSize,
                HasPreviousPage = applications.HasPreviousPage,
                HasNextPage = applications.HasNextPage,
                FirstItemOnPage = applications.FirstItemOnPage,
                LastItemOnPage = applications.LastItemOnPage,
                Data = _mapper.Map<IEnumerable<ApplicationDto>>(applications)
            };
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetApplication(Guid Id)
        {
            var application = await _unitOfWork.Applications.Get(p => p.Id == Id);
            if (application is null)
                return NotFound("Application doesn't found");
            return Ok(application);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateApplication([FromForm] ApplicationForCreationDto creationDto, Guid Id)
        {
            var application = await _unitOfWork.Applications.Get(p => p.Id == Id);
            if (application != null)
                return NotFound("Application doesn't found");
            _mapper.Map(creationDto, application);

            _unitOfWork.Applications.Update(application);
            await _unitOfWork.Save();

            return NoContent();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteApplication(Guid Id)
        {
            var application = await _unitOfWork.Applications.Get(p => p.Id == Id);
            if(application is null)
            {
                return NotFound("Application doesn't found");
            }
            _unitOfWork.Applications.Delete(application);
            await _unitOfWork.Save();
            return NoContent();
        }

    }
}
