using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Class which represents the product in the order
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// OrderItem ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Count of the product
        /// </summary>
        public virtual int Count { get; set; }
        public virtual Order Order { get; set; }
        /// <summary>
        /// Product in the order
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
