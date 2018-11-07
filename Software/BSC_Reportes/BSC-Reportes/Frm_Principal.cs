using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace BSC_Reportes
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public char UsuariosClase { get; set; }
        public string UsuariosLogin { get; set; }
        public Frm_Principal()
        {
            InitializeComponent();
        }
        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            MSRegistro RegIn = new MSRegistro();
            RegIn.SaveSetting("ConexionSQL", "Sking", SkinForm.LookAndFeel.SkinName);
        }


        public void revisaopciones()
        {
            CLS_UsuariosPantallas clasePantallas = new CLS_UsuariosPantallas();
            clasePantallas.UsuariosLogin = UsuariosLogin;
            clasePantallas.MtdSeleccionarUsuariosPantallas();
            if (clasePantallas.Exito)
            {
                if (clasePantallas.Datos.Rows.Count > 0)
                {
                    int r;
                    for (r = 0; r < clasePantallas.Datos.Rows.Count; r++)
                    {
                        switch (clasePantallas.Datos.Rows[r]["pantallasId"].ToString())
                        {
                            case "1":

                                break;

                        }
                    }
                }
            }
        }

    }
}