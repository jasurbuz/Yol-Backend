using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;

namespace Yol.Services.DTOs.CompanyDtos
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string INN { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public int NumberOfEmployees { get; set; }
        public string SucessfullPlansFileName { get; set; }
        public string LicenseFileName { get; set; }
        public ICollection<Road> Roads { get; set; }
    }
}
