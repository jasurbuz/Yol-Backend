using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models.Indentity;

namespace Yol.Data.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
       
        #region Reation
        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }
        #endregion
    }
}
