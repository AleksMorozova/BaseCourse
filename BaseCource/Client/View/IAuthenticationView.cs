using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace Client.View
{
    public interface IAuthenticationView
    {
        /// <summary>
        /// Uset login
        /// </summary>
        string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// User
        /// </summary>
        User User { get; set; }
    }
}
