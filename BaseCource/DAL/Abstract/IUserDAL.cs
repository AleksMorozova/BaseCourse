using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DAL.Abstract
{
    public interface IUserDAL
    {
        /// <summary>
        /// Gets user by login and password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User who has the specified login and password. 
        /// Null if there are no users with specified data</returns>
        User GetUser(string login, string password);
    }
}
