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
    public partial class Frm_Pedidos : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        private static Frm_Pedidos m_FormDefInstance;
        public static Frm_Pedidos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pedidos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Pedidos()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Reg";
            column.AutoIncrement = false;
            column.Caption = "#";
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
            column.DataType = typeof(decimal);
            column.ColumnName = "CostoReposicion";
            column.AutoIncrement = false;
            column.Caption = "Costo Reposicion";
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
            column.ColumnName = "AlmacenD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CentroD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "MorelosD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "FcoVillaD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaID";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaIID";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PaseoD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "EstocolmoD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CostaRicaD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CalzadaD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "LombardiaD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "NvaItaliaD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ApatzinganD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ReyesD";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Entrada";
            column.AutoIncrement = false;
            column.Caption = "Entrada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TPedido";
            column.AutoIncrement = false;
            column.Caption = "Total Pedido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgVentaExistencia.DataSource = table;
        }
        public void OcultarBotones()
        {
            btnFolios.Links[0].Visible = false;
            btnGuardar.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
            btnActualizarPedido.Links[0].Visible = false;
            btnCancelar.Links[0].Visible = false;
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
                        case "19":
                            btnFolios.Links[0].Visible = true;
                            break;
                        case "22":
                            btnCancelar.Links[0].Visible = true;
                            break;
                        case "20":
                            btnGuardar.Links[0].Visible = true;
                            break;
                        case "21":
                            btnLimpiar.Links[0].Visible = true;
                            break;
                        case "23":
                            btnActualizarPedido.Links[0].Visible = true;
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
            btnFolios.Links[0].Visible = true;
            btnGuardar.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
            btnActualizarPedido.Links[0].Visible = true;
            btnCancelar.Links[0].Visible = true;
        }
        private void Frm_Pedidos_Load(object sender, EventArgs e)
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
        private void chkCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCosto.Checked == true)
            {
                ColumnsCosto(true);
            }
            else
            {
                ColumnsCosto(false);
            }
        }
        private void chkFamilia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFamilia.Checked == true)
            {
                ColumnsFamilia(true);
            }
            else
            {
                ColumnsFamilia(false);
            }
        }
        private void ColumnsCosto(Boolean Mostrar)
        {
            CostoReposicion.Visible = Mostrar;
        }
        private void ColumnsFamilia(Boolean Mostrar)
        {
            Familia.Visible = Mostrar;
        }

        private void Frm_Pedidos_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkCosto.Checked = true;
            chkFamilia.Checked = true;
            dtgVentaExistencia.DataSource = null;
            MakeTablaPedidos();
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValVentaExistencia.OptionsSelection.MultiSelect = true;
            dtgValVentaExistencia.OptionsView.ShowGroupPanel = false;
            CostoReposicion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            CostoReposicion.DisplayFormat.FormatString = "$ ###,###0.00";
            pbProgreso.Position = 0;
            DesbloquearObjetos(true);
        }
        private void DesbloquearObjetos(Boolean Valor)
        {
            txtFolio.Enabled = Valor;
        }
    }
}