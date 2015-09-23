using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.fluentmapping
{
    public class StringConst
    {
        public const string OrderMapTableName = "[Order]";
        public const string OrderItemMapTableName = "OrderItem";
        public const string ProductMapTableName = "Product";
        public const string ProductPriceMapTableName = "ProductPrice";
        public const string UserMapTableName = "Users";
        public const string OrderItemFKColum = "Order_id";
        public const string ProductPriceFKColum = "Product_Id";
        public const string UsersFK = "Users_id";
    }
}
