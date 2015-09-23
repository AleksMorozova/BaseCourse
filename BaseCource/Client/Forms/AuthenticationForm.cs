using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.View;
using Contracts;
using Client.Presentor;
using Server.Service;
using System.Resources;

namespace Client.Forms
{
    public partial class AuthenticationForm : Form, IAuthenticationView
    {
        AuthenticationPresenter p;
        ResourceManager resourceManager = new ResourceManager("Client.Resources.AuthenticationStrings", typeof(CustomerEditOrderForm).Assembly);
        public AuthenticationForm(IContract contract)
        {
            InitializeComponent();
            SetStrings();
            p = new AuthenticationPresenter(this, contract);
        }

        public string Login
        {
            get
            {
                return txtLogin.Text;
            }
            set
            {
                txtLogin.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            User = p.Authenticate(Login, Password);
            if (User == null)
            {
                MessageBox.Show(resourceManager.GetString("InputCorrectLoginAndPassword"));
            }
            else
            {
                this.Close();
            }
        }


        public DomainModel.Entities.User User
        {
            get;
            set;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SetStrings()
        {
            lblLogin.Text = resourceManager.GetString("Login");
            lblPassword.Text = resourceManager.GetString("Password");
            btnCancel.Text = resourceManager.GetString("Cancel");
            btnSubmit.Text = resourceManager.GetString("Submit");
        }
    }
}
