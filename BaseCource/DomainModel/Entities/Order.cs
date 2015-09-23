using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Class which represents order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Date when the order was placed
        /// </summary>
        public virtual DateTime PlacingDate { get; set; }
        /// <summary>
        /// Items which contains in the order
        /// </summary>
        public virtual IList<OrderItem> Items { get; set; }
        /// <summary>
        /// Status of the order
        /// </summary>
        public virtual Status Status { get; set; }
        /// <summary>
        /// User which made thi order
        /// </summary>
        public virtual User User { get; set; }
    }
  
}
