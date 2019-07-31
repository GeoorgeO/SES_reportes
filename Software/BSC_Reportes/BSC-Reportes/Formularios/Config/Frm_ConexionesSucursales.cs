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
using System.Data.SqlClient;

namespace BSC_Reportes
{
    public partial class Frm_ConexionesSucursales : DevExpress.XtraEditors.XtraForm
    {
        int vIdSucursal = 0;
        public Frm_ConexionesSucursales()
        {
            InitializeComponent();
        }
        private static Frm_ConexionesSucursales m_FormDefInstance;
        public static Frm_ConexionesSucursales DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_ConexionesSucursales();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public int IdPantallaBotones { get;  set; }
        public string UsuariosLogin { get;  set; }
        public char UsuarioClase { get;  set; }

        private void CargarSucursales(int? Valor)
        {
            ConexionesSucursales conSucursales = new ConexionesSucursales();
            conSucursales.MtdSeleccionarSucursales();
            if (conSucursales.Exito)
            {
                cboSucursales.Properties.DisplayMember = "SucursalesNombre";
                cboSucursales.Properties.ValueMember = "SucursalesId";
                cboSucursales.EditValue = Valor;
                cboSucursales.Properties.DataSource = conSucursales.Datos;
            }
        }
        private void CargarConexionesSucursales()
        {
            ConexionesSucursales conexion = new ConexionesSucursales();
            Crypto desencriptar = new Crypto();
            conexion.MtdSeleccionarConexionesSucursales();
            if(conexion.Exito)
            {
                if(conexion.Datos.Rows.Count>0)
                {
                    for(int x=0;x<conexion.Datos.Rows.Count;x++)
                    {
                        if (conexion.Datos.Rows[x][2].ToString() != string.Empty)
                        {
                            conexion.Datos.Rows[x][2] = desencriptar.Desencriptar(conexion.Datos.Rows[x][2].ToString());
                        }
                        else
                        {
                            conexion.Datos.Rows[x][2] = string.Empty;
                        }
                        if (conexion.Datos.Rows[x][3].ToString() != string.Empty)
                        {
                            conexion.Datos.Rows[x][3] = desencriptar.Desencriptar(conexion.Datos.Rows[x][3].ToString());
                        }
                        else
                        {
                            conexion.Datos.Rows[x][3] = string.Empty;
                        }
                        if (conexion.Datos.Rows[x][4].ToString() != string.Empty)
                        {
                            conexion.Datos.Rows[x][4] = desencriptar.Desencriptar(conexion.Datos.Rows[x][4].ToString());
                        }
                        else
                        {
                            conexion.Datos.Rows[x][4] = string.Empty;
                        }
                    }
                    dtgConexiones.DataSource = conexion.Datos;
                }
            }
        }
        private void Frm_VerificadorPrecios_Load(object sender, EventArgs e)
        {
            dtgValConexiones.OptionsBehavior.Editable = false;
            dtgValConexiones.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValConexiones.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            CargarSucursales(null);
            CargarConexionesSucursales();
        }

        private void dtgConexiones_Click(object sender, EventArgs e)
        {
            if (dtgValConexiones.RowCount > 0)
            {
                foreach (int i in dtgValConexiones.GetSelectedRows())
                {
                    Crypto DesEncryp = new Crypto();
                    DataRow row = dtgValConexiones.GetDataRow(i);
                    vIdSucursal = Convert.ToInt32(row["IdSucursal"].ToString());
                    txtServer.Text = row["Servidor"].ToString();
                    txtLogin.Text = row["Usuario"].ToString();
                    txtDB.Text = row["BasedeDatos"].ToString();
                    CargarSucursales(vIdSucursal);
                    
                    if (row[5].ToString() != string.Empty)
                    {
                        txtPassword.Text = DesEncryp.Desencriptar(row[5].ToString());
                    }
                    else
                    {
                        txtPassword.Text = string.Empty;
                    }
                }

            }
        }

        private void btnGuardarConexion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConexionesSucursales modif = new ConexionesSucursales();
            Crypto encryp = new Crypto();
            modif.SucursalesId = Convert.ToInt32(cboSucursales.EditValue);
            modif.ServerID = encryp.Encriptar(txtServer.Text);
            modif.UserID = encryp.Encriptar(txtLogin.Text);
            modif.PassID = encryp.Encriptar(txtPassword.Text);
            modif.DataBaseID = encryp.Encriptar(txtDB.Text);
            using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServer.Text, txtDB.Text, txtLogin.Text, txtPassword.Text)))
            {
                try
                {
                    conn.Open();
                    modif.MtdModificarConexion();
                    if (modif.Exito)
                    {
                        CargarConexionesSucursales();
                        XtraMessageBox.Show("Se ha guardado la configuración con Exito");
                    }
                }
                catch
                {
                    XtraMessageBox.Show("No se ha Establecido Conexion con el Servidor");
                }
            }
        }

        private void btnProbarConexion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServer.Text, txtDB.Text, txtLogin.Text, txtPassword.Text)))
            {
                try
                {
                    conn.Open();
                    XtraMessageBox.Show("Conexion Exitosa");
                }
                catch
                {
                    XtraMessageBox.Show("No se ha Establecido Conexion con el Servidor");
                }
            }
        }

        private void cboSucursales_EditValueChanged(object sender, EventArgs e)
        {
            ConexionesSucursales consult = new ConexionesSucursales();
            consult.SucursalesId = Convert.ToInt32(cboSucursales.EditValue);
            consult.MtdSeleccionarSucursalesId();
            if(consult.Exito)
            {
                if(consult.Datos.Rows.Count>0)
                {
                    Crypto encryp = new Crypto();
                    txtServer.Text = encryp.Desencriptar(consult.Datos.Rows[0][2].ToString());
                    txtDB.Text = encryp.Desencriptar(consult.Datos.Rows[0][3].ToString());
                    txtLogin.Text = encryp.Desencriptar(consult.Datos.Rows[0][4].ToString());
                    txtPassword.Text = encryp.Desencriptar(consult.Datos.Rows[0][5].ToString());
                }
            }
        }
    }
}