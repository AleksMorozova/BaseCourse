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
using log4net;

namespace DAL.Concrete.AdoNet
{
    public class ANUserDAL:IUserDAL
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(ANUserDAL));
        public User GetUser(string login, string password)
        {
            SqlCeConnection conn = SQLQueryString.connection;

            conn.Open();

            //Console.WriteLine("Connection is successfully made!");

            try
            {
                string commandText = SQLQueryString.SelectUsersString;
                SqlCeCommand cmd = new SqlCeCommand(commandText, conn);

                cmd.Parameters.AddWithValue("@log", login);
                cmd.Parameters.AddWithValue("@pas", password);

                SqlCeDataReader dr = cmd.ExecuteReader();

                User user;

                if (dr.Read())
                {
                    user = new User();
                    //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", dr[0], dr[1], dr[2], dr[3], dr[4]);
                    log.Info("User:   " + " ID " + dr[0] + " NAME  " + dr[1] + "  ROLE  " + (Role)dr[2] + "  LOGIN  " + dr[3] + "  PASSWOR  " + dr[4]);
                    user.Id = (int)dr[0];
                    user.Name = (string)dr[1];
                    user.Role = (Role)dr[2];
                    user.Login = (string)dr[3];
                    user.Password = (string)dr[4];
                    return user;
                }

                return null;
            }
            catch (SqlCeException ex)
            {
                log.Error(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
