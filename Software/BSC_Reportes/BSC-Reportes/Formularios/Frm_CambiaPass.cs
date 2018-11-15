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
    public partial class Frm_CambiaPass : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CambiaPass()
        {
            InitializeComponent();
        }

        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }

        private void guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(tconfirmapass.Text== tnewpass.Text)
            {
                Crypto clsencripta = new Crypto();
                CLS_Usuarios selpro = new CLS_Usuarios();
                selpro.UsuariosLogin = UsuariosLogin;
                selpro.UsuariosOldPass = clsencripta.Encriptar(tpassold.Text);
                selpro.UsuariosPassword = clsencripta.Encriptar(tnewpass.Text);
                selpro.MtdUpdatePassUsuarios();
                if (selpro.Exito)
                {
                    if (selpro.Datos.Rows[0][0].ToString() == "-1")
                    {
                        XtraMessageBox.Show("La contraseña anterior no es correcta, favor de verificar.");
                    }
                    if (selpro.Datos.Rows[0][0].ToString() == "0")
                    {
                        XtraMessageBox.Show("Contraseña cambiada correctamente.");
                        limpiarform();
                    }
                }
                else
                {
                    XtraMessageBox.Show(selpro.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("La nueva contraseña ingresada no coincide, favor de verificar.");
            }

            
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            limpiarform();
        }
        public void limpiarform()
        {
            tpassold.Text = "";
            tconfirmapass.Text = "";
            tnewpass.Text = "";
        }
    }
}