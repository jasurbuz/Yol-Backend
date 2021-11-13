using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;

namespace Yol.Services.DTOs.AdminDtos
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Region { get; set; }
        public string Token { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Road> Roads { get; set; }
    }
}
