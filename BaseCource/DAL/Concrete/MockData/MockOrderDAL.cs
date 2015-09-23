using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Abstract;
using DomainModel.Entities;

namespace DAL.Concrete.MockData
{
    public class MockOrderDAL :IOrderDAL
    {
        public IList<DomainModel.Entities.Order> GetOrders(int userID)
        {
            List<Order> result = new List<Order>();
            switch (userID)
            {
                case 1:
                    {
                        //result.Add(new Order() { Status = Status.Deliver, PlacingDate = DateTime.Parse("12/4/2013"), Id = 1, Users_Id=1 });
                        //result.Add(new Order() { Status = Status.Confirmed, PlacingDate = DateTime.Parse("2/4/2014"), Id = 2, Users_Id=1 });
                        break;
                    }
            }
            return result;
        }

        #region Члены IOrderDAL


        public IList<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        #endregion


        public Order SaveNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void ChangeOrderStatus(int orderId, Status newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
