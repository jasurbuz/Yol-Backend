using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Services.DTOs.RoadDtos
{
    public class RoadForMapDTO
    {
        public Guid Id { get; set; }
        public ICollection<decimal[]> Coordinates { get; set; }
        public string Status { get; set; }
    }
}
