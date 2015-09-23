using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DomainModel.Entities;

namespace Server.fluentmapping
{
    class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(StringConst.ProductMapTableName);
            Id(x => x.Id).Column("Product_id").GeneratedBy.Identity();
            Map(x => x.Name).Column("ProductName");
            Map(x => x.Units).Column("Units");
            /*HasMany(x => x.Prices).Cascade.All().
                KeyColumn(StringConst.ProductPriceFKColum);*/
        }
    }
}
