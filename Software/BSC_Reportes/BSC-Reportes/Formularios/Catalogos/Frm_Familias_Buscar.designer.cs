namespace BSC_Reportes
{
    partial class Frm_BFamilias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BFamilias));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.trlFamilia = new DevExpress.XtraTreeList.TreeList();
            this.TrFamilia = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlFamilia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSalir);
            this.panelControl2.Controls.Add(this.btnConsultar);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 371);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(442, 85);
            this.panelControl2.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.Location = new System.Drawing.Point(227, 15);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(149, 54);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Appearance.Options.UseFont = true;
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(72, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(149, 54);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Seleccionar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.trlFamilia);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(442, 371);
            this.panelControl1.TabIndex = 2;
            // 
            // trlFamilia
            // 
            this.trlFamilia.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.TrFamilia});
            this.trlFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlFamilia.Location = new System.Drawing.Point(7, 7);
            this.trlFamilia.Name = "trlFamilia";
            this.trlFamilia.Size = new System.Drawing.Size(428, 357);
            this.trlFamilia.TabIndex = 0;
            this.trlFamilia.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlFamilia_FocusedNodeChanged);
            // 
            // TrFamilia
            // 
            this.TrFamilia.Caption = "Nombre Familias";
            this.TrFamilia.FieldName = "TrFamilia";
            this.TrFamilia.Name = "TrFamilia";
            this.TrFamilia.OptionsColumn.AllowEdit = false;
            this.TrFamilia.OptionsColumn.AllowSort = false;
            this.TrFamilia.Visible = true;
            this.TrFamilia.VisibleIndex = 0;
            // 
            // Frm_BFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 456);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_BFamilias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Familias";
            this.Load += new System.EventHandler(this.Frm_BFamilias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlFamilia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList trlFamilia;
        private DevExpress.XtraTreeList.Columns.TreeListColumn TrFamilia;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
    }
}