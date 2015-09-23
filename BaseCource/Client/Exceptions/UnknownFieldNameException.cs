using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Exceptions
{
    public class UnknownFieldNameException:Exception
    {
        public UnknownFieldNameException(){}
        public UnknownFieldNameException(string message) : base(message) { }
        public UnknownFieldNameException(string message, Exception innerException) : base(message, innerException) { }
    }
}
