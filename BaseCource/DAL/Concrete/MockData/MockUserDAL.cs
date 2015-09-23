using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Abstract;
using DomainModel.Entities;

namespace DAL.Concrete.MockData
{
    public class MockUserDAL:IUserDAL
    {
        public User GetUser(string login, string password)
        {
            if (login == "Vasya" && password == "123456")
            {
                return new User() { Login = login, Password = password, Name = "Vasya Pupkin", Role = Role.Customer, Id = 1 };
            }
            return null;
        }
    }
}
