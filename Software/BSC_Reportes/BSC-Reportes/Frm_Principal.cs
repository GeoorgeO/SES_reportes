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
            CLS_Usuarios clasePantallas = new CLS_Usuarios();
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
                                if (UsuariosClase == 'N')
                                {

                                }else
                                {
                                    btnUsuarios.Enabled = true;
                                }
                                
                                break;
                            case "2":
                                barButtonItem1.Enabled = true;
                                break;
                            case "3":
                                if (UsuariosClase == 'N')
                                {

                                }
                                else
                                {
                                    btncontrolacesos.Enabled = true;
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
            vusuarios.llenarusuario(UsuariosLogin, UsuariosClase);
            vusuarios.Show();
        }

        private void btncontrolacesos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_UsuariosPantallaBotones vcontrol = new Frm_UsuariosPantallaBotones();
            vcontrol.llenarusuario(UsuariosLogin, UsuariosClase);
            vcontrol.Show();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            if (UsuariosClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                revisaopciones();
            }
            
        }

        public void accesosuperusuario()
        {
            btnUsuarios.Enabled = true;
            btncontrolacesos.Enabled = true;
            barButtonItem1.Enabled = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_ReportePedidos vpedidos = new Frm_ReportePedidos();
            vpedidos.llenarusuario(UsuariosLogin, UsuariosClase);
            vpedidos.Show();
        }
    }
}