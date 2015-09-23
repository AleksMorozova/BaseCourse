using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DomainModel.Entities;
using DAL.Abstract;
using System.Data;
using System.Data.SqlServerCe;
using NativeSQLviaADO;
using DAL.Concrete.AdoNet;

namespace DAL.Concrete.AdoNet
{
    class ANProductDAL : IProductDAL   
    {
        public List<Product> GetAllProducts()
        {
            List<Product> ProductList = new List<Product>();

            SqlCeConnection conn = new SqlCeConnection(SQLQueryString.ConnStr);

            conn.Open();

            try
            {

                Console.WriteLine("Connection is successfully made!");

                string commandText = SQLQueryString.SelectProduct;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                SqlCeDataReader dr = cmd.ExecuteReader();

                Product prod;

                while (dr.Read())
                {
                    // List<ProductPrice> PriceList = new List<ProductPrice>();
                    //Console.WriteLine("{0}\t{1}\t{2}", dr[0], dr[1], dr[2]);
                    prod = new Product();
                    prod.Id = (int)dr[0];
                    prod.Name = dr[1].ToString();
                    prod.Units = (int)dr[2];
                    prod.Price = CurrentPrice((int)dr[0]);
                    // PriceList.AddRange(GetProductPrice((int)dr[0]));
                    // prod.Prices = PriceList;
                    ProductList.Add(prod);

                }

                return ProductList;
            }

            finally
            {
                conn.Close();
            }
        }

        public List<ProductPrice> GetProductPrice(int prodID)
        {
            List<ProductPrice> PriceList = new List<ProductPrice>();

            SqlCeConnection conn = new SqlCeConnection(SQLQueryString.ConnStr);

            try
            {

                conn.Open();

                // Console.WriteLine("Connection is successfully made!");

                string commandText = SQLQueryString.SelectPriceString;

                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@id", prodID);

                SqlCeDataReader dr = cmd.ExecuteReader();

                ProductPrice price;

                while (dr.Read())
                {
                    // Console.WriteLine("{0}\t{1}\t{2}", dr[0], dr[1], dr[2]);

                    price = new ProductPrice();

                    price.Price = (int)dr[1];
                    price.EffectiveDate = (DateTime)dr[2];

                    PriceList.Add(price);
                }

                return PriceList;

            }

            finally
            {
                conn.Close();

            }
        }

        public ProductPrice CurrentPrice(int prodID)
        {
            List<ProductPrice> PriceList = new List<ProductPrice>();
            PriceList = GetProductPrice(prodID);
            ProductPrice productprice;

            List<ProductPrice> SortedList = PriceList.OrderBy(o => o.EffectiveDate).ToList();

            for (int i = SortedList.Count - 1; i >= 0; i++)
            {

                if (SortedList[i].EffectiveDate <= DateTime.Now)
                {

                    productprice = new ProductPrice();
                    productprice.Price = SortedList[i].Price;
                    productprice.EffectiveDate = SortedList[i].EffectiveDate;
                    productprice.Id = SortedList[i].Id;
                    productprice.Product = SortedList[i].Product;

                    //Console.WriteLine("Price" + productprice.Price);

                    return productprice;
                }
            }

            return null;
        }
    }
}
