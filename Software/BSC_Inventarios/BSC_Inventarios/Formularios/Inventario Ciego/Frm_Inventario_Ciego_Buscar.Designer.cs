namespace BSC_Inventarios
{ 
    partial class Frm_Inventario_Ciego_Buscar
    {
        /// <summary>
        /// 
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
            this.dtgFoliosInventario = new DevExpress.XtraGrid.GridControl();
            this.dtgValFoliosInventario = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFoliosInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValFoliosInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgFoliosInventario
            // 
            this.dtgFoliosInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgFoliosInventario.Location = new System.Drawing.Point(10, 10);
            this.dtgFoliosInventario.MainView = this.dtgValFoliosInventario;
            this.dtgFoliosInventario.Name = "dtgFoliosInventario";
            this.dtgFoliosInventario.Size = new System.Drawing.Size(432, 321);
            this.dtgFoliosInventario.TabIndex = 0;
            this.dtgFoliosInventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValFoliosInventario});
            this.dtgFoliosInventario.DoubleClick += new System.EventHandler(this.dtgFoliosInventario_DoubleClick);
            // 
            // dtgValFoliosInventario
            // 
            this.dtgValFoliosInventario.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.dtgValFoliosInventario.GridControl = this.dtgFoliosInventario;
            this.dtgValFoliosInventario.Name = "dtgValFoliosInventario";
            this.dtgValFoliosInventario.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Folio";
            this.gridColumn1.FieldName = "InventarioCiegoFolio";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "InventarioCiegoFecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Estatus";
            this.gridColumn3.FieldName = "InventarioCiegoEstatus";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // Frm_Inventario_Ciego_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 341);
            this.Controls.Add(this.dtgFoliosInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inventario_Ciego_Buscar";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Folios Pendientes";
            this.Shown += new System.EventHandler(this.Frm_Inventario_Ciego_Buscar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFoliosInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValFoliosInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dtgFoliosInventario;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValFoliosInventario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}