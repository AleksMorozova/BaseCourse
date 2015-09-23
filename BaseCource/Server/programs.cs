using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using DomainModel.Entities;



namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //HManage h = new HManage();
            //Product p = new Product();
            
            //using (ISession session = h._sessionfactory.OpenSession())
            //using (ITransaction transaction = session.BeginTransaction())
            //{
                
            //    Console.WriteLine(session.QueryOver<Product>().Where(x => x.Name == "Sam").SingleOrDefault().Name);
            //}


        }
    }
    interface IRepository
    {
        void add();
        void update();
        void Get();

    }
    public class RepositiryManage : IRepository
    {

        public void add()
        {
            
        }

        public void update()
        {
        }

        public void Get()
        {
        }
    }
    public sealed class HManage
    {
        public readonly ISessionFactory _sessionfactory;
        private ISession _session;
        public readonly Configuration _configuration;
        public HManage()
        {
            _configuration = new Configuration().Configure().AddAssembly(GetType().Assembly);
            _sessionfactory = _configuration.BuildSessionFactory();
        }
        
    }
}
