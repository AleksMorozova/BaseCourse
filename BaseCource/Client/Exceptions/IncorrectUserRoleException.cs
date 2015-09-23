using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Exceptions
{
    class IncorrectUserRoleException:Exception
    {
        public IncorrectUserRoleException()
        {

        }
        public IncorrectUserRoleException(string message) : base(message) { }
        public IncorrectUserRoleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
