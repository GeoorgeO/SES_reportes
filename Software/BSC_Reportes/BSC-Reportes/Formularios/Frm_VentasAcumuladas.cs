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
    public partial class Frm_VentasAcumuladas : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        public Frm_VentasAcumuladas()
        {
            InitializeComponent();
        }
        private static Frm_VentasAcumuladas m_FormDefInstance;
        public static Frm_VentasAcumuladas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_VentasAcumuladas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "SucursalesNombre";
            column.AutoIncrement = false;
            column.Caption = "Sucursal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Codigo";
            column.AutoIncrement = false;
            column.Caption = "Codigo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Descripcion";
            column.AutoIncrement = false;
            column.Caption = "Descripcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Familia";
            column.AutoIncrement = false;
            column.Caption = "Familia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TicketArticuloPrecio";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TicketArticuloCantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgVentaExistencia.DataSource = table;
        }
        private void btnImpProveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmVentasAcumuladas = this;
            frmpro.ShowDialog();
        }
        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
        }

        private void Frm_VentasAcumuladas_Load(object sender, EventArgs e)
        {
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
        public void OcultarBotones()
        {
            btnImpProveedor.Links[0].Visible = false;
            btnBuscarFamilia.Links[0].Visible = false;
            btnGenerarReporte.Links[0].Visible = false;
            btnExportarExcel.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
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
                        case "33":
                            btnImpProveedor.Links[0].Visible = true;
                            break;
                        case "34":
                            btnBuscarFamilia.Links[0].Visible = true;
                            break;
                        case "35":
                            btnGenerarReporte.Links[0].Visible = true;
                            break;
                        case "36":
                            btnExportarExcel.Links[0].Visible = true;
                            break;
                        case "37":
                            btnLimpiar.Links[0].Visible = true;
                            break;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(clspantbotones.Mensaje);
            }
        }
        public void accesosuperusuario()
        {
            btnImpProveedor.Links[0].Visible = true;
            btnBuscarFamilia.Links[0].Visible = true;
            btnGenerarReporte.Links[0].Visible = true;
            btnExportarExcel.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
        }

        private void btnBuscarFamilia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_BFamilias frmFam = new Frm_BFamilias();
            frmFam.ShowDialog();
            if (frmFam.IdFamilia != 0)
            {
                txtIdFamilia.Text = frmFam.IdFamilia.ToString();
                BuscarFamilia(Convert.ToInt32(txtIdFamilia.Text));
            }
        }
        private void BuscarFamilia(int IdFamilia)
        {
            CLS_Familias bArt = new CLS_Familias();
            bArt.FamiliaId = Convert.ToInt32(IdFamilia.ToString());
            bArt.MtdSeleccionarFamilia();
            if (bArt.Exito)
            {
                if (bArt.Datos.Rows.Count > 0)
                {
                    txtNombreFamilia.Text = bArt.Datos.Rows[0][1].ToString();
                }
            }
        }
    }
}