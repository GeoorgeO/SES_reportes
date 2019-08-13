namespace BSC_Inventarios
{
    partial class Frm_Inventario_Ciego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inventario_Ciego));
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnGenera = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAbrir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnEnviar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.btnGuardar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIgualar = new DevExpress.XtraEditors.SimpleButton();
            this.Bar = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblEstatus = new DevExpress.XtraEditors.LabelControl();
            this.cboSucursales = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFolio = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgInventarioCiego = new DevExpress.XtraGrid.GridControl();
            this.dtgValInventarioCiego = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSucursales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventarioCiego)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValInventarioCiego)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bIconos,
            this.bEstado});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblProveedor,
            this.btnGenera,
            this.btnAbrir,
            this.btnGuardar,
            this.btnImprimir,
            this.btnEnviar,
            this.btnSalir});
            this.barManager2.MainMenu = this.bIconos;
            this.barManager2.MaxItemId = 64;
            this.barManager2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager2.StatusBar = this.bEstado;
            // 
            // bIconos
            // 
            this.bIconos.BarName = "Menú principal";
            this.bIconos.DockCol = 0;
            this.bIconos.DockRow = 0;
            this.bIconos.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bIconos.FloatLocation = new System.Drawing.Point(42, 184);
            this.bIconos.FloatSize = new System.Drawing.Size(1106, 535);
            this.bIconos.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenera),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAbrir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEnviar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir)});
            this.bIconos.OptionsBar.AllowCollapse = true;
            this.bIconos.OptionsBar.AllowQuickCustomization = false;
            this.bIconos.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bIconos.OptionsBar.DisableClose = true;
            this.bIconos.OptionsBar.DisableCustomization = true;
            this.bIconos.OptionsBar.DrawBorder = false;
            this.bIconos.OptionsBar.DrawDragBorder = false;
            this.bIconos.OptionsBar.RotateWhenVertical = false;
            this.bIconos.OptionsBar.UseWholeRow = true;
            this.bIconos.Text = "Menú principal";
            // 
            // btnGenera
            // 
            this.btnGenera.Caption = "Generar \r\nRevision";
            this.btnGenera.Id = 50;
            this.btnGenera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenera.ImageOptions.Image")));
            this.btnGenera.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGenera.ImageOptions.LargeImage")));
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenera_ItemClick);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Caption = "Abrir";
            this.btnAbrir.Id = 63;
            this.btnAbrir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.ImageOptions.Image")));
            this.btnAbrir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAbrir.ImageOptions.LargeImage")));
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbrir_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 51;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.LargeImage")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Caption = "Enviar";
            this.btnEnviar.Id = 57;
            this.btnEnviar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.ImageOptions.Image")));
            this.btnEnviar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.ImageOptions.LargeImage")));
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEnviar_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 59;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
            // 
            // bEstado
            // 
            this.bEstado.BarName = "Barra de estado";
            this.bEstado.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bEstado.DockCol = 0;
            this.bEstado.DockRow = 0;
            this.bEstado.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bEstado.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblProveedor)});
            this.bEstado.OptionsBar.AllowQuickCustomization = false;
            this.bEstado.OptionsBar.DrawDragBorder = false;
            this.bEstado.OptionsBar.UseWholeRow = true;
            this.bEstado.Text = "Barra de estado";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Caption = "Entrada:";
            this.lblProveedor.Id = 48;
            this.lblProveedor.Name = "lblProveedor";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(982, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 504);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(982, 25);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(59, 504);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(982, 0);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 504);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 53;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.LargeImage")));
            this.btnGuardar.Name = "btnGuardar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnIgualar);
            this.panelControl1.Controls.Add(this.Bar);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lblEstatus);
            this.panelControl1.Controls.Add(this.cboSucursales);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dtFecha);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtFolio);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(59, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(923, 74);
            this.panelControl1.TabIndex = 8;
            // 
            // btnIgualar
            // 
            this.btnIgualar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIgualar.ImageOptions.Image")));
            this.btnIgualar.Location = new System.Drawing.Point(627, 17);
            this.btnIgualar.Name = "btnIgualar";
            this.btnIgualar.Size = new System.Drawing.Size(97, 39);
            this.btnIgualar.TabIndex = 29;
            this.btnIgualar.Text = "Igualar \r\nConteos";
            this.btnIgualar.ToolTip = "Iguala el primer conteo al segundo conteo";
            this.btnIgualar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnIgualar.Click += new System.EventHandler(this.btnIgualar_Click);
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(55, 43);
            this.Bar.MenuManager = this.barManager2;
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(328, 18);
            this.Bar.TabIndex = 28;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Proceso";
            // 
            // lblEstatus
            // 
            this.lblEstatus.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatus.Appearance.Options.UseFont = true;
            this.lblEstatus.Location = new System.Drawing.Point(627, 15);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(0, 23);
            this.lblEstatus.TabIndex = 26;
            // 
            // cboSucursales
            // 
            this.cboSucursales.Enabled = false;
            this.cboSucursales.Location = new System.Drawing.Point(476, 16);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSucursales.Size = new System.Drawing.Size(123, 20);
            this.cboSucursales.TabIndex = 25;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(425, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Sucursal:";
            // 
            // dtFecha
            // 
            this.dtFecha.EditValue = null;
            this.dtFecha.Enabled = false;
            this.dtFecha.Location = new System.Drawing.Point(235, 16);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Size = new System.Drawing.Size(148, 20);
            this.dtFecha.TabIndex = 23;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(196, 20);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(33, 13);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "Fecha:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Folio";
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(55, 16);
            this.txtFolio.MenuManager = this.barManager2;
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Properties.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(100, 20);
            this.txtFolio.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgInventarioCiego);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(59, 74);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(923, 430);
            this.panelControl2.TabIndex = 9;
            // 
            // dtgInventarioCiego
            // 
            this.dtgInventarioCiego.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInventarioCiego.Location = new System.Drawing.Point(12, 12);
            this.dtgInventarioCiego.MainView = this.dtgValInventarioCiego;
            this.dtgInventarioCiego.MenuManager = this.barManager2;
            this.dtgInventarioCiego.Name = "dtgInventarioCiego";
            this.dtgInventarioCiego.Size = new System.Drawing.Size(899, 406);
            this.dtgInventarioCiego.TabIndex = 0;
            this.dtgInventarioCiego.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValInventarioCiego});
            // 
            // dtgValInventarioCiego
            // 
            this.dtgValInventarioCiego.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.dtgValInventarioCiego.GridControl = this.dtgInventarioCiego;
            this.dtgValInventarioCiego.Name = "dtgValInventarioCiego";
            this.dtgValInventarioCiego.OptionsView.ShowGroupPanel = false;
            this.dtgValInventarioCiego.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.dtgValInventarioCiego.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dtgValInventarioCiego_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "ArticuloCodigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 89;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripcion";
            this.gridColumn2.FieldName = "ArticuloDescripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 241;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Primer Conteo";
            this.gridColumn3.FieldName = "PrimerConteo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 59;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Segundo Conteo";
            this.gridColumn4.FieldName = "SegundoConteo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 63;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Familia";
            this.gridColumn5.FieldName = "FamiliaNombre";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 159;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ArticuloCantidad";
            this.gridColumn6.FieldName = "ArticuloCantidad";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 64;
            // 
            // Frm_Inventario_Ciego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 529);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "Frm_Inventario_Ciego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario Ciego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Frm_Inventario_Ciego_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSucursales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventarioCiego)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValInventarioCiego)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager2;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnGenera;
        private DevExpress.XtraBars.BarLargeButtonItem btnAbrir;
        private DevExpress.XtraBars.BarLargeButtonItem btnGuardar;
        private DevExpress.XtraBars.BarLargeButtonItem btnImprimir;
        private DevExpress.XtraBars.BarLargeButtonItem btnEnviar;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFolio;
        private DevExpress.XtraGrid.GridControl dtgInventarioCiego;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValInventarioCiego;
        private DevExpress.XtraEditors.DateEdit dtFecha;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LookUpEdit cboSucursales;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblEstatus;
        private DevExpress.XtraEditors.ProgressBarControl Bar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnIgualar;
    }
}