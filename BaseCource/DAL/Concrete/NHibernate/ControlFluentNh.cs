using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Infrastructure;
using NHibernate;
using FluentNHibernate.Conventions;
using NHibernate.Cfg;
using NHibernate.Criterion;
using DomainModel.Entities;
using DAL.Abstract;
namespace DAL.Concrete.NHibernate
{
    public class ControlFluentNh : IUserDAL, IOrderDAL, IOrderItemDAL
    {
        //delegate T test<T>(T item);
        private ISession _session;
        private Configuration _configuration;
        private readonly ISessionFactory _SessionFactoty;
        private ITransaction _Transaction;

        public static ControlFluentNh SessionInstance
        {
            get
            {
                return singletone.Instance;
            }
        }

        private class singletone
        {
            static singletone() { }
            internal static readonly ControlFluentNh Instance = new ControlFluentNh();
        }
        public ControlFluentNh()
        {
            if (_configuration == null)
            {
                _configuration = Fluently.Configure().Database(MsSqlCeConfiguration.Standard.
                    ConnectionString(con => con.FromConnectionStringWithKey("FHdb")).ShowSql()).
                    Mappings(x => x.FluentMappings.AddFromAssembly(GetType().Assembly)).BuildConfiguration();
            }
            _SessionFactoty = _configuration.BuildSessionFactory();
        }

        public void AddItem<T>(T item) where T : class
        {
            this.OpenTransaction();
            if (_session == null)
            {
                Console.WriteLine("Session is close");
                return;
            }
            _session.SaveOrUpdate(item);
            this.FinishTransaction();
        }
        public T GetItem<T>(int id, string login = null, string pass = null) where T : class, new()
        {
            T temp = new T();
            if (pass == null && login == null)
            {
                this.OpenTransaction();
                if (_session == null)
                {
                    Console.WriteLine("Session is close");
                    return temp;
                }
                temp = _session.Get<T>(id);
                this.FinishTransaction();
            }
            else
            {
                if (temp is User)
                {
                    temp = (T)_session.CreateCriteria<T>().Add(Restrictions.Conjunction().Add(Restrictions.Eq("Login", login)).Add(Restrictions.Eq("Password", pass))).UniqueResult();
                }
            }
            return temp;
        }
        public List<T> GetList<T>() where T : class
        {
            List<T> temp = new List<T>();
            this.OpenTransaction();
            if (_session == null)
            {
                Console.WriteLine("Session is close");
                return temp;
            }
            temp = (List<T>)_session.CreateCriteria<T>().List<T>();
            this.FinishTransaction();
            return temp;
        }
        public void delete<T>(int id)
        {
            this.OpenTransaction();
            if (_session == null)
            {
                Console.WriteLine("Session is close");
                return;
            }
            T temp = (T)_session.Get(typeof(T), id);
            _session.Flush();
            if (temp == null)
            {
                Console.WriteLine("It was deleted or never exist");
                this.FinishTransaction();
                return;
            }
            _session.Delete(temp);
            this.FinishTransaction();

        }
        public bool OpenSession()
        {
            try
            {
                _session = _SessionFactoty.OpenSession();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }
        public bool CloseSession()
        {
            if (_session == null)
            {
                try
                {

                    _session.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
            return true;
        }
        private void OpenTransaction()
        {
            if (_session == null)
            {
                Console.WriteLine("Session is close");
                return;
            }
            _Transaction = _session.BeginTransaction();
        }

        private void FinishTransaction()
        {
            if (_session == null)
            {
                Console.WriteLine("Session is close");
                return;
            }
            _Transaction.Commit();
            _Transaction.Dispose();
        }



        public User GetUser(string login, string password)
        {
            OpenSession();
            User temp = GetItem<User>(1, login, password);
            CloseSession();
            return temp;
        }

        public IList<DomainModel.Entities.Order>GetOrders(int userID)
        {
            OpenSession();
            //_session.CreateCriteria<DomainModel.Entities.Order>().Add(Restrictions.)
            CloseSession();
            return new List<DomainModel.Entities.Order>();
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public IList<OrderItem> GetOrderItems(int orderID)
        {
            throw new NotImplementedException();
        }

        #region Члены IOrderDAL


        public IList<DomainModel.Entities.Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        #endregion


        public DomainModel.Entities.Order SaveNewOrder(DomainModel.Entities.Order order)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(DomainModel.Entities.Order order)
        {
            throw new NotImplementedException();
        }

        public void ChangeOrderStatus(int orderId, Status newStatus)
        {
            throw new NotImplementedException();
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
