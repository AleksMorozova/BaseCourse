using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
//build FIX
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using NHibernate.Proxy;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Spring.Context.Support;
using DAL.Abstract;
using DAL.Concrete.NHibernate;
using System.ServiceModel;
using Contracts;
using Server.Service;
using System.Configuration;
using System.Collections.Specialized;
using System.ServiceModel.Description;
using log4net;
using log4net.Config;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();	
            //List<ProductPrice> p = new List<ProductPrice>() { new ProductPrice { EffectiveDate = DateTime.Now, Price = 2, ProductId = 45 } };
            //Product s = new Product() { Name = "S-class_1", Prices = p, Units = 52 };
            //List<OrderItem> It = new List<OrderItem> { new OrderItem { Count = 1, Product = s, Product_Id = 45, Order_Id = 15 } };
            //Order or = new Order { Items = It, PlacingDate = DateTime.Now, Status = Status.New, Users_Id = 16 };
            //int id = 1;
            //User u = new User { Name = "Kap1a1asd", Role = (int)Role.Customer, Password = "asd", Login = (new Random()).Next().ToString() };
            /*try
            {
                Console.WriteLine(userDal.GetUser("New", "Newest").Name);
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Please, implement " + userDal.GetType().ToString() + " first!");
            }*/
            //ControlFluentNh ch = ControlFluentNh.SessionInstance;
            //User u = ch.GetUser("new", "newest");
            //Console.WriteLine(u.Login);
            //Console.ReadKey();
            SetConnection();
        }

        static string GetSettings()
        {
            // Assume failure. 
            string returnValue = null;

            NameValueCollection settings =
                   ConfigurationManager.AppSettings;

            // If found, return the connection string. 
            if (settings != null)
                returnValue = settings[0];

            return returnValue;
        }

        static void SetConnection()
        {

            string newadress = GetSettings();
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri address = new Uri(newadress);
            Type contract = typeof(IContract);
            ServiceHost host = new ServiceHost(typeof(ServiceContract));
            host.AddServiceEndpoint(contract, binding, address);
            ServiceDebugBehavior debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();

            // if not found - add behavior with setting turned on 
            if (debug == null)
            {
                host.Description.Behaviors.Add(
                     new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
            }
            else
            {
                // make sure setting is turned ON
                if (!debug.IncludeExceptionDetailInFaults)
                {
                    debug.IncludeExceptionDetailInFaults = true;
                }
            }
            host.Open();

           
            Console.WriteLine("Server is started. To stop server press any key...");
            Console.ReadKey();
            host.Close();
        }

    }
}
