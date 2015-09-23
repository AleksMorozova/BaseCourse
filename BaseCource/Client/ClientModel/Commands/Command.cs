using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ClientModel.Commands
{
    public class Command
    {
        public Entity Entity { get; set; }
        public CommandType CommandType { get; set; }
        public String FieldName { get; set; }
        public object Value { get; set; }
    }
}
