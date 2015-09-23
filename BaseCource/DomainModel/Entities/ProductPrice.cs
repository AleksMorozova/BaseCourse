using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Class which represents the product price
    /// </summary>
    public class ProductPrice:IComparable
    {
        /// <summary>
        /// Product price ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Product 
        /// </summary>
        public virtual Product Product { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public virtual double Price { get; set; }
        /// <summary>
        /// Date when this price is actual
        /// </summary>
        public virtual DateTime EffectiveDate { get; set; }

        public int CompareTo(object obj)
        {
            return EffectiveDate.CompareTo(obj);
        }
    }
}
