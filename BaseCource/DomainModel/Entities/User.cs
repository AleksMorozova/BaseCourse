
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DomainModel.Entities
{
    /// <summary>
    /// The base user class
    /// </summary>
    public class User
    {
        /// <summary>
        /// User ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// User login
        /// </summary>
        public virtual string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// User role
        /// </summary>
        public virtual Role Role { get; set; }
    }
    
}
