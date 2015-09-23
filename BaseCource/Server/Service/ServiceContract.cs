using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using DomainModel.Entities;
using DAL.Abstract;
using DAL.Concrete.NHibernate;
using Spring.Context.Support;

namespace Server.Service
{
    public class ServiceContract : IContract
    {
        IUserDAL userDAL;
        IOrderDAL orderDAL;
        IOrderItemDAL orderItemDAL;
        IProductDAL productDAL;
        static ServiceContract()
        {
            ContextRegistry.RegisterContext(new XmlApplicationContext("../../../DataAccessLayerSetup.xml"));
        }
        public ServiceContract()
        {
            userDAL = (IUserDAL)ContextRegistry.GetContext().GetObject("UserDAL");
            orderDAL = (IOrderDAL)ContextRegistry.GetContext().GetObject("OrderDAL");
            orderItemDAL = (IOrderItemDAL)ContextRegistry.GetContext().GetObject("OrderItemDAL");
            productDAL = (IProductDAL)ContextRegistry.GetContext().GetObject("ProductDAL");
        }
        public User GetUser(string login, string password)
        {
            return userDAL.GetUser(login, password);
        }
        public IList<Order> GetOrderList(int userID)
        {
            return orderDAL.GetOrders(userID);
        }

        public IList<OrderItem> GetOrderItems(int orderID)
        {
            return orderItemDAL.GetOrderItems(orderID);
        }


        public IList<Product> GetProducts()
        {
            return productDAL.GetAllProducts();
        }

        public IList<Order> GetAllOrders ()
        {
            return orderDAL.GetAllOrders();
        }


        public Order SaveNewOrder(Order order)
        {
            return orderDAL.SaveNewOrder(order);
        }

        public void RemoveOrder(Order order)
        {
            orderDAL.RemoveOrder(order);
        }

        public void ChangeOrderStatus(int orderId, Status newStatus)
        {
            orderDAL.ChangeOrderStatus(orderId, newStatus);
        }

        public void SaveNewOrderItem(OrderItem orderItem)
        {
            orderItemDAL.SaveNewOrderItem(orderItem);
        }

        public OrderItem GetOrderItem(int orderId, int productId)
        {
            return orderItemDAL.GetOrderItem(orderId, productId);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            orderItemDAL.RemoveOrderItem(orderItem);
        }

        public void ChangeOrderItemCount(int orderItemId, int newCount)
        {
            orderItemDAL.ChangeOrderItemCount(orderItemId, newCount);
        }
    }
}
