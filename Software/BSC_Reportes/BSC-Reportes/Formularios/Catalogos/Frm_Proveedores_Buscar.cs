﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace BSC_Reportes
{
    public partial class Frm_Proveedores_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ReportePedidos FrmReportePedidos;
        public Frm_Proveedores_Buscar()
        {
            InitializeComponent();
        }

        public string ProveedorId { get; private set; }
        public string ProveedorNombre { get; private set; }

        private void dtgProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValProveedores.GetSelectedRows())
                {
                    DataRow row = this.dtgValProveedores.GetDataRow(i);
                    ProveedorId = row["ProveedorId"].ToString();
                    ProveedorNombre = row["ProveedorNombre"].ToString();
                    lblProveedor.Caption = ProveedorId + " " + ProveedorNombre;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Proveedores_Buscar_Shown(object sender, EventArgs e)
        {
            dtgValProveedores.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValProveedores.OptionsSelection.EnableAppearanceFocusedCell = false;
            CLS_Proveedores selpro = new CLS_Proveedores();
            selpro.MtdSeleccionarProveedores();
            if (selpro.Exito)
            {
                if(selpro.Datos.Rows.Count>0)
                {
                    dtgProveedores.DataSource = selpro.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(selpro.Mensaje);
            }
            lblProveedor.Caption = "Proveedor:";
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmReportePedidos.BuscarProveedor(ProveedorId);
            this.Close();
        }

        private void dtgProveedores_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValProveedores.GetSelectedRows())
                {
                    DataRow row = this.dtgValProveedores.GetDataRow(i);
                    ProveedorId = row["ProveedorId"].ToString();
                    ProveedorNombre = row["ProveedorNombre"].ToString();
                    lblProveedor.Caption = string.Format("{0} {1}", ProveedorId, ProveedorNombre);
                    FrmReportePedidos.BuscarProveedor(ProveedorId);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}