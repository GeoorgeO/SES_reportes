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
using System.IO;

namespace BSC_Reportes
{
    public partial class Frm_Usuarios : DevExpress.XtraEditors.XtraForm
    {

        int activo = 1;

        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        CLS_Usuarios selpro = new CLS_Usuarios();

        public void actualizarGrid()
        {
            selpro.UsuariosActivo = activo;
            selpro.MtdSeleccionarUsuarios();
            if (selpro.Exito)
            {
                if (selpro.Datos.Rows.Count > 0)
                {
                    grid.DataSource = selpro.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(selpro.Mensaje);
            }
            gridView1.RefreshData();
            limpiarFormulario();
        }
  
        public void limpiarFormulario()
        {
            usuariosLogin.Text = "";
            usuariosNombre.Text = "";
            usuariosPassword.Text = "";
            checkadmin.Checked = false;
            checkactivo.Checked = true;
        }
       

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {

            actualizarGrid();
            

            gridColumn3.Visible = false;
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn2.OptionsColumn.AllowEdit = false;
            gridColumn4.OptionsColumn.AllowEdit = false;
        }

        private void grid_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    usuariosLogin.Text = row["UsuariosLogin"].ToString();
                    usuariosNombre.Text = row["UsuariosNombre"].ToString();
                    usuariosPassword.Text = row["UsuariosPassword"].ToString();
                    if (row["UsuariosClase"].ToString()=="A")
                    {
                        checkadmin.Checked = true;
                    }
                    else
                    {
                        checkadmin.Checked = false;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        

        private void guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Usuarios_Insert UdpUsu = new CLS_Usuarios_Insert();
            UdpUsu.UsuariosLogin = usuariosLogin.Text;
            UdpUsu.UsuariosNombre = usuariosNombre.Text;
            UdpUsu.UsuariosPassword = usuariosPassword.Text;
            if (checkadmin.Checked == true)
            {
                UdpUsu.UsuariosClase = "A";
            }
            else
            {
                UdpUsu.UsuariosClase = "N";
            }
            UdpUsu.UsuariosActivo = 1;

            UdpUsu.MtdInsertarUsuarios();
            if (UdpUsu.Exito.ToString() == "True")
            {

            }
            else
            {

            }
            actualizarGrid();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            limpiarFormulario();
        }

        private void btninactivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (activo == 1)
            {
                activo = 0;
            }
            else
            {
                activo = 1;
            }
        }
    }
}