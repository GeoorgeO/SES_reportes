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
    public partial class Frm_Pedidos_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pedidos FrmPedidos;
        public string vPrePedidosId { get;  set; }
        public Frm_Pedidos_Buscar()
        {
            InitializeComponent();
        }

        private void Frm_Pedidos_Buscar_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            dtgValPedidos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValPedidos.OptionsSelection.EnableAppearanceFocusedCell = false;
            lblProveedor.Caption = "Folio:";
            chkFecha.Checked = true;
            chkProveedor.Checked = true;
        }
        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (vPrePedidosId != string.Empty)
            {
                FrmPedidos.BuscarPedido(vPrePedidosId);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Pedido");
            }
        }
        private void dtgPrePedidos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPedidos.GetSelectedRows())
                {
                    DataRow row = this.dtgValPedidos.GetDataRow(i);
                    vPrePedidosId = row["PedidosId"].ToString();
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
                foreach (int i in this.dtgValPedidos.GetSelectedRows())
                {
                    DataRow row = this.dtgValPedidos.GetDataRow(i);
                    vPrePedidosId = row["PedidosId"].ToString();
                    lblProveedor.Caption = string.Format("Folio: {0}", vPrePedidosId);
                    FrmPedidos.BuscarPedido(vPrePedidosId);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btn_ImportarProveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmPedidosBuscar = this;
            frmpro.ShowDialog();
        }
        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgPedidos.DataSource = null;
            CLS_Pedidos selped = new CLS_Pedidos();
            DateTime FInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
            DateTime FFin = Convert.ToDateTime(dtFin.EditValue.ToString());
            if (chkFecha.Checked==true && chkProveedor.Checked==true)
            {
                int result = DateTime.Compare(FInicio, FFin);
                if (result < 1)
                {
                    if (txtProveedorId.Text != string.Empty)
                    {
                        selped.FechaInicio = string.Format("{0}{1}{2} 00:00:00", FInicio.Year, DosCeros(FInicio.Month.ToString()), DosCeros(FInicio.Day.ToString()));
                        selped.FechaFin = string.Format("{0}{1}{2} 23:59:59", FFin.Year, DosCeros(FFin.Month.ToString()), DosCeros(FFin.Day.ToString()));
                        selped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
                        if (rdgTipoPedido.SelectedIndex == 0)
                        {
                            selped.Opcion = 1;
                        }
                        else if (rdgTipoPedido.SelectedIndex == 1)
                        {
                            selped.Opcion = 2;
                        }
                        else if (rdgTipoPedido.SelectedIndex == 2)
                        {
                            selped.Opcion = 4;
                        }
                        else if (rdgTipoPedido.SelectedIndex == 3)
                        {
                            selped.Opcion = 3;
                        }
                        selped.MtdSeleccionarPedidoFechaProveedorLista();
                    }
                    else
                    {
                        XtraMessageBox.Show("Falta Ingrasar un Proveedor");
                    }
                }
                else
                {
                    XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
                }
            }
            else if(chkFecha.Checked == false && chkProveedor.Checked == true)
            {
                if (txtProveedorId.Text != string.Empty)
                {
                    selped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
                    if (rdgTipoPedido.SelectedIndex == 0)
                    {
                        selped.Opcion = 1;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 1)
                    {
                        selped.Opcion = 2;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 2)
                    {
                        selped.Opcion = 4;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 3)
                    {
                        selped.Opcion = 3;
                    }
                    selped.MtdSeleccionarPedidoProveedorLista();
                }
                else
                {
                    XtraMessageBox.Show("Falta Ingrasar un Proveedor");
                }
            }
            else if (chkFecha.Checked == true && chkProveedor.Checked == false)
            {
                int result = DateTime.Compare(FInicio, FFin);
                if (result < 1)
                {
                    selped.FechaInicio = string.Format("{0}{1}{2} 00:00:00", FInicio.Year, DosCeros(FInicio.Month.ToString()), DosCeros(FInicio.Day.ToString()));
                    selped.FechaFin = string.Format("{0}{1}{2} 23:59:59", FFin.Year, DosCeros(FFin.Month.ToString()), DosCeros(FFin.Day.ToString()));
                    if (rdgTipoPedido.SelectedIndex == 0)
                    {
                        selped.Opcion = 1;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 1)
                    {
                        selped.Opcion = 2;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 2)
                    {
                        selped.Opcion = 4;
                    }
                    else if (rdgTipoPedido.SelectedIndex == 3)
                    {
                        selped.Opcion = 3;
                    }
                    selped.MtdSeleccionarPedidoFechaLista();
                }
                else
                {
                    XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
                }
            }
            
            if (selped.Exito)
            {
                if (selped.Datos.Rows.Count > 0)
                {
                    dtgPedidos.DataSource = selped.Datos;
                }
                else
                {
                    XtraMessageBox.Show("No existen registros para mostrar");
                }
            }
        }
        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void txtProveedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BuscarProveedor(txtProveedorId.Text);
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFecha.Checked==true)
            {
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
            }
            else
            {
                dtInicio.Enabled = false;
                dtFin.Enabled = false;
            }
            if(chkFecha.Checked==false && chkProveedor.Checked==false)
            {
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
                txtProveedorId.Enabled = true;
                chkProveedor.Checked = true;
                chkFecha.Checked = true;
            }
        }

        private void chkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProveedor.Checked == true)
            {
                txtProveedorId.Enabled = true;
            }
            else
            {
                txtProveedorId.Enabled = false;
            }
            if (chkFecha.Checked == false && chkProveedor.Checked == false)
            {
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
                txtProveedorId.Enabled = true;
                chkProveedor.Checked = true;
                chkFecha.Checked = true;
            }
        }

        private void Frm_Pedidos_Buscar_Load(object sender, EventArgs e)
        {

        }
    }
}