using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Class which represents the technologist
    /// </summary>
    class Technologist:User
    {
        public Technologist()
        {
            Role = Role.Technologist;
        }
    }
}
