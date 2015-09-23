    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using DomainModel;
using DomainModel.Entities;

namespace Server.fluentmapping
{
   public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table(StringConst.OrderMapTableName);
            Id(x => x.Id).Column("Order_id");
            Map(x => x.PlacingDate).CustomType<DateTime>();
            Map(x => x.Status).CustomType<Status>();
            HasMany(x => x.Items).Cascade.All().KeyColumn(StringConst.OrderItemFKColum).
                Table(StringConst.OrderItemMapTableName);
            //References(x => x.Users_Id).Column("Users_id").Cascade.None();
            //Map(x => x.Users_Id).Column("Users_id");
        }
       
    }
}
