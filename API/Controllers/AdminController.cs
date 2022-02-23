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
using Microsoft.AspNetCore.Identity;
using Yol.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Yol.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody]AdminForCreationDto adminDto, string role = "Admin")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (_userManager.Users.Any(user => user.UserName == adminDto.Username))
                return BadRequest(new { Error = "Username already exist!" });
            
            var admin = _mapper.Map<Admin>(adminDto);

            admin.NormalizedUserName = adminDto.Username.ToUpper();

            var result = await _userManager.CreateAsync(admin, adminDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(admin, role);

            return Accepted();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdmins([FromQuery] RequestParams requestParams)
        {
            if (requestParams.OrderBy is null)
                    requestParams.OrderBy = "Region";
            var admins = await _unitOfWork.Admins.GetPagedList(requestParams,
                order => order.OrderBy(requestParams.OrderBy));
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
            return Ok(_mapper.Map<AdminDto>(admin));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin([FromForm] AdminForCreationDto adminDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _unitOfWork.Admins.Get(admin => admin.Id == id, tracking: true);

            if (admin.UserName != adminDto.Username)
            {
                if (_userManager.Users.Any(user => user.UserName == adminDto.Username))
                    return BadRequest(new { Error = "Username already exist!" });
            }

            if (admin is null)
                return NotFound();

            _mapper.Map(adminDto, admin);

            admin.NormalizedUserName = admin.UserName.ToUpper();

            _unitOfWork.Admins.Update(admin);

            await _unitOfWork.Save();

            return NoContent();
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
