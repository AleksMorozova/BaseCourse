using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    /// <summary>
    /// Enumeration of possible statuses of the order
    /// </summary>
    public enum Status
    {
        Draft,
        New,
        Confirmed,
        Paid,
        Deliver
    }
}
