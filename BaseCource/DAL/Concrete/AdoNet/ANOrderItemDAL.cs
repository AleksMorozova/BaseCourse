using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DomainModel.Entities;
using DAL.Abstract;
using System.Data;
using System.Data.SqlServerCe;
using NativeSQLviaADO;
using log4net;

namespace DAL.Concrete.AdoNet
{
    class ANOrderItemDAL : IOrderItemDAL
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(ANOrderItemDAL));
        public void SaveOrderItems(OrderItem orderItem)
        {

            SqlCeConnection conn = SQLQueryString.connection;
            conn.Open();

            string commandText = SQLQueryString.InsertOrderItem;

            SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

            cmd.Parameters.AddWithValue("@quantity", orderItem.Count);
            cmd.Parameters.AddWithValue("@orderid", orderItem.Order.Id);
            cmd.Parameters.AddWithValue("@prod_id", orderItem.Product.Id);

            try
            {
                cmd.ExecuteNonQuery();
                log.Info("Data has been successfully added!");
            }
            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return;
            }
        }

        public IList<OrderItem> GetOrderItems(int orderID)
        {
            IList<OrderItem> ItemList = new List<OrderItem>();

            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();

                string commandText = SQLQueryString.SelectOrderItemString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", orderID);

                SqlCeDataReader dr = cmd.ExecuteReader();

                OrderItem orderItem;

                while (dr.Read())
                {
                    orderItem = new OrderItem();

                    orderItem.Id = (int)dr[0];
                    orderItem.Count = (int)dr[1];

                    DateTime date = FindDate((int)dr[2], conn);
                    orderItem.Product = GetProduct((int)dr[3], date, conn);

                    ItemList.Add(orderItem);
                }

                return ItemList;

            }

            finally
            {
                conn.Close();
            }


        }

        public Product GetProduct(int prodID, DateTime placingdate, SqlCeConnection conn)
        {
            IList<Product> ProductList = new List<Product>();

            try
            {
                string commandText = SQLQueryString.SelectProductList;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@id", prodID);
                SqlCeDataReader dr = cmd.ExecuteReader();

                Product prod;

                while (dr.Read())
                {

                    prod = new Product();
                    prod.Id = (int)dr[0];
                    prod.Name = dr[1].ToString();
                    prod.Units = (int)dr[2];
                    prod.Price = CurrentPrice((int)dr[0], placingdate, conn);

                    ProductList.Add(prod);

                    return prod;
                }

                return null;
            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void SaveNewOrderItem(OrderItem orderItem)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();

                string commandText = SQLQueryString.InsertOrderItem;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@quantity", orderItem.Count);
                cmd.Parameters.AddWithValue("@orderid", orderItem.Order.Id);
                cmd.Parameters.AddWithValue("@prod_id", orderItem.Product.Id);

                cmd.ExecuteNonQuery();

                log.Info("Data has been successfully added!");
            }

            finally
            {
                conn.Close();
            }
        }

        public OrderItem GetOrderItem(int orderId, int productId)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();

                string commandText = SQLQueryString.SelectOrderItemString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.Parameters.AddWithValue("@prodid", productId);

                SqlCeDataReader dr = cmd.ExecuteReader();

                OrderItem orderItem;

                while (dr.Read())
                {
                    orderItem = new OrderItem();

                    orderItem.Id = (int)dr[0];
                    orderItem.Count = (int)dr[1];
                    orderItem.Order = GetOrder((int)dr[2], conn);
                    DateTime date = FindDate((int)dr[2], conn);
                    orderItem.Product = GetProduct((int)dr[3], date, conn);

                    return orderItem;

                }

                return null;

            }

            finally
            {
                conn.Close();
            }
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();
                string commandText = SQLQueryString.DeleteOrderItem;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@id", orderItem.Id);

                cmd.ExecuteNonQuery();

                log.Info("Data has been successfully deleted!");

            }

            finally
            {
                conn.Close();
            }
        }

        public void ChangeOrderItemCount(int orderItemId, int newCount)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();
                string commandText = SQLQueryString.UpdateOrderItem;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@quantity", newCount);
                cmd.Parameters.AddWithValue("@id", orderItemId);

                cmd.ExecuteNonQuery();

                log.Info("Data has been successfully updated!");

            }

            finally
            {
                conn.Close();
            }
        }

        public Order GetOrder(int orderID, SqlCeConnection conn)
        {

            try
            {

                string commandText = SQLQueryString.SelectOrderbyID;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", orderID);

                SqlCeDataReader dr = cmd.ExecuteReader();

                Order ord;

                while (dr.Read())
                {
                    ord = new Order();
                    ord.Id = (int)dr[0];
                    ord.PlacingDate = (DateTime)dr[1];
                    ord.Status = (Status)dr[2];
                    ord.User = GetUser((int)dr[3], conn);

                    return ord;
                }

                return null;

            }
            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public User GetUser(int id, SqlCeConnection conn)
        {

            try
            {
                conn.Open();
                string commandText = SQLQueryString.SelectUsers;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", id);


                SqlCeDataReader dr = cmd.ExecuteReader();

                User user;

                if (dr.Read())
                {
                    user = new User();

                    user.Id = (int)dr[0];
                    user.Name = (string)dr[1];
                    user.Role = (Role)dr[2];
                    user.Login = (string)dr[3];
                    user.Password = (string)dr[4];
                    return user;
                }

                return null;
            }


            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public List<ProductPrice> GetProductPrice(int prodID, SqlCeConnection conn)
        {
            List<ProductPrice> PriceList = new List<ProductPrice>();

            try
            {
                string commandText = SQLQueryString.SelectPriceString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", prodID);

                SqlCeDataReader dr = cmd.ExecuteReader();

                ProductPrice price;

                while (dr.Read())
                {

                    price = new ProductPrice();

                    price.Price = (int)dr[1];
                    price.EffectiveDate = (DateTime)dr[2];

                    PriceList.Add(price);
                }

                return PriceList;

            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public ProductPrice CurrentPrice(int prodID, DateTime date, SqlCeConnection conn)
        {

            List<ProductPrice> PriceList = new List<ProductPrice>();
            PriceList = GetProductPrice(prodID, conn);
            ProductPrice productprice;

            List<ProductPrice> SortedList = PriceList.OrderBy(o => o.EffectiveDate).ToList();

            for (int i = 0; i <= SortedList.Count - 1; i++)
            {

                if (SortedList[i].EffectiveDate >= date)
                {

                    productprice = new ProductPrice();
                    productprice.Price = SortedList[i].Price;
                    productprice.EffectiveDate = SortedList[i].EffectiveDate;
                    productprice.Id = SortedList[i].Id;
                    productprice.Product = SortedList[i].Product;

                    //Console.WriteLine("Price" + productprice.Price);

                    return productprice;
                }

                else
                {
                    productprice = new ProductPrice();
                    productprice.Price = 0;
                    productprice.EffectiveDate = SortedList[i].EffectiveDate;
                    productprice.Id = SortedList[i].Id;
                    productprice.Product = SortedList[i].Product;

                    //Console.WriteLine("Price" + productprice.Price);

                    return productprice;
                }

            }

            return null;
        }

        public static DateTime FindDate(int ordid, SqlCeConnection conn)
        {
            try
            {
                DateTime date = new DateTime(2000, 1, 1, 1, 1, 1);
                string commandText = SQLQueryString.Selectdate;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", ordid);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    date = (DateTime)dr[0];

                    return date;

                }

                return date;

            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return DateTime.Now;
            }

        }
    }
}
