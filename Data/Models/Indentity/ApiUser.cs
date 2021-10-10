using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models
{
    public class ApiUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Region { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string ImageName { get; set; }

        public override bool LockoutEnabled => true;

        public ICollection<Event> Events { get; set; }
            = new List<Event>();
    }
}
