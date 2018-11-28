namespace BSC_Reportes
{
    partial class Frm_Pedidos_Buscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Pedidos_Buscar));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnSeleccionar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPrePedidos = new DevExpress.XtraGrid.GridControl();
            this.dtgValPrePedidos = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.PrePedidoId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ProveedorNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.FechaInicio = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.FechaFin = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProveedorNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProveedorId = new DevExpress.XtraEditors.TextEdit();
            this.btnImpProveedor = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem3 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.chkFecha = new DevExpress.XtraEditors.CheckEdit();
            this.chkProveedor = new DevExpress.XtraEditors.CheckEdit();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrePedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPrePedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProveedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bIconos,
            this.bEstado});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSeleccionar,
            this.barLargeButtonItem1,
            this.barEditItem1,
            this.lblProveedor,
            this.barLargeButtonItem2,
            this.barLargeButtonItem3});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 51;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bEstado;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSeleccionar)});
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
            // btnSeleccionar
            // 
            this.btnSeleccionar.Caption = "Seleccionar";
            this.btnSeleccionar.Id = 17;
            this.btnSeleccionar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.Image")));
            this.btnSeleccionar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.LargeImage")));
            this.btnSeleccionar.Name = "btnSeleccionar";
            toolTipItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem2.Appearance.Options.UseImage = true;
            toolTipItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem2.Image")));
            toolTipTitleItem2.Text = "Seleccionar";
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnSeleccionar.SuperTip = superToolTip2;
            this.btnSeleccionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSeleccionar_ItemClick);
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
            this.lblProveedor.Caption = "Folio:";
            this.lblProveedor.Id = 48;
            this.lblProveedor.Name = "lblProveedor";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(828, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 414);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(828, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(71, 414);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(828, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 414);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Id = 46;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 47;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(71, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(757, 99);
            this.panelControl2.TabIndex = 16;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dtgPrePedidos);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(71, 99);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(757, 315);
            this.panelControl1.TabIndex = 17;
            // 
            // dtgPrePedidos
            // 
            this.dtgPrePedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPrePedidos.Location = new System.Drawing.Point(12, 12);
            this.dtgPrePedidos.MainView = this.dtgValPrePedidos;
            this.dtgPrePedidos.Name = "dtgPrePedidos";
            this.dtgPrePedidos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.dtgPrePedidos.Size = new System.Drawing.Size(733, 291);
            this.dtgPrePedidos.TabIndex = 4;
            this.dtgPrePedidos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValPrePedidos});
            this.dtgPrePedidos.Click += new System.EventHandler(this.dtgPrePedidos_Click);
            this.dtgPrePedidos.DoubleClick += new System.EventHandler(this.dtgPrePedidos_DoubleClick);
            // 
            // dtgValPrePedidos
            // 
            this.dtgValPrePedidos.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.dtgValPrePedidos.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.PrePedidoId,
            this.ProveedorNombre,
            this.FechaInicio,
            this.FechaFin,
            this.gridColumn1,
            this.bandedGridColumn1});
            this.dtgValPrePedidos.GridControl = this.dtgPrePedidos;
            this.dtgValPrePedidos.Name = "dtgValPrePedidos";
            this.dtgValPrePedidos.OptionsFind.AlwaysVisible = true;
            this.dtgValPrePedidos.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Articulo";
            this.gridBand1.Columns.Add(this.PrePedidoId);
            this.gridBand1.Columns.Add(this.ProveedorNombre);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 410;
            // 
            // PrePedidoId
            // 
            this.PrePedidoId.Caption = "Folio";
            this.PrePedidoId.FieldName = "PrePedidosId";
            this.PrePedidoId.Name = "PrePedidoId";
            this.PrePedidoId.OptionsColumn.AllowEdit = false;
            this.PrePedidoId.OptionsColumn.AllowMove = false;
            this.PrePedidoId.Visible = true;
            this.PrePedidoId.Width = 106;
            // 
            // ProveedorNombre
            // 
            this.ProveedorNombre.Caption = "Proveedor";
            this.ProveedorNombre.FieldName = "ProveedorNombre";
            this.ProveedorNombre.Name = "ProveedorNombre";
            this.ProveedorNombre.OptionsColumn.AllowEdit = false;
            this.ProveedorNombre.OptionsColumn.AllowMove = false;
            this.ProveedorNombre.Visible = true;
            this.ProveedorNombre.Width = 304;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Periodo";
            this.gridBand2.Columns.Add(this.FechaInicio);
            this.gridBand2.Columns.Add(this.FechaFin);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 150;
            // 
            // FechaInicio
            // 
            this.FechaInicio.Caption = "F. Inicio";
            this.FechaInicio.FieldName = "FechaInicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Visible = true;
            // 
            // FechaFin
            // 
            this.FechaFin.Caption = "F. Fin";
            this.FechaFin.FieldName = "FechaFin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Creacion";
            this.gridBand3.Columns.Add(this.gridColumn1);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 75;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha Creacion";
            this.gridColumn1.FieldName = "FechaInsert";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "Buscar";
            this.barLargeButtonItem2.Id = 49;
            this.barLargeButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem2.ImageOptions.Image")));
            this.barLargeButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem2.ImageOptions.LargeImage")));
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkProveedor);
            this.groupControl1.Controls.Add(this.chkFecha);
            this.groupControl1.Controls.Add(this.txtProveedorNombre);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtProveedorId);
            this.groupControl1.Controls.Add(this.dtFin);
            this.groupControl1.Controls.Add(this.dtInicio);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(505, 85);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Parametros";
            // 
            // dtFin
            // 
            this.dtFin.EditValue = null;
            this.dtFin.Location = new System.Drawing.Point(282, 25);
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtFin.Size = new System.Drawing.Size(100, 20);
            this.dtFin.TabIndex = 11;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(91, 25);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtInicio.Size = new System.Drawing.Size(100, 20);
            this.dtInicio.TabIndex = 10;
            this.dtInicio.EditValueChanged += new System.EventHandler(this.dtInicio_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(217, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Fecha Fin:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Fecha Inicio:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtProveedorNombre
            // 
            this.txtProveedorNombre.Location = new System.Drawing.Point(140, 51);
            this.txtProveedorNombre.Name = "txtProveedorNombre";
            this.txtProveedorNombre.Properties.ReadOnly = true;
            this.txtProveedorNombre.Size = new System.Drawing.Size(242, 20);
            this.txtProveedorNombre.TabIndex = 14;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Proveedor:";
            // 
            // txtProveedorId
            // 
            this.txtProveedorId.Location = new System.Drawing.Point(91, 51);
            this.txtProveedorId.Name = "txtProveedorId";
            this.txtProveedorId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProveedorId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtProveedorId.Properties.Mask.EditMask = "n0";
            this.txtProveedorId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProveedorId.Size = new System.Drawing.Size(43, 20);
            this.txtProveedorId.TabIndex = 12;
            // 
            // btnImpProveedor
            // 
            this.btnImpProveedor.Caption = "  Importar \r\nProveedor";
            this.btnImpProveedor.Id = 52;
            this.btnImpProveedor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImpProveedor.ImageOptions.Image")));
            this.btnImpProveedor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImpProveedor.ImageOptions.LargeImage")));
            this.btnImpProveedor.Name = "btnImpProveedor";
            // 
            // barLargeButtonItem3
            // 
            this.barLargeButtonItem3.Caption = " Importar \r\nProveedor";
            this.barLargeButtonItem3.Id = 50;
            this.barLargeButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem3.ImageOptions.Image")));
            this.barLargeButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem3.ImageOptions.LargeImage")));
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            // 
            // chkFecha
            // 
            this.chkFecha.Location = new System.Drawing.Point(410, 28);
            this.chkFecha.MenuManager = this.barManager1;
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Properties.Caption = "Fecha";
            this.chkFecha.Size = new System.Drawing.Size(75, 19);
            this.chkFecha.TabIndex = 15;
            // 
            // chkProveedor
            // 
            this.chkProveedor.Location = new System.Drawing.Point(410, 49);
            this.chkProveedor.MenuManager = this.barManager1;
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.Properties.Caption = "Proveedor";
            this.chkProveedor.Size = new System.Drawing.Size(75, 19);
            this.chkProveedor.TabIndex = 16;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Estaus";
            this.bandedGridColumn1.FieldName = "Estatus";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // Frm_Pedidos_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 439);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_Pedidos_Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Pedidos";
            this.Shown += new System.EventHandler(this.Frm_Pre_Pedidos_Buscar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrePedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPrePedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProveedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        public DevExpress.XtraBars.BarLargeButtonItem btnSeleccionar;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dtgPrePedidos;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView dtgValPrePedidos;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PrePedidoId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ProveedorNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn FechaInicio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn FechaFin;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtProveedorNombre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtProveedorId;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem3;
        private DevExpress.XtraEditors.CheckEdit chkProveedor;
        private DevExpress.XtraEditors.CheckEdit chkFecha;
        private DevExpress.XtraBars.BarLargeButtonItem btnImpProveedor;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
    }
}