using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaDeDatos;

namespace BSC_Inventarios
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        public char UsuariosClase { get;  set; }
        public string UsuariosLogin { get;  set; }

       
        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            MSRegistro RegOut = new MSRegistro();
            SkinForm.LookAndFeel.SetSkinStyle(RegOut.GetSetting("ConexionSQL", "Sking"));
        }
        private bool Permisos(string usuariosLogin, int Pantalla)
        {
            Boolean Valor = false;
            CLS_Usuario_Pantalla sel = new CLS_Usuario_Pantalla();
            sel.UsuariosLogin = usuariosLogin;
            sel.InventarioPantallaId = Pantalla;
            sel.MtdSeleccionarUsuarioPantalla();
            if (sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    Valor = true;
                }
            }
            return Valor;
        }

        private void btnInventarioCiego_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 1))
            {
                Frm_Inventario_Ciego vusuarios = new Frm_Inventario_Ciego();
                Frm_Inventario_Ciego.DefInstance.MdiParent = this;
                Frm_Inventario_Ciego.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Inventario_Ciego.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }

       
        private void btnRevisionContraloria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 2))
            {
                Frm_Revision_Contraloria vusuarios = new Frm_Revision_Contraloria();
                Frm_Revision_Contraloria.DefInstance.MdiParent = this;
                Frm_Revision_Contraloria.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Revision_Contraloria.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }
        private void btnConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 3))
            {
                Frm_Config_Inventario frm = new Frm_Config_Inventario();
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }

        private void btnConfigEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 4))
            {
                Frm_ConfigEmail vusuarios = new Frm_ConfigEmail();
                Frm_ConfigEmail.DefInstance.MdiParent = this;
                Frm_ConfigEmail.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_ConfigEmail.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }
        private void btnEntrada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 5))
            {
                Frm_Entradas vusuarios = new Frm_Entradas();
                Frm_Entradas.DefInstance.MdiParent = this;
                Frm_Entradas.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Entradas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }

        }


        private void btnSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 6))
            {
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }
        private void btnUsuarioPantalla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Permisos(UsuariosLogin, 7))
            {
                Frm_Usuario_Pantalla frmu = new Frm_Usuario_Pantalla();
                frmu.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No tiene permiso para usar este modulo");
            }
        }
    }
}
