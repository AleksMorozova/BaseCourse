using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Class which represents customer
    /// </summary>
    public class Customer:User
    {
        /// <summary>
        /// Customer's orders
        /// </summary>
        public virtual List<Order> Orders { get; set; }
        public Customer()
        {
            Role = Role.Customer;
        }
    }
}
