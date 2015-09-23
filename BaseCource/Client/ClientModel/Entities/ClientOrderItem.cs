using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ClientModel.Entities
{
    public class ClientOrderItem:Entity
    {
        public ClientOrderItem(int Id)
        {
            this.Id = Id;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get { return Price * Count; } private set { } }
    }
}
