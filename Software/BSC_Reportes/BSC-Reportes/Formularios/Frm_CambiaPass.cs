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
            CLS_Usuarios selpro = new CLS_Usuarios();
            selpro.UsuariosLogin = UsuariosLogin;
            selpro.UsuariosOldPass = tpassold.Text;
            selpro.UsuariosPassword = tnewpass.Text;
            selpro.MtdUpdatePassUsuarios();
            if (selpro.Exito)
            {
                if(selpro.Datos.Rows[0][0].ToString() == "-1")
                {
                    XtraMessageBox.Show("La contraeña anterior no es correcta, favor de verificar.");
                }
            }
            else
            {
                XtraMessageBox.Show(selpro.Mensaje);
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tpassold.Text = "";
            tconfirmapass.Text = "";
            tnewpass.Text = "";
        }
    }
}