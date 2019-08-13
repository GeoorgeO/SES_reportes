namespace BSC_Inventarios
{
    partial class Frm_Usuario_Pantalla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Usuario_Pantalla));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbUsuarios = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtgDisponibles = new DevExpress.XtraGrid.GridControl();
            this.dtgValDisponibles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDispone = new DevExpress.XtraEditors.SimpleButton();
            this.btnAsigna = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisponeTodos = new DevExpress.XtraEditors.SimpleButton();
            this.btnAsignaTodos = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dtgAsignadas = new DevExpress.XtraGrid.GridControl();
            this.dtgValAsignadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsuarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValAsignadas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbUsuarios);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(783, 60);
            this.panelControl1.TabIndex = 0;
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.Location = new System.Drawing.Point(72, 20);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUsuarios.Size = new System.Drawing.Size(497, 20);
            this.cmbUsuarios.TabIndex = 1;
            this.cmbUsuarios.EditValueChanged += new System.EventHandler(this.cmbUsuarios_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 60);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(359, 385);
            this.panelControl2.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtgDisponibles);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(345, 371);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Disponibles";
            // 
            // dtgDisponibles
            // 
            this.dtgDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDisponibles.Location = new System.Drawing.Point(7, 27);
            this.dtgDisponibles.MainView = this.dtgValDisponibles;
            this.dtgDisponibles.Name = "dtgDisponibles";
            this.dtgDisponibles.Size = new System.Drawing.Size(331, 337);
            this.dtgDisponibles.TabIndex = 0;
            this.dtgDisponibles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValDisponibles});
            this.dtgDisponibles.Click += new System.EventHandler(this.dtgDisponibles_Click);
            // 
            // dtgValDisponibles
            // 
            this.dtgValDisponibles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.dtgValDisponibles.GridControl = this.dtgDisponibles;
            this.dtgValDisponibles.Name = "dtgValDisponibles";
            this.dtgValDisponibles.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dtgValDisponibles.OptionsSelection.MultiSelect = true;
            this.dtgValDisponibles.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Pantalla";
            this.gridColumn2.FieldName = "InventarioPantallaNombre";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "InventarioPantallaId";
            this.gridColumn3.FieldName = "InventarioPantallaId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 163;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDispone);
            this.panelControl3.Controls.Add(this.btnAsigna);
            this.panelControl3.Controls.Add(this.btnDisponeTodos);
            this.panelControl3.Controls.Add(this.btnAsignaTodos);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(359, 60);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(60, 385);
            this.panelControl3.TabIndex = 2;
            // 
            // btnDispone
            // 
            this.btnDispone.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDispone.ImageOptions.Image")));
            this.btnDispone.Location = new System.Drawing.Point(10, 172);
            this.btnDispone.Name = "btnDispone";
            this.btnDispone.Size = new System.Drawing.Size(40, 40);
            this.btnDispone.TabIndex = 3;
            this.btnDispone.Click += new System.EventHandler(this.btnDispone_Click);
            // 
            // btnAsigna
            // 
            this.btnAsigna.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAsigna.ImageOptions.Image")));
            this.btnAsigna.Location = new System.Drawing.Point(10, 126);
            this.btnAsigna.Name = "btnAsigna";
            this.btnAsigna.Size = new System.Drawing.Size(40, 40);
            this.btnAsigna.TabIndex = 2;
            this.btnAsigna.Click += new System.EventHandler(this.btnAsigna_Click);
            // 
            // btnDisponeTodos
            // 
            this.btnDisponeTodos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisponeTodos.ImageOptions.Image")));
            this.btnDisponeTodos.Location = new System.Drawing.Point(10, 80);
            this.btnDisponeTodos.Name = "btnDisponeTodos";
            this.btnDisponeTodos.Size = new System.Drawing.Size(40, 40);
            this.btnDisponeTodos.TabIndex = 1;
            this.btnDisponeTodos.Click += new System.EventHandler(this.btnDisponeTodos_Click);
            // 
            // btnAsignaTodos
            // 
            this.btnAsignaTodos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAsignaTodos.ImageOptions.Image")));
            this.btnAsignaTodos.Location = new System.Drawing.Point(11, 34);
            this.btnAsignaTodos.Name = "btnAsignaTodos";
            this.btnAsignaTodos.Size = new System.Drawing.Size(40, 40);
            this.btnAsignaTodos.TabIndex = 0;
            this.btnAsignaTodos.Click += new System.EventHandler(this.btnAsignaTodos_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.groupControl2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(419, 60);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl4.Size = new System.Drawing.Size(359, 385);
            this.panelControl4.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dtgAsignadas);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(7, 7);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(345, 371);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Asignadas";
            // 
            // dtgAsignadas
            // 
            this.dtgAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAsignadas.Location = new System.Drawing.Point(7, 27);
            this.dtgAsignadas.MainView = this.dtgValAsignadas;
            this.dtgAsignadas.Name = "dtgAsignadas";
            this.dtgAsignadas.Size = new System.Drawing.Size(331, 337);
            this.dtgAsignadas.TabIndex = 1;
            this.dtgAsignadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValAsignadas});
            this.dtgAsignadas.Click += new System.EventHandler(this.dtgAsignadas_Click);
            // 
            // dtgValAsignadas
            // 
            this.dtgValAsignadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4});
            this.dtgValAsignadas.GridControl = this.dtgAsignadas;
            this.dtgValAsignadas.Name = "dtgValAsignadas";
            this.dtgValAsignadas.OptionsSelection.MultiSelect = true;
            this.dtgValAsignadas.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Pantalla";
            this.gridColumn1.FieldName = "InventarioPantallaNombre";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "InventarioPantallaId";
            this.gridColumn4.FieldName = "InventarioPantallaId";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // Frm_Usuario_Pantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 445);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Usuario_Pantalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario Pantalla";
            this.Shown += new System.EventHandler(this.Frm_Usuario_Pantalla_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsuarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValAsignadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbUsuarios;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dtgDisponibles;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValDisponibles;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dtgAsignadas;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValAsignadas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnDispone;
        private DevExpress.XtraEditors.SimpleButton btnAsigna;
        private DevExpress.XtraEditors.SimpleButton btnDisponeTodos;
        private DevExpress.XtraEditors.SimpleButton btnAsignaTodos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}