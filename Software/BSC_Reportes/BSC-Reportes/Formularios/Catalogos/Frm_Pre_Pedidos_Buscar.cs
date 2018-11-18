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
    public partial class Frm_Pre_Pedidos_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pre_Pedidos FrmReportePedidos;
        public string vPrePedidosId { get;  set; }
        public Frm_Pre_Pedidos_Buscar()
        {
            InitializeComponent();
        }

        private void Frm_Pre_Pedidos_Buscar_Shown(object sender, EventArgs e)
        {
            dtgValPrePedidos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValPrePedidos.OptionsSelection.EnableAppearanceFocusedCell = false;
            CLS_Pedidos selpro = new CLS_Pedidos();
            selpro.PrePedidoCerrado = 0;
            selpro.PrePedidosCancelado = 0;
            selpro.MtdSeleccionarPrePedidos();
            if (selpro.Exito)
            {
                if (selpro.Datos.Rows.Count > 0)
                {
                    dtgPrePedidos.DataSource = selpro.Datos;
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
            FrmReportePedidos.BuscarPrePedido(vPrePedidosId);
            this.Close();
        }
        private void dtgPrePedidos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPrePedidos.GetSelectedRows())
                {
                    DataRow row = this.dtgValPrePedidos.GetDataRow(i);
                    vPrePedidosId = row["PrePedidosId"].ToString();
                    lblProveedor.Caption = string.Format("Folio: {0}", vPrePedidosId);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void dtgPrePedidos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPrePedidos.GetSelectedRows())
                {
                    DataRow row = this.dtgValPrePedidos.GetDataRow(i);
                    vPrePedidosId = row["PrePedidosId"].ToString();
                    lblProveedor.Caption = string.Format("Folio: {0}", vPrePedidosId);
                    FrmReportePedidos.BuscarPrePedido(vPrePedidosId);
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