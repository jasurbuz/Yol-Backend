﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models.Indentity
{
    public class Admin : ApiUser
    {
        #region Relation
        public ICollection<News> News { get; set; }
        public ICollection<Road> Roads { get; set; }
        #endregion
    }
}
