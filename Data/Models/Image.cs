﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Data.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }

        #region Relation
        public Guid RoadId { get; set; }
        public Road Road { get; set; }
        #endregion
    }
}
