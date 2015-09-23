using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlServerCe;

namespace NativeSQLviaADO
{
    class SQLQueryString
    {
        //SqlCeConnection connection = new SqlCeConnection(SQLQueryString.ConnStr);

        static string GetConnectionStringByName(string name)
        {
            // Assume failure. 
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string. 
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
        public static string ConnStr = GetConnectionStringByName("FHdb");

        public static SqlCeConnection connection = new SqlCeConnection(SQLQueryString.ConnStr);

        //public const string ConnStr = @"Data Source=|DataDirectory|\..\..\..\Course.sdf";
        /// <summary>
        /// User
        /// </summary>
        public const string SelectUsers = "SELECT Users_id, UsersName, Role, Login, Password FROM Users WHERE Users_id=@id";
        public const string SelectUsersString = "SELECT Users_id, UsersName, Role, Login, Password FROM Users WHERE Login=@log and Password = @pas";
        public const string UpdateUsersNameString = "UPDATE Users SET UsersName = @name WHERE Login = @log and Passwor= @pas";
        public const string UpdateUsersLoginPas = "UPDATE Users SET Login = @newlog WHERE Login = @log and Passwor= @pas";

        public const string SelectUsersID = "SELECT Users_id From Users WHERE Login = @log and Passwor= @pas";

        public const string DeleteUsersString = "DELETE FROM Users WHERE Users_id = @id";
        public const string InsertUsersString = "INSERT INTO Users" + "(UsersName,Role,Login,Password) VALUES (@name,@role,@log,@pas)";

        /// <summary>
        /// Order
        /// </summary>
        public const string SelectOrderString = "SELECT Order_id, PlacingDate, Status,Users_id FROM [Order] WHERE Users_id=@id";
        public const string SelectOrderbyID = "SELECT Order_id, PlacingDate, Status, Users_id FROM [Order] WHERE Order_id=@id";
        public const string SelectAllOrderString = "SELECT Order_id, PlacingDate, Status,Users_id FROM [Order]";
        public const string InsertOrderString = "INSERT INTO  [Order]" + " (PlacingDate, Status, Users_id) VALUES (@date, @status, @user)";
        public const string DeleteOrderString = "DELETE FROM [Order] WHERE Order_id=@id";
        public const string UpdateOrderString = "UPDATE [Order] SET Status = @status WHERE Order_id=@id";

        /// <summary>
        /// Product Price
        /// </summary>
        public const string SelectPriceString = "SELECT ProductPrice_id, Price, EffectiveDate, Product_id FROM ProductPrice WHERE  Product_id=@id";
        public const string Selectdate = "SELECT PlacingDate FROM [Order] WHERE  Order_id=@id";

        public const string InsertProductPrice = "";

        public const string UpdateProductPrice = "";
        public const string DeleteProductPrice = "";

        /// <summary>
        /// Product
        /// </summary>
        //public const string SelectProductList = "SELECT ProductName, Units FROM Product";
        public const string InsertProductString = "INSERT INTO Product" + " (ProductName, Units) VALUES (@name,@units)";
        public const string UpdateProductString = "UPDATE Product SET Units=@units WHERE ProducName = @name";
        public const string DeleteProductString = "DELETE FROM Product WHERE Product_id=@id";
        public const string SelectProductList = "SELECT Product_id, ProductName, Units FROM Product WHERE Product_id=@id";
        public const string SelectProduct = "SELECT Product_id, ProductName, Units FROM Product";
        public const string SelectProdID = "SELECT Product_id FROM Product WHERE ProductName=@name";

        /// <summary>
        /// Order_Item
        /// </summary>
        public const string SelectOrderItemString = "SELECT OrderItem_id, Quantity, Order_id, Product_id From OrderItem WHERE OrderItem.Order_id = @id";
        public const string SelectOrderItem2 = "SELECT ProductName, Quantity From Product, OrderItem WHERE Order_id = @id and Product_id = @prodid";
        public const string UpdateOrderItem = "UPDATE OrderItem Set Quantity = @quantity WHERE OrderItem_id=@id";
        public const string InsertOrderItem = "INSERT INTO OrderItem" + "(Quantity, Order_id, Product_id) VALUES (@quantity, @orderid, @prod_id)";
        public const string DeleteOrderItem = "DELETE FROM OrderItem WHERE OrderItem_id=@id";
        public const string SelectProdIdString = "SELECT Product_id FROM Product WHERE ProductName = @name";


    }
}
