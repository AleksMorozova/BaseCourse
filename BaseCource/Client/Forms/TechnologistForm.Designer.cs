namespace Client.Forms
{
    partial class TechnologistForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAllOrders = new DevExpress.XtraGrid.GridControl();
            this.gvAllOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.PlacingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.User_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAllOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductId,
            this.ProductName,
            this.Count});
            this.gvItems.GridControl = this.gcAllOrders;
            this.gvItems.Name = "gvItems";
            // 
            // ProductId
            // 
            this.ProductId.Caption = "Product ID";
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
            // Count
            // 
            this.Count.Caption = "Count";
            this.Count.FieldName = "Count";
            this.Count.Name = "Count";
            this.Count.Visible = true;
            this.Count.VisibleIndex = 2;
            // 
            // gcAllOrders
            // 
            this.gcAllOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.gvItems;
            gridLevelNode1.RelationName = "Items";
            this.gcAllOrders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcAllOrders.Location = new System.Drawing.Point(12, 12);
            this.gcAllOrders.MainView = this.gvAllOrders;
            this.gcAllOrders.Name = "gcAllOrders";
            this.gcAllOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gcAllOrders.Size = new System.Drawing.Size(619, 235);
            this.gcAllOrders.TabIndex = 0;
            this.gcAllOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAllOrders,
            this.gvItems});
            // 
            // gvAllOrders
            // 
            this.gvAllOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OrderId,
            this.OrderStatus,
            this.PlacingDate,
            this.User_Name});
            this.gvAllOrders.GridControl = this.gcAllOrders;
            this.gvAllOrders.Name = "gvAllOrders";
            this.gvAllOrders.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gvAllOrders_MasterRowGetChildList);
            this.gvAllOrders.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvAllOrders_MasterRowGetRelationName);
            this.gvAllOrders.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvAllOrders_MasterRowGetRelationDisplayCaption);
            this.gvAllOrders.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gvAllOrders_MasterRowGetRelationCount);
            // 
            // OrderId
            // 
            this.OrderId.Caption = "Order ID";
            this.OrderId.FieldName = "Id";
            this.OrderId.Name = "OrderId";
            this.OrderId.OptionsColumn.ReadOnly = true;
            this.OrderId.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.OrderId.Visible = true;
            this.OrderId.VisibleIndex = 0;
            // 
            // OrderStatus
            // 
            this.OrderStatus.Caption = "Status";
            this.OrderStatus.ColumnEdit = this.repositoryItemComboBox1;
            this.OrderStatus.FieldName = "Status";
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.Visible = true;
            this.OrderStatus.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // PlacingDate
            // 
            this.PlacingDate.Caption = "Placing Date";
            this.PlacingDate.FieldName = "PlacingDate";
            this.PlacingDate.Name = "PlacingDate";
            this.PlacingDate.OptionsColumn.ReadOnly = true;
            this.PlacingDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.PlacingDate.Visible = true;
            this.PlacingDate.VisibleIndex = 2;
            // 
            // User_Name
            // 
            this.User_Name.Caption = "User";
            this.User_Name.FieldName = "User.Name";
            this.User_Name.Name = "User_Name";
            this.User_Name.OptionsColumn.ReadOnly = true;
            this.User_Name.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.User_Name.Visible = true;
            this.User_Name.VisibleIndex = 3;
            // 
            // TechnologistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 294);
            this.Controls.Add(this.gcAllOrders);
            this.Name = "TechnologistForm";
            this.Text = "TechnologistForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAllOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAllOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAllOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn OrderId;
        private DevExpress.XtraGrid.Columns.GridColumn OrderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn PlacingDate;
        private DevExpress.XtraGrid.Columns.GridColumn User_Name;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Count;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}