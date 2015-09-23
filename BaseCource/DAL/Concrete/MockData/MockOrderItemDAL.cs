using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Abstract;
using DomainModel.Entities;

namespace DAL.Concrete.MockData
{
    public class MockOrderItemDAL:IOrderItemDAL
    {
        public void SaveOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public IList<OrderItem> GetOrderItems(int orderID)
        {
            List<OrderItem> result = new List<OrderItem>();
            //if (orderID == 1)
            //{
            //    result.Add(new OrderItem() { Id = 1, Order_Id = 1, Count = 2, Product = new Product() { Id = 123, Name = "Молоко литровое", Prices = new List<ProductPrice>(), Units = 2 } });
            //    result.Add(new OrderItem() { Id = 2, Order_Id = 1, Count = 5, Product = new Product() { Id = 1233, Name = "Танк деревянный", Prices = new List<ProductPrice>(), Units = 3 } });
            //}
            //if (orderID == 2)
            //{
            //    result.Add(new OrderItem() { Id = 3, Order_Id = 2, Count = 3, Product = new Product() { Id = 33, Name = "Сковорода", Prices = new List<ProductPrice>(), Units = 2 } });
            //    result.Add(new OrderItem() { Id = 4, Order_Id = 2, Count = 2, Product = new Product() { Id = 6243, Name = "Бензин А-95", Prices = new List<ProductPrice>(), Units = 2 } });
            //}
            return result;
        }


        public void SaveNewOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetOrderItem(int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void ChangeOrderItemCount(int orderItemId, int newCount)
        {
            throw new NotImplementedException();
        }
    }
}
