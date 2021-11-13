using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yol.Services.DTOs;

namespace Yol.API.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();
    }
}
