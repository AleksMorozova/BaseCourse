using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using System.ComponentModel;

namespace Client.View
{
    public interface ITechnologistView
    {
        IList<Order> Orders { get; set; }
        User Technologist { get; set; }
        Order SelectedOrder { get; set; }
    }
}
