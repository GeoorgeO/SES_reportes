using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;
using DevExpress.XtraEditors;

namespace BSC_Sincronizacion
{
    public partial class Frm_Conexiones : DevExpress.XtraEditors.XtraForm
    {
      
        private static Frm_Conexiones m_FormDefInstance;
        public static Frm_Conexiones DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Conexiones();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        
        public Frm_Conexiones()
        {
            InitializeComponent();
        }
        private void CargarIconos()
        {
            btnGuardarConexion.LargeGlyph = imageCollection1.Images[0];
            btnProbarConexion.LargeGlyph = imageCollection1.Images[1];
        }
        
        public string LeerConexion()
        {
            try
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;

                ValServer = txtServer.Text;
                ValDBase = txtDB.Text;
                ValUser = txtLogin.Text;
                ValPass = txtPassword.Text;


                StrConexion = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ValServer, ValDBase, ValUser, ValPass);
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Frm_Conexiones_Load(object sender, EventArgs e)
        {
            CargarIconos();
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();
            string valServer, valDB, valLogin, valPass;
            string valServerC, valDBC, valLoginC, valPassC;
            string valServerR, valDBR, valLoginR, valPassR;

            try
            {
                valServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerL"));
                valDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseL"));
                valLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserL"));
                valPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordL"));
            }
            catch
            {
                valServer = string.Empty;
                valDB = string.Empty;
                valLogin = string.Empty;
                valPass = string.Empty;
            }

            try
            {
                valServerC = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerC"));
                valDBC = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseC"));
                valLoginC = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserC"));
                valPassC = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordC"));
            }
            catch
            {
                valServerC = string.Empty;
                valDBC = string.Empty;
                valLoginC = string.Empty;
                valPassC = string.Empty;
            }
            try
            {
                valServerR = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerR"));
                valDBR = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseR"));
                valLoginR = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserR"));
                valPassR = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordR"));
            }
            catch
            {
                valServerR = string.Empty;
                valDBR = string.Empty;
                valLoginR = string.Empty;
                valPassR = string.Empty;
            }

            if (valServer != null && valDB != null && valLogin != null & valPass != null)
            {
                txtServer.Text = valServer;
                txtDB.Text = valDB;
                txtLogin.Text = valLogin;
                txtPassword.Text = valPass;
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServer.Text, txtDB.Text, txtLogin.Text, txtPassword.Text)))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        XtraMessageBox.Show("No se Han Configurado datos Correctos para la conexion a la base de datos Local");
                    }
                }
            }
            else
            {
                txtServer.Text = string.Empty;
                txtDB.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }

            if (valServerC != null && valDBC != null && valLoginC != null & valPassC != null)
            {
                txtServerC.Text = valServerC;
                txtDBC.Text = valDBC;
                txtLoginC.Text = valLoginC;
                txtPasswordC.Text = valPassC;
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerC.Text, txtDBC.Text, txtLoginC.Text, txtPasswordC.Text)))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        XtraMessageBox.Show("No se Han Configurado datos Correctos para la conexion a la base de datos Central");
                    }
                }
            }
            else
            {
                txtServerC.Text = string.Empty;
                txtDBC.Text = string.Empty;
                txtLoginC.Text = string.Empty;
                txtPasswordC.Text = string.Empty;
            }

            if (valServerR != null && valDBR != null && valLoginR != null & valPassR != null)
            {
                txtServerR.Text = valServerR;
                txtDBR.Text = valDBR;
                txtLoginR.Text = valLoginR;
                txtPasswordR.Text = valPassR;
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerR.Text, txtDBR.Text, txtLoginR.Text, txtPasswordR.Text)))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        XtraMessageBox.Show("No se Han Configurado datos Correctos para la conexion a la base de datos Reportes");
                    }
                }
            }
            else
            {
                txtServerR.Text = string.Empty;
                txtDBR.Text = string.Empty;
                txtLoginR.Text = string.Empty;
                txtPasswordR.Text = string.Empty;
            }
        }
        private void btnGuardarConexion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtServer.Text != "" && txtDB.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
            {
                {
                    SqlConnection conn = new SqlConnection("Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDB.Text + ";Persist Security Info=True;User ID=" + txtLogin.Text + ";Password=" + txtPassword.Text);
                    try
                    {
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        conn.Open();
                        RegIn.SaveSetting("ConexionSQL", "Server", EncriptarTexto.Encriptar(txtServer.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBase", EncriptarTexto.Encriptar(txtDB.Text));
                        RegIn.SaveSetting("ConexionSQL", "User", EncriptarTexto.Encriptar(txtLogin.Text));
                        RegIn.SaveSetting("ConexionSQL", "Password", EncriptarTexto.Encriptar(txtPassword.Text));
                        XtraMessageBox.Show("Se Grabaron los Datos Del Servidor Principal Con Exito");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error Descripcion: " + ex);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan Datos para la Conexion Principal");
            }
        }
        private void btnProbarConexion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtServer.Text != "" && txtDB.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServer.Text, txtDB.Text, txtLogin.Text, txtPassword.Text)))
                {
                    try
                    {
                        conn.Open();
                        XtraMessageBox.Show("Conexion Exitosa DB Principal");
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        RegIn.SaveSetting("ConexionSQL", "Server", EncriptarTexto.Encriptar(txtServer.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBase", EncriptarTexto.Encriptar(txtDB.Text));
                        RegIn.SaveSetting("ConexionSQL", "User", EncriptarTexto.Encriptar(txtLogin.Text));
                        RegIn.SaveSetting("ConexionSQL", "Password", EncriptarTexto.Encriptar(txtPassword.Text));
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("No se pudo Conectar con la Base de Datos Principal: " + ex);
                    }
                }

            }
        }
        private void txtDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDB.Text == string.Empty && e.KeyValue == 13)
            {
                if (txtServer.Text != string.Empty && txtLogin.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    Frm_DataBaseSQL frm = new Frm_DataBaseSQL();
                    frm.Instancia = txtServer.Text;
                    frm.User = txtLogin.Text;
                    frm.Pass = txtPassword.Text;
                    frm.ShowDialog();
                    txtDB.Text = frm.CadenaBaseDatos;
                }
                else
                {
                    XtraMessageBox.Show("Faltan por definir Datos");
                }
            }
        }
        private void txtServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtServer.Text == string.Empty && e.KeyValue == 13)
            {
                Frm_InstanciaSQL frm = new Frm_InstanciaSQL();
                frm.ShowDialog();
                txtServer.Text = frm.CadenaServer;
            }
        }

        private void btnGuardarConexionL_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "" && txtDB.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
            {
                {
                    SqlConnection conn = new SqlConnection("Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDB.Text + ";Persist Security Info=True;User ID=" + txtLogin.Text + ";Password=" + txtPassword.Text);
                    try
                    {
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        conn.Open();
                        RegIn.SaveSetting("ConexionSQL", "ServerL", EncriptarTexto.Encriptar(txtServer.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseL", EncriptarTexto.Encriptar(txtDB.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserL", EncriptarTexto.Encriptar(txtLogin.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordL", EncriptarTexto.Encriptar(txtPassword.Text));
                        XtraMessageBox.Show("Se Grabaron los Datos Del Servidor Local Con Exito");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error Descripcion: " + ex);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan Datos para la Conexion Local");
            }
        }
        private void btnProbarConexionL_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "" && txtDB.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServer.Text, txtDB.Text, txtLogin.Text, txtPassword.Text)))
                {
                    try
                    {
                        conn.Open();
                        XtraMessageBox.Show("Conexion Exitosa DB Local");
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        RegIn.SaveSetting("ConexionSQL", "ServerL", EncriptarTexto.Encriptar(txtServer.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseL", EncriptarTexto.Encriptar(txtDB.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserL", EncriptarTexto.Encriptar(txtLogin.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordL", EncriptarTexto.Encriptar(txtPassword.Text));
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("No se pudo Conectar con la Base de Datos Local: " + ex);
                    }
                }
            }
        }

        private void btnGuardarConexionC_Click(object sender, EventArgs e)
        {
            if (txtServerC.Text != "" && txtDBC.Text != "" && txtLoginC.Text != "" && txtPasswordC.Text != "")
            {
                {
                    SqlConnection conn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerC.Text, txtDBC.Text, txtLoginC.Text, txtPasswordC.Text));
                    try
                    {
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        conn.Open();
                        RegIn.SaveSetting("ConexionSQL", "ServerC", EncriptarTexto.Encriptar(txtServerC.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseC", EncriptarTexto.Encriptar(txtDBC.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserC", EncriptarTexto.Encriptar(txtLoginC.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordC", EncriptarTexto.Encriptar(txtPasswordC.Text));
                        XtraMessageBox.Show("Se Grabaron los Datos Del Servidor Central Con Exito");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error Descripcion: " + ex);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan Datos para la Conexion Central");
            }
        }
        private void btnProbarConexionC_Click(object sender, EventArgs e)
        {
            if (txtServerC.Text != "" && txtDBC.Text != "" && txtLoginC.Text != "" && txtPasswordC.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerC.Text, txtDBC.Text, txtLoginC.Text, txtPasswordC.Text)))
                {
                    try
                    {
                        conn.Open();
                        XtraMessageBox.Show("Conexion Exitosa DB Central");
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        RegIn.SaveSetting("ConexionSQL", "ServerC", EncriptarTexto.Encriptar(txtServerC.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseC", EncriptarTexto.Encriptar(txtDBC.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserC", EncriptarTexto.Encriptar(txtLoginC.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordC", EncriptarTexto.Encriptar(txtPasswordC.Text));
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("No se pudo Conectar con la Base de Datos Central: " + ex);
                    }
                }
            }
        }

        private void btnGuardarConexionR_Click(object sender, EventArgs e)
        {
            if (txtServerR.Text != "" && txtDBR.Text != "" && txtLoginR.Text != "" && txtPasswordR.Text != "")
            {
                {
                    SqlConnection conn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerR.Text, txtDBR.Text, txtLoginR.Text, txtPasswordR.Text));
                    try
                    {
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        conn.Open();
                        RegIn.SaveSetting("ConexionSQL", "ServerR", EncriptarTexto.Encriptar(txtServerR.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseR", EncriptarTexto.Encriptar(txtDBR.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserR", EncriptarTexto.Encriptar(txtLoginR.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordR", EncriptarTexto.Encriptar(txtPasswordR.Text));
                        XtraMessageBox.Show("Se Grabaron los Datos Del Servidor Central Con Exito");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error Descripcion: " + ex);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan Datos para la Conexion Central");
            }
        }
        private void btnProbarConexionR_Click(object sender, EventArgs e)
        {
            if (txtServerR.Text != "" && txtDBR.Text != "" && txtLoginR.Text != "" && txtPasswordR.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtServerR.Text, txtDBR.Text, txtLoginR.Text, txtPasswordR.Text)))
                {
                    try
                    {
                        conn.Open();
                        XtraMessageBox.Show("Conexion Exitosa DB Central");
                        MSRegistro RegIn = new MSRegistro();
                        Crypto EncriptarTexto = new Crypto();
                        RegIn.SaveSetting("ConexionSQL", "ServerC", EncriptarTexto.Encriptar(txtServerR.Text));
                        RegIn.SaveSetting("ConexionSQL", "DBaseC", EncriptarTexto.Encriptar(txtDBR.Text));
                        RegIn.SaveSetting("ConexionSQL", "UserC", EncriptarTexto.Encriptar(txtLoginR.Text));
                        RegIn.SaveSetting("ConexionSQL", "PasswordC", EncriptarTexto.Encriptar(txtPasswordR.Text));
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("No se pudo Conectar con la Base de Datos Central: " + ex);
                    }
                }
            }
        }
    }
}