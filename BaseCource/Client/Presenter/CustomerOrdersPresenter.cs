using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.View;
using Contracts;
using DomainModel.Entities;
using Client.ClientModel.Entities;
using Client.Translator;
using System.ComponentModel;

namespace Client.Presentor
{
    public class CustomerOrdersPresenter
    {
        ICustomerOrdersView customerOrderView;
        IContract customerContract;

        public CustomerOrdersPresenter(ICustomerOrdersView customerOrderView, IContract customerContract)
        {
            this.customerOrderView = customerOrderView;
            this.customerContract = customerContract;
        }
        /// <summary>
        /// Fills the order list
        /// </summary>
        public void FillOrderList()
        {
            List<Order> orders = customerContract.GetOrderList(customerOrderView.Customer.Id).ToList();
            customerOrderView.Orders = new List<ClientOrder>();
            foreach (var order in orders)
            {
                customerOrderView.Orders.Add(EntitiesTranslator.TranslateToClientOrder(order));
            }
            foreach (var item in customerOrderView.Orders)
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
            List<OrderItem> orderItems = customerContract.GetOrderItems(orderID).ToList();
            ClientOrder order = customerOrderView.Orders.First(oi => oi.Id == orderID);
            order.Products = new BindingList<ClientOrderItem>();
            foreach (var item in orderItems)
            {
                order.Products.Add(EntitiesTranslator.TranslateToClientOrderItem(item));
            }
        }
        /// <summary>
        /// Gets the otrder items list of the specified order
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <returns>The list of order items</returns>
        public List<ClientOrderItem> GetOrderItems(ClientOrder order)
        {
            if (customerOrderView.Orders.FirstOrDefault(o => o == order) != null)
            {
                if (order.Products == null && order.Id != 0)
                    FillOrderItemsList(order.Id);
                return customerOrderView.Orders.First(oi => oi.Id == order.Id).Products.ToList();
            }
            else
            {
                throw new ArgumentException("The specified order is not at the order list");
            }
        }
    }
}
