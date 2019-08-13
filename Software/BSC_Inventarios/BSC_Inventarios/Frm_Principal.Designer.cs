namespace BSC_Inventarios
{
    partial class Frm_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEntrada = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalida = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventarioCiego = new DevExpress.XtraBars.BarButtonItem();
            this.btnRevisionContraloria = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfigEmail = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnUsuarioPantalla = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.SkinForm = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnEntrada,
            this.btnSalida,
            this.btnInventarioCiego,
            this.btnRevisionContraloria,
            this.barButtonItem5,
            this.btnConfig,
            this.btnConfigEmail,
            this.skinRibbonGalleryBarItem1,
            this.btnUsuarioPantalla});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl1.Size = new System.Drawing.Size(782, 143);
            // 
            // btnEntrada
            // 
            this.btnEntrada.Caption = "Entradas";
            this.btnEntrada.Id = 1;
            this.btnEntrada.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrada.ImageOptions.Image")));
            this.btnEntrada.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEntrada.ImageOptions.LargeImage")));
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEntrada_ItemClick);
            // 
            // btnSalida
            // 
            this.btnSalida.Caption = "Salidas";
            this.btnSalida.Id = 2;
            this.btnSalida.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalida.ImageOptions.Image")));
            this.btnSalida.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalida.ImageOptions.LargeImage")));
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalida_ItemClick);
            // 
            // btnInventarioCiego
            // 
            this.btnInventarioCiego.Caption = "Inventario Ciego";
            this.btnInventarioCiego.Id = 3;
            this.btnInventarioCiego.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInventarioCiego.ImageOptions.Image")));
            this.btnInventarioCiego.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInventarioCiego.ImageOptions.LargeImage")));
            this.btnInventarioCiego.Name = "btnInventarioCiego";
            this.btnInventarioCiego.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInventarioCiego_ItemClick);
            // 
            // btnRevisionContraloria
            // 
            this.btnRevisionContraloria.Caption = "Revision Contraloria";
            this.btnRevisionContraloria.Id = 4;
            this.btnRevisionContraloria.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRevisionContraloria.ImageOptions.Image")));
            this.btnRevisionContraloria.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRevisionContraloria.ImageOptions.LargeImage")));
            this.btnRevisionContraloria.Name = "btnRevisionContraloria";
            this.btnRevisionContraloria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRevisionContraloria_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Parametros";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // btnConfig
            // 
            this.btnConfig.Caption = "Config Articulos Diarios";
            this.btnConfig.Id = 6;
            this.btnConfig.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.ImageOptions.Image")));
            this.btnConfig.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnConfig.ImageOptions.LargeImage")));
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfig_ItemClick);
            // 
            // btnConfigEmail
            // 
            this.btnConfigEmail.Caption = "Config Email";
            this.btnConfigEmail.Id = 7;
            this.btnConfigEmail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigEmail.ImageOptions.Image")));
            this.btnConfigEmail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnConfigEmail.ImageOptions.LargeImage")));
            this.btnConfigEmail.Name = "btnConfigEmail";
            this.btnConfigEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfigEmail_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 8;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // btnUsuarioPantalla
            // 
            this.btnUsuarioPantalla.Caption = "Usuario Pantallas";
            this.btnUsuarioPantalla.Id = 9;
            this.btnUsuarioPantalla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarioPantalla.ImageOptions.Image")));
            this.btnUsuarioPantalla.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUsuarioPantalla.ImageOptions.LargeImage")));
            this.btnUsuarioPantalla.Name = "btnUsuarioPantalla";
            this.btnUsuarioPantalla.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsuarioPantalla_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Inventario";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInventarioCiego);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRevisionContraloria);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Inventario";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.btnConfig);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnConfigEmail);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnUsuarioPantalla);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Configuracion";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Movimientos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEntrada);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalida);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Movimientos Inventario";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Interfaz";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Interfaz";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // SkinForm
            // 
            this.SkinForm.EnableBonusSkins = true;
            this.SkinForm.LookAndFeel.SkinName = "DevExpress Dark Style";
            // 
            // Frm_Principal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 372);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Frm_Principal";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Inventarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Principal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnEntrada;
        private DevExpress.XtraBars.BarButtonItem btnSalida;
        private DevExpress.XtraBars.BarButtonItem btnInventarioCiego;
        private DevExpress.XtraBars.BarButtonItem btnRevisionContraloria;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel SkinForm;
        private DevExpress.XtraBars.BarButtonItem btnConfig;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnConfigEmail;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem btnUsuarioPantalla;
    }
}

