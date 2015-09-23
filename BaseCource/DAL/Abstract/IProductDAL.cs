using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DAL.Abstract
{
    public interface IProductDAL
    {
        /// <summary>
        /// Gets all products from data source
        /// </summary>
        /// <returns>All products which contain at the data source</returns>
        List<Product> GetAllProducts();
    }
}
