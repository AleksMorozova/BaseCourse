using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ClientModel.Entities;
using DomainModel.Entities;

namespace Client.Translator
{
    public static class EntitiesTranslator
    {
        public static ClientOrder TranslateToClientOrder(Order order)
        {
            if (order != null)
            {
                ClientOrder clientOrder = new ClientOrder(order.Id);
                clientOrder.PlacingDate = order.PlacingDate;
                clientOrder.Status = order.Status;
                if (order.Items != null)
                {
                    clientOrder.Products = new System.ComponentModel.BindingList<ClientOrderItem>();
                    foreach (var item in order.Items)
                    {
                        clientOrder.Products.Add(TranslateToClientOrderItem(item));
                    }
                }
                return clientOrder;
            }
            return null;
        }
        public static ClientOrderItem TranslateToClientOrderItem(OrderItem orderItem)
        {
            if (orderItem != null&&orderItem.Product!=null)
            {
                ClientOrderItem clientOrderItem = new ClientOrderItem(orderItem.Product.Id);
                clientOrderItem.Name = orderItem.Product.Name;
                clientOrderItem.Count = orderItem.Count;
                clientOrderItem.Price = orderItem.Product.Price.Price;
               
                return clientOrderItem;
            }
            return null;
        }
        public static Order TranslateToOrder(ClientOrder clientOrder, User user)
        {
            if (clientOrder != null)
            {
                Order order = new Order();
                order.Id = clientOrder.Id;
                order.PlacingDate = clientOrder.PlacingDate;
                order.Status = clientOrder.Status;
                order.User = user;
                if (clientOrder.Products != null)
                {
                    order.Items = new List<OrderItem>();
                    for (int i = 0; i < clientOrder.Products.Count; i++)
                    {
                        order.Items.Add(TranslateToOrderItem(clientOrder.Products[i], order));
                    }
                }
                return order;
            }
            return null;
        }
        public static Order TranslateToOrder(ClientOrder clientOrder)
        {
            return TranslateToOrder(clientOrder, null);
        }
        public static OrderItem TranslateToOrderItem(ClientOrderItem clientOrderItem, Order order)
        {
            if (clientOrderItem != null)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.Product = new Product();
                orderItem.Product.Id = clientOrderItem.Id;
                orderItem.Product.Name = clientOrderItem.Name;
                orderItem.Count = clientOrderItem.Count;
                orderItem.Order = order;
                return orderItem;
            }
            return null;
        }
        public static OrderItem TranslateToOrderItem(ClientOrderItem clientOrderItem)
        {
            return TranslateToOrderItem(clientOrderItem, null);
        }
    }
}
