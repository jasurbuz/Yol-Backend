using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Data.Models.Indentity;

namespace Yol.Services.DTOs.RoadDtos
{
    public class RoadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Lenghth { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public decimal SeparatedMoney { get; set; }
        public decimal UsedMoney { get; set; }
        public string Source { get; set; }
        public string Responsible { get; set; }
        public string Region { get; set; }
        public Admin Admin { get; set; }
        public ICollection<decimal[]> Cordinates { get; set; }
        public ICollection<string> Images { get; set; }
    }
}
