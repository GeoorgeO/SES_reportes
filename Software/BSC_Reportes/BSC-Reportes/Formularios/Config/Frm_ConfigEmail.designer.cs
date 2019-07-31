namespace BSC_Reportes
{
    partial class Frm_ConfigEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConfigEmail));
            this.txtCorreoPuerto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSeguridadSSL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoServerEntrante = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoServerSaliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoRemitente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnProbar = new DevExpress.XtraEditors.SimpleButton();
            this.cboReportes = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoDestino = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dtgCorreosDestino = new DevExpress.XtraGrid.GridControl();
            this.dtgValoresCorreosDestino = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoPuerto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeguridadSSL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoServerEntrante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoServerSaliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRemitente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCorreosDestino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresCorreosDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCorreoPuerto
            // 
            this.txtCorreoPuerto.Location = new System.Drawing.Point(161, 173);
            this.txtCorreoPuerto.Name = "txtCorreoPuerto";
            this.txtCorreoPuerto.Properties.MaxLength = 6;
            this.txtCorreoPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtCorreoPuerto.TabIndex = 36;
            this.txtCorreoPuerto.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoPuerto_Paint);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(78, 175);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(72, 13);
            this.labelControl19.TabIndex = 35;
            this.labelControl19.Text = "Correo Puerto:";
            // 
            // cmbSeguridadSSL
            // 
            this.cmbSeguridadSSL.Location = new System.Drawing.Point(161, 147);
            this.cmbSeguridadSSL.Name = "cmbSeguridadSSL";
            this.cmbSeguridadSSL.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbSeguridadSSL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbSeguridadSSL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSeguridadSSL.Properties.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbSeguridadSSL.Properties.NullText = "Selecciona SSL";
            this.cmbSeguridadSSL.Size = new System.Drawing.Size(100, 20);
            this.cmbSeguridadSSL.TabIndex = 34;
            this.cmbSeguridadSSL.Paint += new System.Windows.Forms.PaintEventHandler(this.cmbSeguridadSSL_Paint);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(42, 149);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(108, 13);
            this.labelControl14.TabIndex = 33;
            this.labelControl14.Text = "Correo Seguridad SSL:";
            // 
            // txtCorreoServerEntrante
            // 
            this.txtCorreoServerEntrante.Location = new System.Drawing.Point(161, 121);
            this.txtCorreoServerEntrante.Name = "txtCorreoServerEntrante";
            this.txtCorreoServerEntrante.Size = new System.Drawing.Size(199, 20);
            this.txtCorreoServerEntrante.TabIndex = 32;
            this.txtCorreoServerEntrante.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoServerEntrante_Paint);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(25, 123);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(125, 13);
            this.labelControl13.TabIndex = 31;
            this.labelControl13.Text = "Correo Servidor Entrante:";
            // 
            // txtCorreoServerSaliente
            // 
            this.txtCorreoServerSaliente.Location = new System.Drawing.Point(161, 95);
            this.txtCorreoServerSaliente.Name = "txtCorreoServerSaliente";
            this.txtCorreoServerSaliente.Size = new System.Drawing.Size(199, 20);
            this.txtCorreoServerSaliente.TabIndex = 30;
            this.txtCorreoServerSaliente.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoServerSaliente_Paint);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(29, 97);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(121, 13);
            this.labelControl12.TabIndex = 29;
            this.labelControl12.Text = "Correo Servidor Saliente:";
            // 
            // txtCorreoPass
            // 
            this.txtCorreoPass.Location = new System.Drawing.Point(161, 69);
            this.txtCorreoPass.Name = "txtCorreoPass";
            this.txtCorreoPass.Properties.PasswordChar = '*';
            this.txtCorreoPass.Size = new System.Drawing.Size(100, 20);
            this.txtCorreoPass.TabIndex = 28;
            this.txtCorreoPass.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoPass_Paint);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(64, 71);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(86, 13);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "Correo Password:";
            // 
            // txtCorreoUser
            // 
            this.txtCorreoUser.Location = new System.Drawing.Point(161, 43);
            this.txtCorreoUser.Name = "txtCorreoUser";
            this.txtCorreoUser.Size = new System.Drawing.Size(199, 20);
            this.txtCorreoUser.TabIndex = 26;
            this.txtCorreoUser.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoUser_Paint);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(78, 45);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(72, 13);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "Correo Usuario";
            // 
            // txtCorreoRemitente
            // 
            this.txtCorreoRemitente.Location = new System.Drawing.Point(161, 15);
            this.txtCorreoRemitente.Name = "txtCorreoRemitente";
            this.txtCorreoRemitente.Size = new System.Drawing.Size(199, 20);
            this.txtCorreoRemitente.TabIndex = 24;
            this.txtCorreoRemitente.Paint += new System.Windows.Forms.PaintEventHandler(this.txtCorreoRemitente_Paint);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(61, 17);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(89, 13);
            this.labelControl9.TabIndex = 23;
            this.labelControl9.Text = "Correo Remitente:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(374, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 44);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar Config";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.separatorControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btnProbar);
            this.panelControl1.Controls.Add(this.cboReportes);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnGuardar);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtCorreoRemitente);
            this.panelControl1.Controls.Add(this.txtCorreoDestino);
            this.panelControl1.Controls.Add(this.txtCorreoPuerto);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl19);
            this.panelControl1.Controls.Add(this.txtCorreoUser);
            this.panelControl1.Controls.Add(this.cmbSeguridadSSL);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.labelControl14);
            this.panelControl1.Controls.Add(this.txtCorreoPass);
            this.panelControl1.Controls.Add(this.txtCorreoServerEntrante);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.txtCorreoServerSaliente);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(566, 268);
            this.panelControl1.TabIndex = 38;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(3, 191);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(560, 19);
            this.separatorControl1.TabIndex = 41;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(107, 246);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "Reporte:";
            // 
            // btnProbar
            // 
            this.btnProbar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbar.Appearance.Options.UseFont = true;
            this.btnProbar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProbar.ImageOptions.Image")));
            this.btnProbar.Location = new System.Drawing.Point(374, 91);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(147, 44);
            this.btnProbar.TabIndex = 38;
            this.btnProbar.Text = "Probar Config";
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // cboReportes
            // 
            this.cboReportes.Location = new System.Drawing.Point(161, 242);
            this.cboReportes.Name = "cboReportes";
            this.cboReportes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReportes.Size = new System.Drawing.Size(199, 20);
            this.cboReportes.TabIndex = 39;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Appearance.Options.UseFont = true;
            this.btnAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.ImageOptions.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(374, 218);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(147, 44);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Text = "Agregar Correo";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(74, 219);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Correo Destino:";
            // 
            // txtCorreoDestino
            // 
            this.txtCorreoDestino.Location = new System.Drawing.Point(161, 216);
            this.txtCorreoDestino.Name = "txtCorreoDestino";
            this.txtCorreoDestino.Size = new System.Drawing.Size(199, 20);
            this.txtCorreoDestino.TabIndex = 28;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.dtgCorreosDestino);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 268);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl3.Size = new System.Drawing.Size(566, 240);
            this.panelControl3.TabIndex = 40;
            // 
            // dtgCorreosDestino
            // 
            this.dtgCorreosDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCorreosDestino.Location = new System.Drawing.Point(10, 10);
            this.dtgCorreosDestino.MainView = this.dtgValoresCorreosDestino;
            this.dtgCorreosDestino.Name = "dtgCorreosDestino";
            this.dtgCorreosDestino.Size = new System.Drawing.Size(546, 220);
            this.dtgCorreosDestino.TabIndex = 4;
            this.dtgCorreosDestino.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValoresCorreosDestino});
            this.dtgCorreosDestino.Click += new System.EventHandler(this.dtgCorreosDestino_Click);
            this.dtgCorreosDestino.DoubleClick += new System.EventHandler(this.dtgCorreosDestino_DoubleClick);
            // 
            // dtgValoresCorreosDestino
            // 
            this.dtgValoresCorreosDestino.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.dtgValoresCorreosDestino.GridControl = this.dtgCorreosDestino;
            this.dtgValoresCorreosDestino.Name = "dtgValoresCorreosDestino";
            this.dtgValoresCorreosDestino.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresCorreosDestino.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresCorreosDestino.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresCorreosDestino.OptionsBehavior.Editable = false;
            this.dtgValoresCorreosDestino.OptionsBehavior.ReadOnly = true;
            this.dtgValoresCorreosDestino.OptionsCustomization.AllowColumnMoving = false;
            this.dtgValoresCorreosDestino.OptionsSelection.MultiSelect = true;
            this.dtgValoresCorreosDestino.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.dtgValoresCorreosDestino.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "IdCorreo";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "CorreoNombre";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "ReporteNombre";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // Frm_ConfigEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 508);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_ConfigEmail";
            this.Text = "Configuracion Email";
            this.Load += new System.EventHandler(this.Frm_ConfigEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoPuerto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeguridadSSL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoServerEntrante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoServerSaliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRemitente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCorreosDestino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresCorreosDestino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCorreoPuerto;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSeguridadSSL;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtCorreoServerEntrante;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtCorreoServerSaliente;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtCorreoPass;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtCorreoUser;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtCorreoRemitente;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCorreoDestino;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnProbar;
        private DevExpress.XtraGrid.GridControl dtgCorreosDestino;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValoresCorreosDestino;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboReportes;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}