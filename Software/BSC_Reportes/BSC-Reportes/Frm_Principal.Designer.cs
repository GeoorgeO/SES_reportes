﻿namespace BSC_Reportes
{
    partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnUsuarios = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrePedidos = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btncontrolacesos = new DevExpress.XtraBars.BarButtonItem();
            this.btnCambiaPass = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmail = new DevExpress.XtraBars.BarButtonItem();
            this.btnPedidos = new DevExpress.XtraBars.BarButtonItem();
            this.btnVentasAcumuladas = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.SkinForm = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnIndiceRotacion = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnUsuarios,
            this.btnPrePedidos,
            this.skinRibbonGalleryBarItem1,
            this.btncontrolacesos,
            this.btnCambiaPass,
            this.btnEmail,
            this.btnPedidos,
            this.btnVentasAcumuladas,
            this.btnIndiceRotacion});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.ribbonPage4,
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(931, 149);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Caption = "Usuarios";
            this.btnUsuarios.Id = 1;
            this.btnUsuarios.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.ImageOptions.Image")));
            this.btnUsuarios.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.ImageOptions.LargeImage")));
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUsuarios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsuarios_ItemClick);
            // 
            // btnPrePedidos
            // 
            this.btnPrePedidos.Caption = "Pre-Pedidos";
            this.btnPrePedidos.Id = 2;
            this.btnPrePedidos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrePedidos.ImageOptions.Image")));
            this.btnPrePedidos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrePedidos.ImageOptions.LargeImage")));
            this.btnPrePedidos.Name = "btnPrePedidos";
            this.btnPrePedidos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPedidos_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            // 
            // 
            // 
            this.skinRibbonGalleryBarItem1.Gallery.ShowItemText = true;
            this.skinRibbonGalleryBarItem1.Id = 3;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // btncontrolacesos
            // 
            this.btncontrolacesos.Caption = "Control de accesos";
            this.btncontrolacesos.Id = 4;
            this.btncontrolacesos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btncontrolacesos.ImageOptions.Image")));
            this.btncontrolacesos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btncontrolacesos.ImageOptions.LargeImage")));
            this.btncontrolacesos.Name = "btncontrolacesos";
            this.btncontrolacesos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btncontrolacesos_ItemClick);
            // 
            // btnCambiaPass
            // 
            this.btnCambiaPass.Caption = "Cambiar contraseña";
            this.btnCambiaPass.Id = 1;
            this.btnCambiaPass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiaPass.ImageOptions.Image")));
            this.btnCambiaPass.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCambiaPass.ImageOptions.LargeImage")));
            this.btnCambiaPass.Name = "btnCambiaPass";
            this.btnCambiaPass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCambiaPass_ItemClick);
            // 
            // btnEmail
            // 
            this.btnEmail.Caption = "EMail";
            this.btnEmail.Id = 2;
            this.btnEmail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.ImageOptions.Image")));
            this.btnEmail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmail.ImageOptions.LargeImage")));
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmail_ItemClick);
            // 
            // btnPedidos
            // 
            this.btnPedidos.Caption = "Pedidos";
            this.btnPedidos.Id = 3;
            this.btnPedidos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPedidos.ImageOptions.Image")));
            this.btnPedidos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPedidos.ImageOptions.LargeImage")));
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPedidos_ItemClick_1);
            // 
            // btnVentasAcumuladas
            // 
            this.btnVentasAcumuladas.Caption = "Ventas Acumuladas";
            this.btnVentasAcumuladas.Id = 4;
            this.btnVentasAcumuladas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVentasAcumuladas.ImageOptions.Image")));
            this.btnVentasAcumuladas.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnVentasAcumuladas.ImageOptions.LargeImage")));
            this.btnVentasAcumuladas.Name = "btnVentasAcumuladas";
            this.btnVentasAcumuladas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVentasAcumuladas_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage2.ImageOptions.Image")));
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Compras";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPrePedidos);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPedidos);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Compras";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage4.ImageOptions.Image")));
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Ventas";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.btnVentasAcumuladas);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnIndiceRotacion);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "Acumuladas";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.ImageOptions.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Config";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUsuarios);
            this.ribbonPageGroup1.ItemLinks.Add(this.btncontrolacesos);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCambiaPass);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmail);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Seguridad";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage3.ImageOptions.Image")));
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
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 506);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(931, 28);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // SkinForm
            // 
            this.SkinForm.EnableBonusSkins = true;
            this.SkinForm.LookAndFeel.SkinName = "Sharp Plus";
            // 
            // btnIndiceRotacion
            // 
            this.btnIndiceRotacion.Caption = "Indice de Rotacion";
            this.btnIndiceRotacion.Id = 5;
            this.btnIndiceRotacion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnIndiceRotacion.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnIndiceRotacion.Name = "btnIndiceRotacion";
            // 
            // Frm_Principal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 534);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Frm_Principal";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Frm_Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Principal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnUsuarios;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel SkinForm;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btncontrolacesos;
        private DevExpress.XtraBars.BarButtonItem btnPrePedidos;
        private DevExpress.XtraBars.BarButtonItem btnCambiaPass;
        private DevExpress.XtraBars.BarButtonItem btnEmail;
        private DevExpress.XtraBars.BarButtonItem btnPedidos;
        private DevExpress.XtraBars.BarButtonItem btnVentasAcumuladas;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnIndiceRotacion;
    }
}