using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ClientModel.Entities;

namespace Client.ClientModel.Commands
{
    public class CommandList:IList<Command>
    {
        private List<Command> commandList;
        public CommandList()
        {
            commandList = new List<Command>();
        }
        public CommandList(List<Command> newList)
        {
            commandList = newList;
        }
        public int IndexOf(Command item)
        {
            return commandList.IndexOf(item);
        }
        /// <summary>
        /// Don't use this method. Commands must follow a strict sequence
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, Command item)
        {
            Command same = ContainsTheSameChange(item);
            if (same != null)
            {
                commandList.Remove(same);
            }
            commandList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            commandList.RemoveAt(index);
        }

        public Command this[int index]
        {
            get
            {
                return commandList[index];
            }
            set
            {
                commandList[index] = value;
            }
        }

        public void Add(Command item)
        {
            Command same = ContainsTheSameChange(item);
            if (same != null)
            {
                commandList.Remove(same);
            }
            commandList.Add(item);
        }

        public void Clear()
        {
            commandList.Clear();
        }

        public bool Contains(Command item)
        {
            return commandList.Contains(item);
        }

        public void CopyTo(Command[] array, int arrayIndex)
        {
            commandList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return commandList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Command item)
        {
            return commandList.Remove(item);
        }

        public IEnumerator<Command> GetEnumerator()
        {
            return commandList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return commandList.GetEnumerator();
        }
        /// <summary>
        /// Checks if the list contains the same changes
        /// </summary>
        /// <param name="item">New command</param>
        /// <returns>Command which has the same changes, null otherwise</returns>
        Command ContainsTheSameChange(Command item)
        {
            foreach (var command in commandList)
            {
                if (command.Entity == item.Entity && command.CommandType == item.CommandType && command.FieldName == item.FieldName)
                {
                    return command;
                }
            }
            return null;
        }
        /// <summary>
        /// Adds the create order command to list of commands
        /// </summary>
        public void AddCreateOrderCommand(ClientOrder order)
        {
            Command createOrderCommand = new Command();
            createOrderCommand.Entity = order;
            createOrderCommand.CommandType = CommandType.Create;
            commandList.Add(createOrderCommand);
        }
        /// <summary>
        /// Adds the update urder command to list of commands
        /// </summary>
        /// <param name="fieldName">Field name</param>
        /// <param name="value">New value of the specified field</param>
        public void AddUpdateOrderCommand(ClientOrder order, string fieldName, object value)
        {
            Command updateOrderCommand = new Command();
            updateOrderCommand.Entity = order;
            updateOrderCommand.CommandType = CommandType.Update;
            updateOrderCommand.FieldName = fieldName;
            updateOrderCommand.Value = value;
            commandList.Add(updateOrderCommand);
        }
        /// <summary>
        ///  Adds the remove urder command to list of commands
        /// </summary>
        /// <param name="clientOrder">The order which should be removed</param>
        public void AddRemoveOrderCommand(ClientOrder clientOrder)
        {
            Command removeOrderCommand = new Command();
            removeOrderCommand.Entity = clientOrder;
            removeOrderCommand.CommandType = CommandType.Delete;
            foreach (var item in clientOrder.Products)
            {
                AddRemoveOrderItemCommand(item);
            }
            commandList.Add(removeOrderCommand);
        }
        /// <summary>
        /// Adds the create order item command to list of commands
        /// </summary>
        /// <param name="clientOrderItem">Order item</param>
        public void AddCreateOrderItemCommand(ClientOrderItem clientOrderItem)
        {
            Command createOrderItemCommand = new Command();
            createOrderItemCommand.Entity = clientOrderItem;
            createOrderItemCommand.CommandType = CommandType.Create;
            commandList.Add(createOrderItemCommand);
        }
        /// <summary>
        /// Adds the update order item command
        /// </summary>
        /// <param name="clientOrderItem">Order item which should be updated</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="value">New value of the specified field</param>
        public void AddUpdateOrderItemCommand(ClientOrderItem clientOrderItem, string fieldName, object value)
        {
            Command updateOredItemCommand = new Command();
            updateOredItemCommand.Entity = clientOrderItem;
            updateOredItemCommand.CommandType = CommandType.Update;
            updateOredItemCommand.FieldName = fieldName;
            updateOredItemCommand.Value = value;
            commandList.Add(updateOredItemCommand);
        }
        /// <summary>
        /// Adds the remove order item command
        /// </summary>
        /// <param name="clientOrderItem">Order item which should be removed</param>
        public void AddRemoveOrderItemCommand(ClientOrderItem clientOrderItem)
        {
            bool thisTransactionCreated = false;
            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Entity == clientOrderItem)
                {
                    if (commandList[i].CommandType == CommandType.Delete)
                        return;
                    else
                    {
                        if (commandList[i].CommandType == CommandType.Create)
                            thisTransactionCreated = true;
                        commandList.Remove(commandList[i]);
                        i--;
                    }
                }
            }
            if (!thisTransactionCreated)
            {
                Command removeOrderItemCommand = new Command();
                removeOrderItemCommand.Entity = clientOrderItem;
                removeOrderItemCommand.CommandType = CommandType.Delete;
                commandList.Add(removeOrderItemCommand);
            }
        }
    }
}
