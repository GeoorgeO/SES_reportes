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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Sincronizar));
            this.lFechaInicio = new DevExpress.XtraEditors.LabelControl();
            this.dtFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.lFechaFin = new DevExpress.XtraEditors.LabelControl();
            this.dtFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.btnSincronizar = new DevExpress.XtraEditors.SimpleButton();
            this.lEstatus = new DevExpress.XtraEditors.LabelControl();
            this.GCatalogos = new DevExpress.XtraGrid.GridControl();
            this.GValCatalogos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkTodos = new DevExpress.XtraEditors.CheckEdit();
            this.btnDataBase = new DevExpress.XtraEditors.SimpleButton();
            this.pbProgreso = new DevExpress.XtraEditors.ProgressBarControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.SkinForm = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btn_CierreVentas = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GValCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.Location = new System.Drawing.Point(65, 32);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(61, 13);
            this.lFechaInicio.TabIndex = 0;
            this.lFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.EditValue = null;
            this.dtFechaInicio.Location = new System.Drawing.Point(131, 26);
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
            this.lFechaFin.Location = new System.Drawing.Point(65, 59);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(50, 13);
            this.lFechaFin.TabIndex = 2;
            this.lFechaFin.Text = "Fecha Fin:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.EditValue = null;
            this.dtFechaFin.Location = new System.Drawing.Point(131, 53);
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
            this.btnSincronizar.Location = new System.Drawing.Point(261, 24);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(83, 23);
            this.btnSincronizar.TabIndex = 4;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // lEstatus
            // 
            this.lEstatus.Appearance.Options.UseTextOptions = true;
            this.lEstatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lEstatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lEstatus.Location = new System.Drawing.Point(101, 76);
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
            this.GCatalogos.Size = new System.Drawing.Size(648, 565);
            this.GCatalogos.TabIndex = 8;
            this.GCatalogos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GValCatalogos});
            // 
            // GValCatalogos
            // 
            this.GValCatalogos.GridControl = this.GCatalogos;
            this.GValCatalogos.Name = "GValCatalogos";
            this.GValCatalogos.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_CierreVentas);
            this.panelControl1.Controls.Add(this.chkTodos);
            this.panelControl1.Controls.Add(this.btnDataBase);
            this.panelControl1.Controls.Add(this.lFechaInicio);
            this.panelControl1.Controls.Add(this.dtFechaInicio);
            this.panelControl1.Controls.Add(this.lEstatus);
            this.panelControl1.Controls.Add(this.lFechaFin);
            this.panelControl1.Controls.Add(this.dtFechaFin);
            this.panelControl1.Controls.Add(this.btnSincronizar);
            this.panelControl1.Controls.Add(this.pbProgreso);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(672, 123);
            this.panelControl1.TabIndex = 9;
            // 
            // chkTodos
            // 
            this.chkTodos.Location = new System.Drawing.Point(261, 51);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Properties.Caption = "Todos";
            this.chkTodos.Size = new System.Drawing.Size(75, 19);
            this.chkTodos.TabIndex = 9;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // btnDataBase
            // 
            this.btnDataBase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDataBase.ImageOptions.Image")));
            this.btnDataBase.Location = new System.Drawing.Point(15, 12);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(26, 23);
            this.btnDataBase.TabIndex = 8;
            this.btnDataBase.Click += new System.EventHandler(this.btnDataBase_Click);
            // 
            // pbProgreso
            // 
            this.pbProgreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgreso.EditValue = 50;
            this.pbProgreso.Location = new System.Drawing.Point(12, 93);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Properties.ShowTitle = true;
            this.pbProgreso.Size = new System.Drawing.Size(648, 18);
            this.pbProgreso.TabIndex = 5;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.GCatalogos);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 123);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(672, 589);
            this.panelControl2.TabIndex = 10;
            // 
            // SkinForm
            // 
            this.SkinForm.EnableBonusSkins = true;
            this.SkinForm.LookAndFeel.SkinName = "Sharp";
            // 
            // btn_CierreVentas
            // 
            this.btn_CierreVentas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_CierreVentas.Location = new System.Drawing.Point(478, 24);
            this.btn_CierreVentas.Name = "btn_CierreVentas";
            this.btn_CierreVentas.Size = new System.Drawing.Size(116, 46);
            this.btn_CierreVentas.TabIndex = 10;
            this.btn_CierreVentas.Text = "Enviar Cierre\r\n de Ventas";
            this.btn_CierreVentas.Click += new System.EventHandler(this.btn_CierreVentas_Click);
            // 
            // Frm_Sincronizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 712);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Sincronizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Sincronizar";
            this.Shown += new System.EventHandler(this.Frm_Sincronizar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GValCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgreso.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lEstatus;
        private DevExpress.XtraGrid.GridControl GCatalogos;
        private DevExpress.XtraGrid.Views.Grid.GridView GValCatalogos;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDataBase;
        private DevExpress.XtraEditors.CheckEdit chkTodos;
        private DevExpress.LookAndFeel.DefaultLookAndFeel SkinForm;
        private DevExpress.XtraEditors.ProgressBarControl pbProgreso;
        private DevExpress.XtraEditors.SimpleButton btn_CierreVentas;
    }
}