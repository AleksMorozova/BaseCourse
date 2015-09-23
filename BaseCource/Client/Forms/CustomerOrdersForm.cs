using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.View;
using DomainModel.Entities;
using Client.Presentor;
using Contracts;
using Client.Exceptions;
using Client.ClientModel.Entities;
using Server.Service;
using DomainModel;
using System.Resources;

namespace Client.Forms
{
    public partial class CustomerOrdersForm : Form, ICustomerOrdersView
    {
        CustomerOrdersPresenter presenter;
        private User customer;
        ResourceManager resourceManager = new ResourceManager("Client.Resources.CustomerOrdersStrings", typeof(CustomerEditOrderForm).Assembly);
        public CustomerOrdersForm(IContract contract)
        {
            InitializeComponent();
            SetStrings();
            presenter = new CustomerOrdersPresenter(this, contract);
        }

        private void SetStrings()
        {
            btnCreateNewOrder.Text = resourceManager.GetString("CreateNewOrder");
            showOrderInfoToolStripMenuItem.Text = resourceManager.GetString("ShowOrderInfo");
        }

        public IList<ClientOrder> Orders
        {
            get
            {
                return (IList<ClientOrder>)grdCtrlOrders.DataSource;
            }
            set
            {
                grdCtrlOrders.DataSource = value;
            }
        }

        public User Customer {
            get
            {
                return customer;
            }
            set
            {
                if (value.Role != Role.Customer)
                    throw new IncorrectUserRoleException("The user role should be CUSTOMER");
                customer = value;
                lblUserName.Text = value.Name;
                presenter.FillOrderList();
            }
        }


        private void gvOrders_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gvOrders_MasterRowGetRelationDisplayCaption(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.RelationName = resourceManager.GetString("ProductsInTheOrder");
                        break;
                    }
            }
        }

        private void gvOrders_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.RelationName = resourceManager.GetString("Items");
                        break;
                    }
            }
        }

        private void gvOrders_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.ChildList = (gvOrders.GetRow(e.RowHandle) as ClientOrder).Products.ToArray();
                        break;
                    }
            }
        }

        private void btnCreateNewOrder_Click(object sender, EventArgs e)
        {
            SelectedOrder = new ClientOrder();
            this.Close();
        }


        public ClientOrder SelectedOrder { get; set; }

        private void showOrderInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedOrder = ((ClientOrder)gvOrders.GetFocusedRow());
            this.Close();
        }
    }
}
