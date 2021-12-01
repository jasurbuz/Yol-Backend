using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models.Indentity;

namespace Yol.Services.DTOs.NewsDtos
{
    public class NewsForCreationDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid AdminId { get; set; }
    }
}