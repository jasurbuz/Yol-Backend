using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Services.DTOs.CompanyDtos
{
    public class CompanyForCreationDto
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string INN { get; set; }
        [Required]
        public string DateOfFoundation { get; set; }
        [Required]
        public int NumberOfEmployees { get; set; }
        
        public IFormFile SucessfullPlansFile { get; set; }
        
        public IFormFile LicenseFile { get; set; }
    }
}
