using System.Windows.Forms;
namespace Client.Forms
{
    partial class CustomerEditOrderForm
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
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tlpGrids = new System.Windows.Forms.TableLayoutPanel();
            this.lblProducts = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderItems = new DevExpress.XtraEditors.LabelControl();
            this.gcProducts = new DevExpress.XtraGrid.GridControl();
            this.cmsProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddToOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrderItems = new DevExpress.XtraGrid.GridControl();
            this.cmsOrderItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromTheOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvOrderItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderId = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblPlacingDate = new DevExpress.XtraEditors.LabelControl();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lblTotalCount = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalCountValue = new DevExpress.XtraEditors.LabelControl();
            this.tlpGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            this.cmsProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrderItems)).BeginInit();
            this.cmsOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductId
            // 
            this.ProductId.Caption = "Product Id";
            this.ProductId.FieldName = "Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.Visible = true;
            this.ProductId.VisibleIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Product Name";
            this.ProductName.FieldName = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            // 
            // tlpGrids
            // 
            this.tlpGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGrids.ColumnCount = 3;
            this.tlpGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGrids.Controls.Add(this.lblProducts, 0, 0);
            this.tlpGrids.Controls.Add(this.lblOrderItems, 2, 0);
            this.tlpGrids.Controls.Add(this.gcProducts, 0, 1);
            this.tlpGrids.Controls.Add(this.gcOrderItems, 2, 1);
            this.tlpGrids.Location = new System.Drawing.Point(12, 60);
            this.tlpGrids.Name = "tlpGrids";
            this.tlpGrids.RowCount = 2;
            this.tlpGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrids.Size = new System.Drawing.Size(633, 214);
            this.tlpGrids.TabIndex = 0;
            // 
            // lblProducts
            // 
            this.lblProducts.Location = new System.Drawing.Point(3, 3);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(0, 13);
            this.lblProducts.TabIndex = 0;
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.Location = new System.Drawing.Point(324, 3);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(0, 13);
            this.lblOrderItems.TabIndex = 1;
            // 
            // gcProducts
            // 
            this.gcProducts.ContextMenuStrip = this.cmsProducts;
            this.gcProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducts.Location = new System.Drawing.Point(3, 23);
            this.gcProducts.MainView = this.gvProducts;
            this.gcProducts.Name = "gcProducts";
            this.gcProducts.Size = new System.Drawing.Size(305, 188);
            this.gcProducts.TabIndex = 2;
            this.gcProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducts});
            // 
            // cmsProducts
            // 
            this.cmsProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddToOrder});
            this.cmsProducts.Name = "cmsProducts";
            this.cmsProducts.Size = new System.Drawing.Size(68, 26);
            // 
            // tsmiAddToOrder
            // 
            this.tsmiAddToOrder.Name = "tsmiAddToOrder";
            this.tsmiAddToOrder.Size = new System.Drawing.Size(67, 22);
            this.tsmiAddToOrder.Click += new System.EventHandler(this.tsmiAddToOrder_Click);
            // 
            // gvProducts
            // 
            this.gvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductId,
            this.ProductName,
            this.Price});
            this.gvProducts.GridControl = this.gcProducts;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.OptionsBehavior.Editable = false;
            this.gvProducts.DoubleClick += new System.EventHandler(this.tsmiAddToOrder_Click);
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price.Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 2;
            // 
            // gcOrderItems
            // 
            this.gcOrderItems.ContextMenuStrip = this.cmsOrderItems;
            this.gcOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOrderItems.Location = new System.Drawing.Point(324, 23);
            this.gcOrderItems.MainView = this.gvOrderItems;
            this.gcOrderItems.Name = "gcOrderItems";
            this.gcOrderItems.Size = new System.Drawing.Size(306, 188);
            this.gcOrderItems.TabIndex = 3;
            this.gcOrderItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrderItems});
            // 
            // cmsOrderItems
            // 
            this.cmsOrderItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromTheOrderToolStripMenuItem});
            this.cmsOrderItems.Name = "cmsOrderItems";
            this.cmsOrderItems.Size = new System.Drawing.Size(68, 26);
            // 
            // removeFromTheOrderToolStripMenuItem
            // 
            this.removeFromTheOrderToolStripMenuItem.Name = "removeFromTheOrderToolStripMenuItem";
            this.removeFromTheOrderToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.removeFromTheOrderToolStripMenuItem.Click += new System.EventHandler(this.removeFromTheOrderToolStripMenuItem_Click);
            // 
            // gvOrderItems
            // 
            this.gvOrderItems.GridControl = this.gcOrderItems;
            this.gvOrderItems.Name = "gvOrderItems";
            this.gvOrderItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvOrderItems_CellValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.00474F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.75829F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.4297F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.64929F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPlacingDate, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(318, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(0, 13);
            this.labelControl3.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(0, 13);
            this.labelControl4.TabIndex = 3;
            // 
            // lblOrderId
            // 
            this.lblOrderId.Location = new System.Drawing.Point(60, 23);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(0, 13);
            this.lblOrderId.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(422, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(0, 13);
            this.labelControl2.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Location = new System.Drawing.Point(60, 3);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerName.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(318, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 13);
            this.labelControl1.TabIndex = 0;
            // 
            // lblPlacingDate
            // 
            this.lblPlacingDate.Location = new System.Drawing.Point(422, 3);
            this.lblPlacingDate.Name = "lblPlacingDate";
            this.lblPlacingDate.Size = new System.Drawing.Size(0, 13);
            this.lblPlacingDate.TabIndex = 6;
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveOrder.Location = new System.Drawing.Point(186, 277);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveOrder.TabIndex = 2;
            this.btnRemoveOrder.UseVisualStyleBackColor = true;
            this.btnRemoveOrder.Click += new System.EventHandler(this.btnRemoveOrder_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveOrder.Location = new System.Drawing.Point(105, 277);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSaveOrder.TabIndex = 3;
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateOrder.Location = new System.Drawing.Point(11, 277);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(88, 23);
            this.btnCreateOrder.TabIndex = 4;
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCount.Location = new System.Drawing.Point(479, 280);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(63, 13);
            this.lblTotalCount.TabIndex = 5;
            this.lblTotalCount.Text = "labelControl5";
            // 
            // lblTotalCountValue
            // 
            this.lblTotalCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCountValue.Location = new System.Drawing.Point(569, 280);
            this.lblTotalCountValue.Name = "lblTotalCountValue";
            this.lblTotalCountValue.Size = new System.Drawing.Size(63, 13);
            this.lblTotalCountValue.TabIndex = 6;
            this.lblTotalCountValue.Text = "labelControl5";
            // 
            // CustomerEditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 305);
            this.Controls.Add(this.lblTotalCountValue);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnRemoveOrder);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpGrids);
            this.MinimumSize = new System.Drawing.Size(673, 335);
            this.Name = "CustomerEditOrderForm";
            this.Text = "CustomerEditOrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnRemoveOrder_Click);
            this.tlpGrids.ResumeLayout(false);
            this.tlpGrids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            this.cmsProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrderItems)).EndInit();
            this.cmsOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGrids;
        private DevExpress.XtraEditors.LabelControl lblProducts;
        private DevExpress.XtraEditors.LabelControl lblOrderItems;
        private DevExpress.XtraGrid.GridControl gcProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducts;
        private DevExpress.XtraGrid.GridControl gcOrderItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrderItems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.LabelControl lblOrderId;
        private DevExpress.XtraEditors.LabelControl lblPlacingDate;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private System.Windows.Forms.ContextMenuStrip cmsProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddToOrder;
        private System.Windows.Forms.ContextMenuStrip cmsOrderItems;
        private System.Windows.Forms.ToolStripMenuItem removeFromTheOrderToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveOrder;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnCreateOrder;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraEditors.LabelControl lblTotalCount;
        private DevExpress.XtraEditors.LabelControl lblTotalCountValue;
    }
}