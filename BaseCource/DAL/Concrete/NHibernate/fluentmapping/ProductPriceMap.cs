using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DomainModel.Entities;

namespace Server.fluentmapping
{
    class ProductPriceMap : ClassMap<ProductPrice>
    {
        public ProductPriceMap()
        {
            Table(StringConst.ProductPriceMapTableName);
            Id(x => x.Id).Column("ProductPrice_id").GeneratedBy.Identity();
            Map(x => x.EffectiveDate).Column("EffectiveDate");
            Map(x => x.Price);
            References(x => x.Product).Column("Product_id").Cascade.SaveUpdate();
        }
    }
}
