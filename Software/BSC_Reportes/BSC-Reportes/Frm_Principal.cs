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
        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void revisaopciones()
        {
            CLS_Usuarios clasePantallas = new CLS_Usuarios();
            clasePantallas.UsuariosLogin = UsuariosLogin;
            clasePantallas.MtdSeleccionarUsuariosPantallas();

            if(UsuariosClase == 'N')
            {
                btnCambiaPass.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnCambiaPass.Visibility = BarItemVisibility.Never;
            }

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
                                if (UsuariosClase == 'N')
                                {

                                }
                                else
                                {
                                    btnUsuarios.Visibility = BarItemVisibility.Always;
                                }

                                break;
                            case "2":
                                if (UsuariosClase == 'N')
                                {

                                }
                                else
                                {
                                    btnPrePedidos.Visibility = BarItemVisibility.Always;
                                }
                                break;
                            case "3":
                                if (UsuariosClase == 'N')
                                {

                                }
                                else
                                {
                                    btncontrolacesos.Visibility = BarItemVisibility.Always;
                                }
                                break;
                            case "4":
                                if (UsuariosClase == 'N')
                                {

                                }
                                else
                                {
                                    btnEmail.Visibility = BarItemVisibility.Always;
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void btnUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Usuarios vusuarios = new Frm_Usuarios();
            Frm_Usuarios.DefInstance.MdiParent = this;
            Frm_Usuarios.DefInstance.IdPantallaBotones = 1;
            Frm_Usuarios.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_Usuarios.DefInstance.UsuarioClase = UsuariosClase;
            Frm_Usuarios.DefInstance.Show();
        }

        private void btncontrolacesos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_UsuariosPantallaBotones vcontrol = new Frm_UsuariosPantallaBotones();

            Frm_UsuariosPantallaBotones.DefInstance.MdiParent = this;
            Frm_UsuariosPantallaBotones.DefInstance.IdPantallaBotones = 3;
            Frm_UsuariosPantallaBotones.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_UsuariosPantallaBotones.DefInstance.UsuarioClase = UsuariosClase;
            Frm_UsuariosPantallaBotones.DefInstance.Show();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            if (UsuariosClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                revisaopciones();
            }

            
        }
        private void OcultarBotones()
        {
            btnUsuarios.Visibility = BarItemVisibility.Never;
            btncontrolacesos.Visibility = BarItemVisibility.Never;
            btnPrePedidos.Visibility = BarItemVisibility.Never;
        }
        public void accesosuperusuario()
        {
            btnUsuarios.Visibility = BarItemVisibility.Always;
            btncontrolacesos.Visibility = BarItemVisibility.Always;
            btnPrePedidos.Visibility = BarItemVisibility.Always;
        }

        private void btnPedidos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Pre_Pedidos.DefInstance.MdiParent = this;
            Frm_Pre_Pedidos.DefInstance.IdPantallaBotones = 2;
            Frm_Pre_Pedidos.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_Pre_Pedidos.DefInstance.UsuarioClase = UsuariosClase;
            Frm_Pre_Pedidos.DefInstance.Show();
        }

        private void btnCambiaPass_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_CambiaPass frmusu = new Frm_CambiaPass();
            //frmusu.FrmUsuariosPantallaBotones = this;
            frmusu.IdPantallaBotones = 4;
            frmusu.UsuariosLogin = UsuariosLogin;
            frmusu.UsuarioClase = UsuariosClase;
            //frmusu.llenarusuario(GusuariosLogin, GusuariosClase);
            frmusu.ShowDialog();
        }

        private void btnEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_ConfigEmail.DefInstance.MdiParent = this;
            Frm_ConfigEmail.DefInstance.IdPantallaBotones = 4;
            Frm_ConfigEmail.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_ConfigEmail.DefInstance.UsuarioClase = UsuariosClase;
            Frm_ConfigEmail.DefInstance.Show();
        }

        private void btnPedidos_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Frm_Pedidos.DefInstance.MdiParent = this;
            Frm_Pedidos.DefInstance.IdPantallaBotones = 5;
            Frm_Pedidos.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_Pedidos.DefInstance.UsuarioClase = UsuariosClase;
            Frm_Pedidos.DefInstance.Show();
        }
    }
}