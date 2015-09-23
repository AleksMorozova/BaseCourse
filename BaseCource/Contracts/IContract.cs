using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        User GetUser(string login, string password);
        /// <summary>
        /// Gets the list of orders of the user with specified ID
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>List of orders</returns>
        [OperationContract]
        IList<Order> GetOrderList(int userID);
        /// <summary>
        /// Gets the list of order items of the order with the specified ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <returns>List of order items</returns>
        [OperationContract]
        IList<OrderItem> GetOrderItems(int orderID);
        /// <summary>
        /// Gets all products from source
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<Product> GetProducts();
        /// <summary>
        /// Gets all orders from source
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<Order> GetAllOrders();
        /// <summary>
        /// Saves new order to source
        /// </summary>
        /// <param name="order">Order which should be saved</param>
        [OperationContract]
        Order SaveNewOrder(Order order);
        /// <summary>
        /// Removes an order from source
        /// </summary>
        /// <param name="order">Order which should be removed</param>
        [OperationContract]
        void RemoveOrder(Order order);
        /// <summary>
        /// Changes order status
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="newStatus">New status</param>
        [OperationContract]
        void ChangeOrderStatus(int orderId, Status newStatus);
        /// <summary>
        /// Saves new order item to source
        /// </summary>
        /// <param name="orderItem">Order item which should be saved</param>
        [OperationContract]
        void SaveNewOrderItem(OrderItem orderItem);
        /// <summary>
        /// Gets an order item with specified parameters
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="productId">Product ID</param>
        /// <returns>Order itmem with specified parameters</returns>
        [OperationContract]
        OrderItem GetOrderItem(int orderId, int productId);
        /// <summary>
        /// Removes order item from source
        /// </summary>
        /// <param name="orderItem">Order item which should be removed</param>
        [OperationContract]
        void RemoveOrderItem(OrderItem orderItem);
        /// <summary>
        /// Changes order item count
        /// </summary>
        /// <param name="orderItemId">Order item ID</param>
        /// <param name="newCount">New count</param>
        [OperationContract]
        void ChangeOrderItemCount(int orderItemId, int newCount);
    }
}
