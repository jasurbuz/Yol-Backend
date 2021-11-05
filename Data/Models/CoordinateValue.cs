using System;

namespace Yol.Data.Models
{
    public class CoordinateValue
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }

        #region Relation
        public Guid CoordinateId { get; set; }
        public Coordinate Coordinate { get; set; }
        #endregion
    }
}
