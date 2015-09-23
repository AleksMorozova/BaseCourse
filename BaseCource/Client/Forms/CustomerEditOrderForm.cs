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
using Client.ClientModel.Entities;
using Server.Service;
using DomainModel;
using DevExpress.XtraGrid.Columns;
using System.Resources;

namespace Client.Forms
{
    public partial class CustomerEditOrderForm : Form, ICustomerEditOrderView
    {
        CustomerEditOrderPresenter presenter;
        ClientOrder order;
        User customer;
        List<Product> products;
        ResourceManager resourceManager = new ResourceManager("Client.Resources.CustomerEditOrderStrings", typeof(CustomerEditOrderForm).Assembly);
        bool isOrderReadOnly;
        public CustomerEditOrderForm(IContract contract)
        {
            InitializeComponent();
            SetStrings();
            presenter = new CustomerEditOrderPresenter(this, contract);
            Products = presenter.GetAllProducts().ToList();
        }
        void SetStrings()
        {
            tsmiAddToOrder.Text = resourceManager.GetString("AddToTheOrder");
            removeFromTheOrderToolStripMenuItem.Text = resourceManager.GetString("RemoveFromTheOrder");
            labelControl1.Text = resourceManager.GetString("OrderStatus")+":";
            labelControl2.Text = resourceManager.GetString("OrderId") + ":";
            labelControl3.Text = resourceManager.GetString("OrderPlacingDate") + ":"; 
            labelControl4.Text = resourceManager.GetString("Customer") + ":";
            lblProducts.Text = resourceManager.GetString("Products");
            lblOrderItems.Text = resourceManager.GetString("ProductsInTheOrder");
            btnCreateOrder.Text = resourceManager.GetString("CreateOrder");
            btnRemoveOrder.Text = resourceManager.GetString("RemoveOrder");
            btnSaveOrder.Text = resourceManager.GetString("SaveOrder");
            lblTotalCount.Text = resourceManager.GetString("OrderTotalPrice")+":";
        }
        public ClientOrder Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                if (order != null)
                {
                    if (order.Status > Status.New)
                        isOrderReadOnly = true;
                    else
                        isOrderReadOnly = false;
                    if (order.Products == null)
                    {
                        order.Products = new BindingList<ClientOrderItem>();
                    }
                    gcOrderItems.DataSource = order.Products;
                    foreach (GridColumn column in gvOrderItems.Columns)
                        column.OptionsColumn.AllowEdit = false;
                    if (!isOrderReadOnly)
                        gvOrderItems.Columns["Count"].OptionsColumn.AllowEdit = true;
                    UpdateTotalCount();
                }
                ShowOrderInfo();
            }
        }

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                gcProducts.DataSource = value;
            }
        }

        public User Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                lblCustomerName.Text = value.Name;
            }
        }

        public string ViewCaption
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public void ShowOrderInfo()
        {
            if (Order != null)
            {
                lblOrderId.Text = Order.Id.ToString();
                if (Order.PlacingDate != new DateTime())
                {
                    lblPlacingDate.Text = Order.PlacingDate.ToShortDateString();
                }
                lblStatus.Text = Order.Status.ToString();
                if (Order.Id == 0)
                {
                    ViewCaption = resourceManager.GetString("CreateNewOrder");
                    presenter.CommandList.AddCreateOrderCommand(Order);
                }
                else
                {
                    ViewCaption = resourceManager.GetString("EditTheOrder"); ;
                }
                if (isOrderReadOnly)
                {
                    btnCreateOrder.Enabled = false;
                    btnRemoveOrder.Enabled = false;
                    btnSaveOrder.Enabled = false;
                    cmsProducts.Enabled = false;
                    cmsOrderItems.Enabled = false;
                }
            }
        }

        private void tsmiAddToOrder_Click(object sender, EventArgs e)
        {
            if (!isOrderReadOnly)
            {
                presenter.AddOrderItemToOrder(((Product)gvProducts.GetFocusedRow()), 1, Order);
                UpdateTotalCount();
            }
        }

        private void gvOrderItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gvOrderItems.Columns["Count"])
            {
                presenter.CommandList.AddUpdateOrderItemCommand(((ClientOrderItem)gvOrderItems.GetFocusedRow()), "Count", e.Value);
            }
        }

        private void removeFromTheOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isOrderReadOnly)
            {
                presenter.RemoveOrderItemFromOrder(((ClientOrderItem)gvOrderItems.GetFocusedRow()));
                UpdateTotalCount();
            }
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            if (!isOrderReadOnly)
            {
                FormClosingEventArgs fcEventArgs = e as FormClosingEventArgs;
                if (MessageBox.Show(resourceManager.GetString("RemoveOrderQuestion"), resourceManager.GetString("Warning"), MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    presenter.RemoveOrder();
                    if (fcEventArgs == null)
                    {
                        isOrderReadOnly = true;
                        this.Close();
                    }
                }
                else
                {
                    if (fcEventArgs != null)
                        fcEventArgs.Cancel = true;
                }
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (Order.Products.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("EmptyProductList"));
                return;
            }
            presenter.SetOrderSatusToNew();
            presenter.SendCommandList();
            isOrderReadOnly = true;
            MessageBox.Show(resourceManager.GetString("OrderCreated"));
            this.Close();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (Order.Products.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("EmptyProductList"));
                return;
            }
            presenter.SendCommandList();
            isOrderReadOnly = true;
            MessageBox.Show(resourceManager.GetString("OrderSaved"));
            this.Close();
        }
        void UpdateTotalCount()
        {
            lblTotalCountValue.Text = order.TotalPrice.ToString();
        }
    }
}
