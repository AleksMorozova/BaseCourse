using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Client.ClientModel.Entities;
using Client.Translator;
using DomainModel.Entities;
using Client.Exceptions;
using System.ComponentModel;

namespace Client.ClientModel.Commands
{
    class CommandListParser
    {
        IContract contract;
        CommandList commandList;
        ClientOrder order;
        User user;
        public CommandListParser(IContract contract, CommandList commandList, User user)
        {
            this.contract = contract;
            this.commandList = commandList;
            this.user=user;
        }
        public CommandListParser(IContract contract, CommandList commandList, ClientOrder order, User user)
        {
            this.contract = contract;
            this.commandList = commandList;
            this.order = order;
            this.user = user;
        }
        public void Parse()
        {
            if(commandList!=null&&commandList.Count>0)
                foreach (Command command in commandList)
                {
                    if (command.Entity is ClientOrder)
                    {
                        ParseClientOrderCommand(command);
                    }
                    else
                    {
                        if (command.Entity is ClientOrderItem)
                            ParseClientOrderItemCommand(command, order);
                    }
                }
        }
        void ParseClientOrderCommand(Command command)
        {
            if (command.Entity as ClientOrder == null)
                throw new ArgumentException("Command has incorrect entity type. The entity should be ClientOrder", "command");
            switch (command.CommandType)
            {
                case CommandType.Create:
                    {
                        Order tmpOrder = EntitiesTranslator.TranslateToOrder((ClientOrder)command.Entity,user);
                        tmpOrder.Items.Clear();
                        ClientOrder newOrder = EntitiesTranslator.TranslateToClientOrder(contract.SaveNewOrder(tmpOrder));
                        ((ClientOrder)command.Entity).Id = newOrder.Id;
                        ((ClientOrder)command.Entity).PlacingDate = newOrder.PlacingDate;
                        ((ClientOrder)command.Entity).Status = newOrder.Status;
                        if (order == null)
                            order = newOrder;
                        return;
                    }
                case CommandType.Delete:
                    {
                        Order tmpOrder = EntitiesTranslator.TranslateToOrder((ClientOrder)command.Entity,user);
                        tmpOrder.Items.Clear();
                        contract.RemoveOrder(tmpOrder);
                        return;
                    }
                case CommandType.Update:
                    {
                        if (command.FieldName == "Status")
                        {
                            contract.ChangeOrderStatus(command.Entity.Id, (Status)command.Value);
                        }
                        else
                        {
                            throw new UnknownFieldNameException("Parser cannot recognize the field " + command.FieldName);
                        }
                        return;
                    }
            }
        }
        void ParseClientOrderItemCommand(Command command, ClientOrder order)
        {
            if (command.Entity as ClientOrderItem == null)
                throw new ArgumentException("Command has incorrect entity type. The entity should be ClientOrderItem", "command");
            switch (command.CommandType)
            {
                case CommandType.Create:
                    {
                        BindingList<ClientOrderItem> products = order.Products;
                        order.Products.Clear();
                        contract.SaveNewOrderItem(EntitiesTranslator.TranslateToOrderItem((ClientOrderItem)command.Entity, EntitiesTranslator.TranslateToOrder(order,user)));
                        order.Products = products;
                        return;
                    }
                case CommandType.Delete:
                    {
                        contract.RemoveOrderItem(contract.GetOrderItem(order.Id, command.Entity.Id));
                        return;
                    }
                case CommandType.Update:
                    {
                        if (command.FieldName == "Count")
                        {
                            contract.ChangeOrderItemCount(contract.GetOrderItem(order.Id, command.Entity.Id).Id, (int)command.Value);
                        }
                        return;
                    }
            }
        }
    }
}
