using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Yol.API.Services;
using Yol.Data.Models;
using Yol.Services.DTOs;
using Yol.Services.DTOs.AdminDtos;
using Yol.Services.IRepository;

namespace Yol.API.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;


        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Username}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized();
            }

            return await GetUserWithToken(userDto.Username);
        }

        [Authorize]
        [HttpGet("getme")]
        public async Task<IActionResult> GetmeAsync()
        {
            var username = User.Identity.Name;

            return await GetUserWithToken(username, hasToken: false);
        }

        private async Task<IActionResult> GetUserWithToken(string username, bool hasToken = true)
        {
            var user = await _userManager.FindByNameAsync(username);

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (role is null)
                return NotFound();

            dynamic userWithToken = MapUserWithToken(user, role);

            userWithToken.Role = role;

            if (hasToken)
                userWithToken.Token = await _authManager.CreateToken();

            return Accepted(userWithToken);
        }

        private dynamic MapUserWithToken(ApiUser user, string role)
        {
            dynamic userWithToken = _mapper.Map<AdminDto>(user);

            return userWithToken;
        }
    }
}
