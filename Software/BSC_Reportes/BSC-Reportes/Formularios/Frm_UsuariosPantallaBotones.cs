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
    public partial class Frm_UsuariosPantallaBotones : DevExpress.XtraEditors.XtraForm
    {
        public Frm_UsuariosPantallaBotones()
        {
            InitializeComponent();
        }

        private void btnselusuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Usuarios frmusu = new Frm_Usuarios();
            frmusu.FrmUsuariosPantallaBotones = this;
            frmusu.selusu = true;
            frmusu.ShowDialog();
           
        }

        public void cargarusuario(string usuario)
        {
            tUsuarioLogin.Text = usuario;
        }

        private void Frm_UsuariosPantallaBotones_Load(object sender, EventArgs e)
        {
            CLS_Pantallas clasepantallas = new CLS_Pantallas();
             clasepantallas.Mtdseleccionarpantallas();
            if (clasepantallas.Exito)
            {
                if (clasepantallas.Datos.Rows.Count > 0)
                {
                    luepantallas.Properties.DataSource = clasepantallas.Datos;
                }
                else
                {
                    luepantallas.Properties.DataSource = null;
                }
                luepantallas.Properties.DisplayMember = "pantallasNombre";
                luepantallas.Properties.ValueMember = "pantallasId";
                //luepantallas.Text.ToString();
                //luepantallas.EditValue.ToString();
            }
            else
            {
                XtraMessageBox.Show(clasepantallas.Mensaje);
            }
        }

        private void luepantallas_EditValueChanged(object sender, EventArgs e)
        {
            if (tUsuarioLogin.Text.Length > 0)
            {
                cargagrid();
            }
        }

        public void cargagrid()
        {
            CLS_Pantallas clspan = new CLS_Pantallas();
            clspan.UsuariosLogin = tUsuarioLogin.Text;
            clspan.pantallasid= Convert.ToInt32(luepantallas.EditValue);
            clspan.Mtdseleccionarbotones();
            if (clspan.Exito)
            {
                if (clspan.Datos.Rows.Count > 0)
                {
                    gridControl1.DataSource = clspan.Datos;
                }
                else
                {
                    gridControl1.DataSource = null;
                }
                
            }
            else
            {
                XtraMessageBox.Show(clspan.Mensaje);
            }


        }

    }
}