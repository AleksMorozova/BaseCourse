using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DAL.Abstract
{
    public interface IOrderDAL
    {
        /// <summary>
        /// Gets the list of orders of the user with specidied ID
        /// </summary>
        /// <param name="userID">User DI</param>
        /// <returns>The list of orders</returns>
        IList<Order> GetOrders(int userID);

        /// <summary>
        /// Gets the list of all orders 
        /// </summary>
        /// <returns>The list of orders</returns>
        IList<Order> GetAllOrders();
        /// <summary>
        /// Saves new order
        /// </summary>
        /// <param name="order">New order</param>
        /// <returns>New order with updated field</returns>
        Order SaveNewOrder(Order order);
        /// <summary>
        /// Remove specified order
        /// </summary>
        /// <param name="order">Order</param>
        void RemoveOrder(Order order);
        /// <summary>
        /// Changes order status
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="newStatus">New status</param>
        void ChangeOrderStatus(int orderId, Status newStatus);
    }
}
