using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models.Indentity;

namespace Yol.Data.Models
{
    public class Road
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

        #region Realtion
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }

        public ICollection<Coordinate> Cordinates { get; set; }
        public ICollection<Image> Images { get; set; }
        #endregion
    }
}
