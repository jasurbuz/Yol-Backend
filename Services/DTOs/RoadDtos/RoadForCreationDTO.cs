using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Services.DTOs.RoadDtos
{
    public class RoadForCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public double Lenghth { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public decimal SeparatedMoney { get; set; }
        public decimal UsedMoney { get; set; }
        public string Source { get; set; }
        public string Responsible { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public Guid AdminId { get; set; }
        [Required]
        public string Cordinate { get; set; }
        public ICollection<IFormFile> Images { get; set; }
    }
}
