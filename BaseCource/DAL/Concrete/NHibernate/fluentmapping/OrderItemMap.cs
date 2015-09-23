using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DomainModel.Entities;

namespace Server.fluentmapping
{
    class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table(StringConst.OrderItemMapTableName);
            Id(x => x.Id).Column("OrderItem_id");
            Map(x => x.Count).Column("Quantity");
            //References(x => x.Order_Id).Cascade.SaveUpdate().Column("Order_id");
            //References(x => x.Product_Id).Cascade.SaveUpdate().Column("Product_id");
        }
    }
}
