using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Data.Models.Indentity;
using Yol.Services.DTOs;
using Yol.Services.DTOs.AdminDtos;
using Yol.Services.IRepository;
using Yol.API.Extensions;

namespace Yol.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromForm]AdminForCreationDto creationDto)
        {
            var admin = _mapper.Map<Admin>(creationDto);
            await _unitOfWork.Admins.Insert(admin);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmins([FromQuery] RequestParams requestParams)
        {
            if (requestParams.OrderBy is null)
                    requestParams.OrderBy = "Region";
            var admins = await _unitOfWork.Admins.GetPagedList(requestParams,
                order => order.OrderBy(requestParams.OrderBy),
                includes: new List<string> { "News" });
            var response = new ResponseDto
            {
                PageCount = admins.PageCount,
                Total = admins.TotalItemCount,
                Current = admins.PageNumber,
                PageSize = admins.PageSize,
                HasPreviousPage = admins.HasPreviousPage,
                HasNextPage = admins.HasNextPage,
                FirstItemOnPage = admins.FirstItemOnPage,
                LastItemOnPage = admins.LastItemOnPage,
                Data = _mapper.Map<IEnumerable<AdminDto>>(admins)
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(Guid id)
        {
            var admin = await _unitOfWork.Admins.Get(p => p.Id == id);
            if (admin == null)
                return NotFound("Admin doesn't found");
            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin([FromForm] AdminForCreationDto adminDto, Guid id)
        {
            var admin = await _unitOfWork.Admins.Get(p => p.Id == id);
            if (admin != null)
            {
                _mapper.Map(adminDto, admin);

                _unitOfWork.Admins.Update(admin);
                await _unitOfWork.Save();
                return Ok();
            }
            else
                return NotFound("Admin doesn't found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(Guid id)
        {
            var admin = await _unitOfWork.Admins.Get(p => p.Id == id);
            if(admin == null)
                return NotFound("Admin doesn't found");
            
            _unitOfWork.Admins.Delete(admin);
            await _unitOfWork.Save();
            
            return NoContent();
        }

    }
}
