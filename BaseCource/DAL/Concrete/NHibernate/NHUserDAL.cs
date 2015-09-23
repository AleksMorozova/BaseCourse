using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Abstract;


namespace DAL.Concrete.NHibernate
{
    public class NHUserDAL:IUserDAL
    {
        public DomainModel.Entities.User GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
