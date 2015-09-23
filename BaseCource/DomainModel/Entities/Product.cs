using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DomainModel.Entities
{
    /// <summary>
    /// The product class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Count of products at the warehouse
        /// </summary>
        public virtual int Units { get; set; }

        /// <summary>
        /// Current product price
        /// </summary>
        public virtual ProductPrice Price { get; set; }
    }
}
