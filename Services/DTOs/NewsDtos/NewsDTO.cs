using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models.Indentity;

namespace Yol.Services.DTOs.NewsDtos
{
    public class NewsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedTime { get; set; }

        public Admin Admin { get; set; }
    }
}
