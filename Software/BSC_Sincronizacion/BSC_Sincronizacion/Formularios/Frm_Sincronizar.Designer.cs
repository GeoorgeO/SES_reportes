namespace BSC_Sincronizacion
{
    partial class Frm_Sincronizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Sincronizar));
            this.lFechaInicio = new DevExpress.XtraEditors.LabelControl();
            this.dtFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.lFechaFin = new DevExpress.XtraEditors.LabelControl();
            this.dtFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.btnSincronizar = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lEstatus = new DevExpress.XtraEditors.LabelControl();
            this.GCatalogos = new DevExpress.XtraGrid.GridControl();
            this.GValCatalogos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDataBase = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GValCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.Location = new System.Drawing.Point(55, 22);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(61, 13);
            this.lFechaInicio.TabIndex = 0;
            this.lFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.EditValue = null;
            this.dtFechaInicio.Location = new System.Drawing.Point(117, 19);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtFechaInicio.TabIndex = 1;
            // 
            // lFechaFin
            // 
            this.lFechaFin.Location = new System.Drawing.Point(55, 49);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(50, 13);
            this.lFechaFin.TabIndex = 2;
            this.lFechaFin.Text = "Fecha Fin:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.EditValue = null;
            this.dtFechaFin.Location = new System.Drawing.Point(117, 46);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtFechaFin.TabIndex = 3;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSincronizar.ImageOptions.Image")));
            this.btnSincronizar.Location = new System.Drawing.Point(247, 17);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(83, 23);
            this.btnSincronizar.TabIndex = 4;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(55, 90);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(471, 18);
            this.progressBarControl1.TabIndex = 5;
            // 
            // lEstatus
            // 
            this.lEstatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lEstatus.Location = new System.Drawing.Point(55, 71);
            this.lEstatus.Name = "lEstatus";
            this.lEstatus.Size = new System.Drawing.Size(471, 13);
            this.lEstatus.TabIndex = 7;
            this.lEstatus.Text = "Estatus";
            // 
            // GCatalogos
            // 
            this.GCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCatalogos.Location = new System.Drawing.Point(12, 12);
            this.GCatalogos.MainView = this.GValCatalogos;
            this.GCatalogos.Name = "GCatalogos";
            this.GCatalogos.Size = new System.Drawing.Size(648, 299);
            this.GCatalogos.TabIndex = 8;
            this.GCatalogos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GValCatalogos});
            // 
            // GValCatalogos
            // 
            this.GValCatalogos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.GValCatalogos.GridControl = this.GCatalogos;
            this.GValCatalogos.Name = "GValCatalogos";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Actualiza";
            this.gridColumn1.FieldName = "Actualiza";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Catalogo";
            this.gridColumn5.FieldName = "Tabla";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDataBase);
            this.panelControl1.Controls.Add(this.lFechaInicio);
            this.panelControl1.Controls.Add(this.dtFechaInicio);
            this.panelControl1.Controls.Add(this.lEstatus);
            this.panelControl1.Controls.Add(this.lFechaFin);
            this.panelControl1.Controls.Add(this.progressBarControl1);
            this.panelControl1.Controls.Add(this.dtFechaFin);
            this.panelControl1.Controls.Add(this.btnSincronizar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(672, 123);
            this.panelControl1.TabIndex = 9;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.GCatalogos);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 123);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(672, 323);
            this.panelControl2.TabIndex = 10;
            // 
            // btnDataBase
            // 
            this.btnDataBase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnDataBase.Location = new System.Drawing.Point(0, 0);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(26, 23);
            this.btnDataBase.TabIndex = 8;
            this.btnDataBase.Click += new System.EventHandler(this.btnDataBase_Click);
            // 
            // Frm_Sincronizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 446);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_Sincronizar";
            this.Text = "Frm_Sincronizar";
            this.Shown += new System.EventHandler(this.Frm_Sincronizar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GValCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lFechaInicio;
        private DevExpress.XtraEditors.DateEdit dtFechaInicio;
        private DevExpress.XtraEditors.LabelControl lFechaFin;
        private DevExpress.XtraEditors.DateEdit dtFechaFin;
        private DevExpress.XtraEditors.SimpleButton btnSincronizar;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl lEstatus;
        private DevExpress.XtraGrid.GridControl GCatalogos;
        private DevExpress.XtraGrid.Views.Grid.GridView GValCatalogos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDataBase;
    }
}