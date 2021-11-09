using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models
{
    public class News
    {
        public int Id { get; set; }
        public int ApiUserId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
