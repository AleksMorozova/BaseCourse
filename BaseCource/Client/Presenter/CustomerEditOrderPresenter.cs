using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.View;
using Contracts;
using DomainModel.Entities;
using Client.ClientModel.Commands;
using Client.ClientModel.Entities;

namespace Client.Presentor
{
    public class CustomerEditOrderPresenter
    {
        ICustomerEditOrderView customerEditOrderView;
        IContract contract;
        public CommandList CommandList { get; protected set; }
        public CustomerEditOrderPresenter(ICustomerEditOrderView view, IContract contract)
        {
            this.contract = contract;
            this.customerEditOrderView = view;
            this.customerEditOrderView.ShowOrderInfo();
            CommandList = new CommandList();
        }
        public IList<Product> GetAllProducts()
        {
            return contract.GetProducts();
        }
        public void AddOrderItemToOrder(Product product, int count, ClientOrder order)
        {
            if(product==null)
                throw new ArgumentException("A product with the specified ID not found", "productId");
            if (count <= 0)
                throw new ArgumentException("Count should be greatest then zero", "count");
            
                ClientOrderItem existingOrderItem = order.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingOrderItem != null)
                {
                    existingOrderItem.Count += count;
                    Command command = CommandList.FirstOrDefault(c => c.Entity == existingOrderItem && c.FieldName == "Count" && c.CommandType == CommandType.Update);
                    if (command != null)
                    {
                        command.Value = existingOrderItem.Count;
                    }
                    else
                    {
                        CommandList.AddUpdateOrderItemCommand(existingOrderItem, "Count", existingOrderItem.Count);
                    }
                    order.Products.ResetItem(order.Products.IndexOf(existingOrderItem));
                }
                else
                {
                    ClientOrderItem orderItem = new ClientOrderItem(product.Id);
                    orderItem.Count = count;
                    orderItem.Price = product.Price.Price;
                    orderItem.Name = product.Name;
                    order.Products.Add(orderItem);
                    CommandList.AddCreateOrderItemCommand(orderItem);
                    CommandList.AddUpdateOrderItemCommand(orderItem, "Count", orderItem.Count);
                }
        }
        public void RemoveOrderItemFromOrder(ClientOrderItem orderItem)
        {
            CommandList.AddRemoveOrderItemCommand(orderItem);
            customerEditOrderView.Order.Products.Remove(orderItem);
        }
        public void RemoveOrder()
        {
            bool thisTransactionCreated = false;
            foreach (var item in CommandList)
            {
                if (item.Entity == customerEditOrderView.Order && item.CommandType == CommandType.Create)
                {
                    thisTransactionCreated = true;
                    break;
                }
            }
            CommandList.Clear();
            if (!thisTransactionCreated)
            {
                if (customerEditOrderView.Order.Products != null)
                {
                    foreach (var item in customerEditOrderView.Order.Products)
                    {
                        CommandList.AddRemoveOrderItemCommand(item);
                    }
                }
                CommandList.AddRemoveOrderCommand(customerEditOrderView.Order);
                SendCommandList();
            }
        }
        public void SetOrderSatusToNew()
        {
            CommandList.AddUpdateOrderCommand(customerEditOrderView.Order, "Status", Status.New);
        }
        public void SendCommandList()
        {
            CommandListParser parser = new CommandListParser(contract, CommandList, customerEditOrderView.Order,customerEditOrderView.Customer);
            parser.Parse();
            CommandList.Clear();
        }
    }
}
