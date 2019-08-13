namespace BSC_Inventarios
{
    partial class Frm_Entradas_Buscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Entradas_Buscar));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.dtgEntradas = new DevExpress.XtraGrid.GridControl();
            this.dtgValEntradas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gFolio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gTipoEntrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRegistros = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEntradaFolio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntradaFolio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSeleccionar);
            this.panelControl2.Controls.Add(this.btnSalir);
            this.panelControl2.Controls.Add(this.btnConsultar);
            this.panelControl2.Controls.Add(this.dtgEntradas);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 76);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 70);
            this.panelControl2.Size = new System.Drawing.Size(512, 373);
            this.panelControl2.TabIndex = 5;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Appearance.Options.UseFont = true;
            this.btnSeleccionar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(182, 316);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(149, 40);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.Location = new System.Drawing.Point(321, 427);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(149, 54);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Appearance.Options.UseFont = true;
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(166, 427);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(149, 54);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Seleccionar";
            // 
            // dtgEntradas
            // 
            this.dtgEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEntradas.Location = new System.Drawing.Point(12, 12);
            this.dtgEntradas.MainView = this.dtgValEntradas;
            this.dtgEntradas.Name = "dtgEntradas";
            this.dtgEntradas.Size = new System.Drawing.Size(488, 289);
            this.dtgEntradas.TabIndex = 0;
            this.dtgEntradas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValEntradas});
            this.dtgEntradas.Click += new System.EventHandler(this.dtgEntradas_Click);
            // 
            // dtgValEntradas
            // 
            this.dtgValEntradas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gFolio,
            this.gCantidad,
            this.gTipoEntrada,
            this.gFecha});
            this.dtgValEntradas.GridControl = this.dtgEntradas;
            this.dtgValEntradas.Name = "dtgValEntradas";
            this.dtgValEntradas.OptionsView.ColumnAutoWidth = false;
            this.dtgValEntradas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.dtgValEntradas.OptionsView.ShowGroupPanel = false;
            // 
            // gFolio
            // 
            this.gFolio.Caption = "Folio Entrada";
            this.gFolio.FieldName = "EntradaMercanciaId";
            this.gFolio.Name = "gFolio";
            this.gFolio.OptionsColumn.AllowEdit = false;
            this.gFolio.OptionsColumn.ReadOnly = true;
            this.gFolio.OptionsColumn.ShowInExpressionEditor = false;
            this.gFolio.Visible = true;
            this.gFolio.VisibleIndex = 0;
            this.gFolio.Width = 68;
            // 
            // gCantidad
            // 
            this.gCantidad.Caption = "Cantidad Articulos";
            this.gCantidad.FieldName = "EntradaMercanciaUnidades";
            this.gCantidad.Name = "gCantidad";
            this.gCantidad.OptionsColumn.AllowEdit = false;
            this.gCantidad.OptionsColumn.ReadOnly = true;
            this.gCantidad.OptionsColumn.ShowInExpressionEditor = false;
            this.gCantidad.Visible = true;
            this.gCantidad.VisibleIndex = 2;
            this.gCantidad.Width = 81;
            // 
            // gTipoEntrada
            // 
            this.gTipoEntrada.Caption = "Tipo Entrada";
            this.gTipoEntrada.FieldName = "EntradaMercanciaTipoDescripcion";
            this.gTipoEntrada.Name = "gTipoEntrada";
            this.gTipoEntrada.OptionsColumn.AllowEdit = false;
            this.gTipoEntrada.Visible = true;
            this.gTipoEntrada.VisibleIndex = 1;
            this.gTipoEntrada.Width = 221;
            // 
            // gFecha
            // 
            this.gFecha.Caption = "Fecha Entrada";
            this.gFecha.FieldName = "EntradaMercanciaFecha";
            this.gFecha.Name = "gFecha";
            this.gFecha.OptionsColumn.AllowEdit = false;
            this.gFecha.Visible = true;
            this.gFecha.VisibleIndex = 3;
            this.gFecha.Width = 70;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dtFin);
            this.panelControl1.Controls.Add(this.dtInicio);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.cmbRegistros);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtEntradaFolio);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(512, 76);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(217, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Registro:";
            // 
            // cmbRegistros
            // 
            this.cmbRegistros.Location = new System.Drawing.Point(273, 13);
            this.cmbRegistros.Name = "cmbRegistros";
            this.cmbRegistros.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRegistros.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000"});
            this.cmbRegistros.Size = new System.Drawing.Size(100, 20);
            this.cmbRegistros.TabIndex = 16;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(403, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(84, 36);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(217, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Fecha Fin:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Fecha Inicio:";
            // 
            // txtEntradaFolio
            // 
            this.txtEntradaFolio.Location = new System.Drawing.Point(90, 13);
            this.txtEntradaFolio.Name = "txtEntradaFolio";
            this.txtEntradaFolio.Size = new System.Drawing.Size(100, 20);
            this.txtEntradaFolio.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Folio:";
            // 
            // dtFin
            // 
            this.dtFin.EditValue = null;
            this.dtFin.Location = new System.Drawing.Point(273, 42);
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtFin.Size = new System.Drawing.Size(100, 20);
            this.dtFin.TabIndex = 19;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(90, 42);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtInicio.Size = new System.Drawing.Size(100, 20);
            this.dtInicio.TabIndex = 18;
            // 
            // Frm_Entradas_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 449);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Entradas_Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Entradas";
            this.Shown += new System.EventHandler(this.Frm_Entradas_Buscar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntradaFolio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl dtgEntradas;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValEntradas;
        private DevExpress.XtraGrid.Columns.GridColumn gFolio;
        private DevExpress.XtraGrid.Columns.GridColumn gCantidad;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEntradaFolio;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gTipoEntrada;
        private DevExpress.XtraGrid.Columns.GridColumn gFecha;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRegistros;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private DevExpress.XtraEditors.DateEdit dtInicio;
    }
}