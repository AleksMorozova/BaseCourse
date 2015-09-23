using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Abstract;
using DomainModel.Entities;

namespace DAL.Concrete.MockData
{
    public class MockProductDAL:IProductDAL
    {
        public List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            result.Add(new Product() { Id = 1, Name = "First Mock Product" });
            result.Add(new Product() { Id = 2, Name = "Second Mock Product" });
            result.Add(new Product() { Id = 3, Name = "Third Mock Product" });
            return result;
        }
    }
}
