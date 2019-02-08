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
    public partial class Frm_ConexionesRemotas : DevExpress.XtraEditors.XtraForm
    {
        int vIdSucursal = 0;
        public Frm_ConexionesRemotas()
        {
            InitializeComponent();
        }
        private void CargarSucursales(int? Valor)
        {
            ConexionesRemotas conSucursales = new ConexionesRemotas();
            conSucursales.MtdSeleccionarSucursales();
            if (conSucursales.Exito)
            {
                cboSucursales.Properties.DisplayMember = "SucursalesNombre";
                cboSucursales.Properties.ValueMember = "SucursalesId";
                cboSucursales.EditValue = Valor;
                cboSucursales.Properties.DataSource = conSucursales.Datos;
            }
        }
        private void CargarConexionesRemotas()
        {
            ConexionesRemotas conexion = new ConexionesRemotas();
            Crypto desencriptar = new Crypto();
            conexion.MtdSeleccionarConexionesRemotas();
            if(conexion.Exito)
            {
                if(conexion.Datos.Rows.Count>0)
                {
                    for(int x=0;x<conexion.Datos.Rows.Count;x++)
                    {
                        conexion.Datos.Rows[x][2] = desencriptar.Desencriptar(conexion.Datos.Rows[x][2].ToString());
                        conexion.Datos.Rows[x][3] = desencriptar.Desencriptar(conexion.Datos.Rows[x][3].ToString());
                        conexion.Datos.Rows[x][4] = desencriptar.Desencriptar(conexion.Datos.Rows[x][4].ToString());
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
            CargarConexionesRemotas();
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
            ConexionesRemotas modif = new ConexionesRemotas();
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
                        CargarConexionesRemotas();
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
            ConexionesRemotas consult = new ConexionesRemotas();
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