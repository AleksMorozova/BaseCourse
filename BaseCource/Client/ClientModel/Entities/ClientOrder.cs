using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ClientModel;
using Client.ClientModel.Entities;
using DomainModel.Entities;
using System.ComponentModel;

namespace Client.ClientModel.Entities
{
    public class ClientOrder:Entity
    {
        public ClientOrder(int Id)
        {
            this.Id = Id;
        }

        public ClientOrder()
        {
            // TODO: Complete member initialization
        }
        public Status Status { get; set; }
        public DateTime PlacingDate { get; set; }
        public double TotalPrice
        {
            get
            {
                double sum = 0;
                foreach (var product in Products)
                {
                    if (product != null)
                        sum += product.TotalPrice;
                }
                return sum;
            }
            private set { }
        }
        public BindingList<ClientOrderItem> Products { get; set; }

    }
}
