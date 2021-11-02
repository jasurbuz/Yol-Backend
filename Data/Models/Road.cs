using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models
{
    public class Road
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public double Lenghth { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public decimal SeparatedMoney { get; set; }
        public decimal UsedMoney { get; set; }
        public IList<IList<string>> Cordinate { get; set; }
        public string Source { get; set; }
        public string Responsible { get; set; }

        #region Realtion
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        #endregion
    }
}
