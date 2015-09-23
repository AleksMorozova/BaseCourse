using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client.Forms;
using System.ServiceModel;
using Contracts;
using DomainModel.Entities;
using Client.Translator;
using System.Configuration;
using System.Collections.Specialized;

namespace Client
{

    static class Program
    {
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
        static IContract contract;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()    

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            contract = SetConnection();
            AuthenticationForm authForm = new AuthenticationForm(contract);
            CustomerOrdersForm custOrdersForm;
            CustomerEditOrderForm custEditOrdersForm;
            Application.Run(authForm);
            if (authForm.User == null)
            {
                //end of program
                return;
            }

            if (authForm.User.Role == Role.Customer)
            {
                custOrdersForm = new CustomerOrdersForm(contract);
                custOrdersForm.Customer = authForm.User;
                Application.Run(custOrdersForm);
                while (custOrdersForm.SelectedOrder != null)
                {
                    custEditOrdersForm = new CustomerEditOrderForm(contract);
                    custEditOrdersForm.Customer = custOrdersForm.Customer;
                    custEditOrdersForm.Order = custOrdersForm.SelectedOrder;
                    Application.Run(custEditOrdersForm);
                    custOrdersForm = new CustomerOrdersForm(contract);
                    custOrdersForm.Customer = authForm.User;
                    Application.Run(custOrdersForm);
                }
            }

            else if (authForm.User.Role == Role.Technologist) 
            {
                TechnologistForm TechForm = new TechnologistForm(contract);
                TechForm.Technologist = authForm.User;
                Application.Run(TechForm);

            }  
        }
        static IContract SetConnection()
        {
            string newadress = GetSettings();
            Uri address = new Uri(newadress);
            EndpointAddress endpoit = new EndpointAddress(address);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, endpoit);
            IContract chanel = factory.CreateChannel();
            return chanel;
        }
    }
}
