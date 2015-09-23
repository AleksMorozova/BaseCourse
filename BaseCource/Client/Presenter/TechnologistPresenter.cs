using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.View;
using Contracts;
using DomainModel.Entities;

namespace Client.Presentor
{
    public class TechnologistPresenter
    {
        ITechnologistView technologistView;
        IContract technologistContract;

        public TechnologistPresenter (ITechnologistView technologistView, IContract technologistContract)
        {
            this.technologistView = technologistView;
            this.technologistContract = technologistContract;
        }
        /// <summary>
        /// Fills the order list
        /// </summary>
        public void FillOrderList()
        {
            technologistView.Orders = technologistContract.GetAllOrders();
            
            foreach (var item in technologistView.Orders)
            {
                GetOrderItems(item);
            }
        }
        /// <summary>
        /// Fills the otrder items list of the order with specified ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        void FillOrderItemsList(int orderID)
        {
            technologistView.Orders.First(oi => oi.Id == orderID).Items = technologistContract.GetOrderItems(orderID);
        }
        /// <summary>
        /// Gets the otrder items list of the specified order
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <returns>The list of order items</returns>
        public List<OrderItem> GetOrderItems(Order order)
        {
            if (technologistView.Orders.FirstOrDefault(o => o == order) != null)
            {
                if (order.Items == null && order.Id != 0)
                    FillOrderItemsList(order.Id);
                return technologistView.Orders.First(oi => oi.Id == order.Id).Items.ToList();
            }
            else
            {
                throw new ArgumentException("The specified order is not at the order list");
            }
        }
    }
}
