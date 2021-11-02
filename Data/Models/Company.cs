using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string INN { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public int NumberOfEmployees { get; set; }
        public int SucessfullPlans { get; set; }
        public string FileName { get; set; }
        public string LicenseFileName { get; set; }

        #region Relation
        public ICollection<Road> Roads { get; set; }
        #endregion

    }
}
