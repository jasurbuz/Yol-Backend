using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;

namespace Yol.Data.Events
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public ICollection<ApiUser> Users { get; set; }
            = new List<ApiUser>();
    }
}
