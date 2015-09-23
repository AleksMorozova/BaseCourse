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
using Server.Service;

namespace Client.Forms
{
    public partial class TechnologistForm : Form, ITechnologistView
    {
        TechnologistPresenter presenter;
        private User technologist;

        public TechnologistForm(IContract contract)
        {
            InitializeComponent();
            presenter = new TechnologistPresenter(this, contract);
            repositoryItemComboBox1.Items.AddRange(Enum.GetValues((typeof(Status))));
        }

        public IList<Order> Orders
        {
            get
            {
                return (IList<Order>)gcAllOrders.DataSource;
            }
            set
            {
                gcAllOrders.DataSource = value;
                //presentor.FillOrderList();
            }
        }


        public User Technologist
        {
            get
            {
                return technologist;
            }
            set
            {
                if (value.Role != Role.Technologist)
                    throw new IncorrectUserRoleException("The user role should be Technologist");
                technologist = value;
                //lblUserName.Text = value.Name;
                presenter.FillOrderList();
            }
        }

        private void gvAllOrders_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gvAllOrders_MasterRowGetRelationDisplayCaption(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.RelationName = "Products in the order";
                        break;
                    }
            }
        }

        private void gvAllOrders_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.RelationName = "Items";
                        break;
                    }
            }
        }

        private void gvAllOrders_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    {
                        e.ChildList = (gvAllOrders.GetRow(e.RowHandle) as Order).Items.ToArray();
                        break;
                    }
            }
        }

        public Order SelectedOrder { get; set; }
    }
}
