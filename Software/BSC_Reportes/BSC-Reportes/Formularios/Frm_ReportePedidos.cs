using System;
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
    public partial class Frm_ReportePedidos : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ReportePedidos()
        {
            InitializeComponent();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkVentas.Checked = true;
            chkExistencia.Checked = true;
            rdbTipo.SelectedIndex = 0;
            dtgVentaExistencia.DataSource = null;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmReportePedidos = this;
            frmpro.ShowDialog();
        }

        private void txtProveedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                BuscarProveedor(txtProveedorId.Text);
            }
        }

        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
        }

        private void Frm_ReportePedidos_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkVentas.Checked = true;
            chkExistencia.Checked = true;
            rdbTipo.SelectedIndex = 0;
            dtgVentaExistencia.DataSource = null;
        }

        private void rdbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdbTipo.SelectedIndex==0)
            {
                DetalladoGrids();
                chkVentas.Enabled = true;
                chkExistencia.Enabled = true;
                chkVentas.Checked = true;
                chkExistencia.Checked = true;
            }
            else
            {
                ConcentradoGrids();
                chkVentas.Enabled = false;
                chkExistencia.Enabled = false;
                chkVentas.Checked = false;
                chkExistencia.Checked = false;
            }
        }

        private void DetalladoGrids()
        {
            ColumnsVentas(true);
            ColumnsExistencia(true);
            ColumnsBands(true);
        }

        private void ConcentradoGrids()
        {
            ColumnsVentas(false);
            ColumnsExistencia(false);
            ColumnsBands(false);
        }

        private void ColumnsBands(Boolean Mostrar)
        {
            gridBand2.Visible = Mostrar;
            gridBand3.Visible = Mostrar;
            gridBand4.Visible = Mostrar;
            gridBand5.Visible = Mostrar;
            gridBand6.Visible = Mostrar;
            gridBand7.Visible = Mostrar;
            gridBand8.Visible = Mostrar;
            gridBand9.Visible = Mostrar;
            gridBand10.Visible = Mostrar;
            gridBand11.Visible = Mostrar;
            gridBand12.Visible = Mostrar;
            gridBand13.Visible = Mostrar;
        }

        private void ColumnsExistencia(Boolean Mostrar)
        {
            gridColumn4.Visible = Mostrar;
            gridColumn6.Visible = Mostrar;
            gridColumn8.Visible = Mostrar;
            gridColumn10.Visible = Mostrar;
            gridColumn12.Visible = Mostrar;
            gridColumn14.Visible = Mostrar;
            gridColumn16.Visible = Mostrar;
            gridColumn18.Visible = Mostrar;
            gridColumn20.Visible = Mostrar;
            gridColumn22.Visible = Mostrar;
            gridColumn24.Visible = Mostrar;
            gridColumn26.Visible = Mostrar;
        }

        private void ColumnsVentas(Boolean Mostrar)
        {
            gridColumn3.Visible = Mostrar;
            gridColumn5.Visible = Mostrar;
            gridColumn7.Visible = Mostrar;
            gridColumn9.Visible = Mostrar;
            gridColumn11.Visible = Mostrar;
            gridColumn13.Visible = Mostrar;
            gridColumn15.Visible = Mostrar;
            gridColumn17.Visible = Mostrar;
            gridColumn19.Visible = Mostrar;
            gridColumn21.Visible = Mostrar;
            gridColumn23.Visible = Mostrar;
            gridColumn25.Visible = Mostrar;
        }

        private void chkVentas_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVentas.Checked==true)
            {
                ColumnsBands(true);
                ColumnsVentas(true);
            }
            else if(chkVentas.Checked == false)
            {
                ColumnsVentas(false);
            }
            if(chkVentas.Checked == false && chkExistencia.Checked == false)
            {
                ColumnsBands(false);
            }
        }

        private void chkExistencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExistencia.Checked == true)
            {
                ColumnsBands(true);
                ColumnsExistencia(true);
            }
            else if (chkExistencia.Checked == false)
            {
                ColumnsExistencia(false);
            }
            if (chkVentas.Checked == false && chkExistencia.Checked == false)
            {
                ColumnsBands(false);
            }
        }
    }
}