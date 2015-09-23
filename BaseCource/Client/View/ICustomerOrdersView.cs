using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using System.ComponentModel;
using Client.ClientModel.Entities;

namespace Client.View
{
    public interface ICustomerOrdersView
    {
        IList<ClientOrder> Orders { get; set; }
        User Customer { get; set; }
        ClientOrder SelectedOrder { get; set; }
    }
}
