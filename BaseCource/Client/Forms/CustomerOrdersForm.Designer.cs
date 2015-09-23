using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
namespace Client.Forms
{
    partial class CustomerOrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvOrderItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdCtrlOrders = new DevExpress.XtraGrid.GridControl();
            this.cmsEditOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showOrderInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlacingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateNewOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlOrders)).BeginInit();
            this.cmsEditOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // gvOrderItems
            // 
            this.gvOrderItems.GridControl = this.grdCtrlOrders;
            this.gvOrderItems.Name = "gvOrderItems";
            this.gvOrderItems.OptionsBehavior.Editable = false;
            // 
            // grdCtrlOrders
            // 
            this.grdCtrlOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCtrlOrders.ContextMenuStrip = this.cmsEditOrder;
            gridLevelNode2.LevelTemplate = this.gvOrderItems;
            gridLevelNode2.RelationName = "Items";
            this.grdCtrlOrders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdCtrlOrders.Location = new System.Drawing.Point(23, 35);
            this.grdCtrlOrders.MainView = this.gvOrders;
            this.grdCtrlOrders.Name = "grdCtrlOrders";
            this.grdCtrlOrders.Size = new System.Drawing.Size(608, 221);
            this.grdCtrlOrders.TabIndex = 0;
            this.grdCtrlOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrders,
            this.gvOrderItems});
            // 
            // cmsEditOrder
            // 
            this.cmsEditOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOrderInfoToolStripMenuItem});
            this.cmsEditOrder.Name = "cmsEditOrder";
            this.cmsEditOrder.Size = new System.Drawing.Size(161, 26);
            // 
            // showOrderInfoToolStripMenuItem
            // 
            this.showOrderInfoToolStripMenuItem.Name = "showOrderInfoToolStripMenuItem";
            this.showOrderInfoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showOrderInfoToolStripMenuItem.Text = "Show Order Info";
            this.showOrderInfoToolStripMenuItem.Click += new System.EventHandler(this.showOrderInfoToolStripMenuItem_Click);
            // 
            // gvOrders
            // 
            this.gvOrders.GridControl = this.grdCtrlOrders;
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.OptionsBehavior.Editable = false;
            this.gvOrders.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gvOrders_MasterRowGetChildList);
            this.gvOrders.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvOrders_MasterRowGetRelationName);
            this.gvOrders.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvOrders_MasterRowGetRelationDisplayCaption);
            this.gvOrders.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gvOrders_MasterRowGetRelationCount);
            this.gvOrders.DoubleClick += new System.EventHandler(this.showOrderInfoToolStripMenuItem_Click);
            // 
            // ProductId
            // 
            this.ProductId.Caption = "Product Id";
            this.ProductId.FieldName = "Product.Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.Visible = true;
            this.ProductId.VisibleIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Product Name";
            this.ProductName.FieldName = "Product.Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            // 
            // ProductCount
            // 
            this.ProductCount.Caption = "Count";
            this.ProductCount.FieldName = "Count";
            this.ProductCount.Name = "ProductCount";
            this.ProductCount.Visible = true;
            this.ProductCount.VisibleIndex = 2;
            // 
            // OrderId
            // 
            this.OrderId.Caption = "Order id";
            this.OrderId.FieldName = "Id";
            this.OrderId.Name = "OrderId";
            this.OrderId.Visible = true;
            this.OrderId.VisibleIndex = 0;
            // 
            // OrderStatus
            // 
            this.OrderStatus.Caption = "Status";
            this.OrderStatus.FieldName = "Status";
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.Visible = true;
            this.OrderStatus.VisibleIndex = 1;
            // 
            // PlacingDate
            // 
            this.PlacingDate.Caption = "Placing Date";
            this.PlacingDate.FieldName = "PlacingDate";
            this.PlacingDate.Name = "PlacingDate";
            this.PlacingDate.Visible = true;
            this.PlacingDate.VisibleIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(23, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "lblUserName";
            // 
            // btnCreateNewOrder
            // 
            this.btnCreateNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewOrder.Location = new System.Drawing.Point(521, 262);
            this.btnCreateNewOrder.Name = "btnCreateNewOrder";
            this.btnCreateNewOrder.Size = new System.Drawing.Size(110, 23);
            this.btnCreateNewOrder.TabIndex = 3;
            this.btnCreateNewOrder.Text = "Create new order";
            this.btnCreateNewOrder.UseVisualStyleBackColor = true;
            this.btnCreateNewOrder.Click += new System.EventHandler(this.btnCreateNewOrder_Click);
            // 
            // CustomerOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 297);
            this.Controls.Add(this.btnCreateNewOrder);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.grdCtrlOrders);
            this.Name = "CustomerOrdersForm";
            this.Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlOrders)).EndInit();
            this.cmsEditOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrders;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrderItems;
        //Columns
        private DevExpress.XtraGrid.Columns.GridColumn OrderId;
        private DevExpress.XtraGrid.Columns.GridColumn OrderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCount;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private DevExpress.XtraGrid.Columns.GridColumn PlacingDate;
        private System.Windows.Forms.Button btnCreateNewOrder;
        private System.Windows.Forms.ContextMenuStrip cmsEditOrder;
        private System.Windows.Forms.ToolStripMenuItem showOrderInfoToolStripMenuItem;
    }
}