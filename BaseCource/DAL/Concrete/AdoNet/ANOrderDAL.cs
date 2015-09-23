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
    class ANOrderDAL : IOrderDAL
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(ANOrderDAL));

        public IList<OrderItem> GetOrderItems(int orderID, SqlCeConnection conn)
        {
            IList<OrderItem> ItemList = new List<OrderItem>();

            try
            {
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
                    orderItem.Order = GetOrder((int)dr[2], conn);
                    orderItem.Product = GetProduct((int)dr[3], conn);

                    ItemList.Add(orderItem);

                }

                return ItemList;
            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }
        //Interfase
        public IList<Order> GetOrders(int userID)
        {
            IList<Order> OrderList = new List<Order>();

            SqlCeConnection conn = SQLQueryString.connection;

            conn.Open();



            try
            {

                string commandText = SQLQueryString.SelectOrderString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", userID);

                SqlCeDataReader dr = cmd.ExecuteReader();

                Order ord;

                while (dr.Read())
                {

                    IList<OrderItem> OrderItem = GetOrderItems((int)dr[0], conn);

                    ord = new Order();
                    ord.Id = (int)dr[0];
                    ord.PlacingDate = (DateTime)dr[1];
                    ord.Status = (Status)dr[2];
                    ord.User = GetUser((int)dr[3], conn);
                    OrderList.Add(ord);

                }

                return OrderList;

            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }



            finally
            {
                conn.Close();

            }
        }

        public Product GetProduct(int prodID, SqlCeConnection conn)
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

        //Interfase
        public IList<Order> GetAllOrders()
        {
            IList<Order> OrderList = new List<Order>();

            SqlCeConnection conn = SQLQueryString.connection;

            conn.Open();

            try
            {

                string commandText = SQLQueryString.SelectAllOrderString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);


                SqlCeDataReader dr = cmd.ExecuteReader();

                Order ord;

                while (dr.Read())
                {

                    IList<OrderItem> OrderItem = GetOrderItems((int)dr[0], conn);
                    ord = new Order();
                    ord.Id = (int)dr[0];
                    ord.PlacingDate = (DateTime)dr[1];
                    ord.Status = (Status)dr[2];
                    ord.User = GetUser((int)dr[3], conn);
                    OrderList.Add(ord);


                }

                return OrderList;

            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }

            finally
            {
                conn.Close();

            }
        }

        public User GetUser(int id, SqlCeConnection conn)
        {
            try
            {
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

        public int GetOrderID(DateTime date, SqlCeConnection conn)
        {

            try
            {
                string commandText1 = " SELECT Order_id From [Order] Where PlacingDate=@date";

                SqlCeCommand cmd = new SqlCeCommand(commandText1, conn);

                cmd.Parameters.AddWithValue("@date", date);

                SqlCeDataReader dr = cmd.ExecuteReader();
                int newid = 0;
                while (dr.Read())
                {
                    newid = (int)dr[0];


                    return newid;
                }

                return newid;

            }

            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return 0;
            }

        }

        public Order SaveNewOrder(Order order)
        {
            SqlCeConnection conn = SQLQueryString.connection;
            conn.Open();
            DateTime date = DateTime.Now;

            try
            {

                string commandText = SQLQueryString.InsertOrderString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@status", order.Status);

                cmd.Parameters.AddWithValue("@user", order.User.Id);
                cmd.ExecuteNonQuery();

                Order neworder = new Order();

                neworder.Id = GetOrderID(date, conn);
                neworder.PlacingDate = date;
                neworder.Status = order.Status;
                neworder.User = GetUser(order.User.Id, conn);
               
                return neworder;
            }

            finally
            {
                conn.Close();
            }

        }

        public void RemoveOrder(Order order)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            try
            {
                conn.Open();

                string commandText = SQLQueryString.DeleteOrderString;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@id", order.Id);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Data has been successfully deleted!");

            }

            finally
            {
                conn.Close();
            }

        }

        public void ChangeOrderStatus(int orderId, Status newStatus)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            conn.Open();
            try
            {

                string commandText = SQLQueryString.UpdateOrderString;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", orderId);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Data has been successfully updated!");

            }

            finally
            {
                conn.Close();
            }
        }
    }
}
