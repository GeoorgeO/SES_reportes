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
    public partial class Frm_Parametros_Pedidos : DevExpress.XtraEditors.XtraForm
    {
        public int IdPantallaBotones { get; set; }
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        private static Frm_Parametros_Pedidos m_FormDefInstance;
        public static Frm_Parametros_Pedidos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Parametros_Pedidos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Parametros_Pedidos()
        {
            InitializeComponent();
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            XtraFolderBrowserDialog saveFileDialog = new XtraFolderBrowserDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = saveFileDialog.SelectedPath;
            }
        }

        private void Frm_Parametros_Pedidos_Shown(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarParametros();
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

        private void CargarParametros()
        {
            CLS_Pedidos ins = new CLS_Pedidos();
            ins.MtdSeleccionarParametrosPedidos();
            if (ins.Exito)
            {
                if(ins.Datos.Rows.Count>0)
                {
                    txtRuta.Text = ins.Datos.Rows[0]["PedidosConfigRuta"].ToString();
                }
            }

        }

        public void accesosuperusuario()
        {
            btnGuardar.Links[0].Visible = true;
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
                        case "51":
                            btnGuardar.Links[0].Visible = true;
                            break;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(clspantbotones.Mensaje);
            }
        }
        public void OcultarBotones()
        {
            btnGuardar.Links[0].Visible = false;
        }
        private void LimpiarCampos()
        {
            txtRuta.Text = string.Empty;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtRuta.Text!=string.Empty)
            {
                CLS_Pedidos ins = new CLS_Pedidos();
                ins.PedidosConfigRuta = txtRuta.Text;
                ins.MtdInsertarParametrosPedidos();
                if(!ins.Exito)
                {
                    XtraMessageBox.Show(ins.Mensaje);
                }
                else
                {
                    XtraMessageBox.Show("Parametros Guardados con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("No existe ruta a guardar");
            }
        }
    }
}