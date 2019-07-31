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
    public partial class Frm_Pre_Pedidos_Status : DevExpress.XtraEditors.XtraForm
    {
        public string vPrePedidosId { get; private set; }
        public int IdPantallaBotones { get; set; }
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        private static Frm_Pre_Pedidos_Status m_FormDefInstance;
        public static Frm_Pre_Pedidos_Status DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pre_Pedidos_Status();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Frm_Pre_Pedidos_Status()
        {
            InitializeComponent();
        }
        private void MakeFirstTable()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();
            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column0";
            column.AutoIncrement = false;
            column.Caption = "PrePedidosId";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column1";
            column.AutoIncrement = false;
            column.Caption = "ProveedorNombre";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column2";
            column.AutoIncrement = false;
            column.Caption = "Estado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "Column3";
            column.AutoIncrement = false;
            column.Caption = "Seleccionar";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column4";
            column.AutoIncrement = false;
            column.Caption = "FechaInsert";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgPrePedidos.DataSource = table;

        }
        private void Frm_Pre_Pedidos_Status_Shown(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarProveedores(null);
            OcultarBotones();
            if (UsuarioClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                MostrarBotones();
            }
        }
        public void accesosuperusuario()
        {
            btnBuscar.Links[0].Visible = true;
            btnGuardar.Links[0].Visible = true;
        }
        public void OcultarBotones()
        {
            btnBuscar.Links[0].Visible = false;
            btnGuardar.Links[0].Visible = false;
        }
        public void MostrarBotones()
        {
            CLS_Pantallas clspantbotones = new CLS_Pantallas();
            clspantbotones.UsuariosLogin = UsuariosLogin;
            clspantbotones.pantallasid = IdPantallaBotones;
            clspantbotones.Mtdselecionarbotonespantalla();
            if (clspantbotones.Exito)
            {
                for (int t = 0; t < clspantbotones.Datos.Rows.Count; t++)
                {
                    switch (clspantbotones.Datos.Rows[t][0].ToString())
                    {
                        case "49":
                            btnBuscar.Links[0].Visible = true;
                            break;
                        case "50":
                            btnGuardar.Links[0].Visible = true;
                            break;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(clspantbotones.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            chkTodos.Checked = true;
            cmbProveedores.Enabled = false;
            dtgPrePedidos.DataSource = null;
            MakeFirstTable();
        }

        private void CargarProveedores(int? Valor)
        {
            CLS_Pedidos ConProv= new CLS_Pedidos();
            ConProv.MtdSeleccionarPrePedidosProveedores();
            if (ConProv.Exito)
            {
                cmbProveedores.Properties.DisplayMember = "ProveedorNombre";
                cmbProveedores.Properties.ValueMember = "Proveedorid";
                cmbProveedores.EditValue = Valor;
                cmbProveedores.Properties.DataSource = ConProv.Datos;
            }
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex==0)
            {
                LimpiarCampos();
                gridColumn3.Caption = "Cerrado";
            }
            else if(radioGroup1.SelectedIndex==1)
            {
                LimpiarCampos();
                gridColumn3.Caption = "Cancelado";
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                LimpiarCampos();
                gridColumn3.Caption = "Solo Lectura";
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTodos.Checked==true)
            {
                cmbProveedores.Enabled = false;
            }
            else
            {
                cmbProveedores.Enabled = true;
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                CLS_Pedidos sel = new CLS_Pedidos();
                sel.ProveedorId = 0;
                if (radioGroup1.SelectedIndex == 0)
                {
                    sel.Opcion = 1;
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    sel.Opcion = 2;
                }
                else
                {
                    sel.Opcion = 3;
                }
                sel.MtdSeleccionarPrePedidoListaEstatus();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0)
                    {
                        dtgPrePedidos.DataSource = sel.Datos;
                    }
                    else
                    {
                        XtraMessageBox.Show("No existen registros para mostrar");
                    }
                }
                else
                {
                    XtraMessageBox.Show(sel.Mensaje);
                }
            }
            else
            {
                if (cmbProveedores.EditValue != null)
                {
                    CLS_Pedidos sel = new CLS_Pedidos();
                    sel.ProveedorId = Convert.ToInt32(cmbProveedores.EditValue);
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        sel.Opcion = 1;
                    }
                    else if (radioGroup1.SelectedIndex == 1)
                    {
                        sel.Opcion = 2;
                    }
                    else
                    {
                        sel.Opcion = 3;
                    }
                    sel.MtdSeleccionarPrePedidoListaEstatus();
                    if (sel.Exito)
                    {
                        if (sel.Datos.Rows.Count > 0)
                        {
                            dtgPrePedidos.DataSource = sel.Datos;
                        }
                        else
                        {
                            XtraMessageBox.Show("No existen registros para mostrar");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(sel.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se ha seleccionado Proveedor");
                }
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int xRow = 0;
            dtgPrePedidos.FocusedView.CloseEditor();
            for (int i = 0; i < dtgValPrePedidos.RowCount; i++)
            {
                xRow = dtgValPrePedidos.GetVisibleRowHandle(i);
                if (Convert.ToBoolean(dtgValPrePedidos.GetRowCellValue(xRow, "Seleccionar")))
                {
                    CLS_Pedidos udp = new CLS_Pedidos();
                    udp.PrePedidosId=Convert.ToInt32(dtgValPrePedidos.GetRowCellValue(xRow, "PrePedidosId").ToString());
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        udp.Opcion = 1;
                    }
                    else if (radioGroup1.SelectedIndex == 1)
                    {
                        udp.Opcion = 2;
                    }
                    else
                    {
                        udp.Opcion = 3;
                    }
                    udp.MtdActualizarPrePedidoEstatus();
                    if(!udp.Exito)
                    {
                        XtraMessageBox.Show(udp.Mensaje);
                    }
                }
            }
            btnBuscar.PerformClick();
        }

        private void Frm_Pre_Pedidos_Status_Load(object sender, EventArgs e)
        {

        }
    }
}