using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DAL.Abstract
{
    public interface IOrderItemDAL
    {
        /// <summary>
        /// Saves order item to database
        /// </summary>
        /// <param name="orderItem">Order item which should be saved</param>
       
        /// <summary>
        /// Gets the order items of the order with specified ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <returns>The list of order items</returns>
        IList<OrderItem> GetOrderItems(int orderID);
        /// <summary>
        /// Saves new order item to datasource
        /// </summary>
        /// <param name="orderItem">Order item which should be saved</param>
        void SaveNewOrderItem(OrderItem orderItem);
        /// <summary>
        /// Gets an order item with specified parameters
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="productId">Product ID</param>
        /// <returns>Order itmem with specified parameters</returns>
        OrderItem GetOrderItem(int orderId, int productId);
        /// <summary>
        /// Removes order item from datasource
        /// </summary>
        /// <param name="orderItem">Order item which should be removed</param>
        void RemoveOrderItem(OrderItem orderItem);
        /// <summary>
        /// Changes order item count
        /// </summary>
        /// <param name="orderItemId">Order item ID</param>
        /// <param name="newCount">New count</param>
        void ChangeOrderItemCount(int orderItemId, int newCount);
    }
}
