using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using Client.ClientModel.Entities;

namespace Client.View
{
    public interface ICustomerEditOrderView
    {
        ClientOrder Order { get; set; }
        List<Product> Products { get; set; }
        User Customer { get; set; }
        String ViewCaption { get; set; }
        /// <summary>
        /// Shows order info to user
        /// </summary>
        void ShowOrderInfo();
    }
}
