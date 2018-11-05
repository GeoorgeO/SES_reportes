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
        int nuevo = 1;

        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        

        public void actualizarGrid()
        {
            CLS_Usuarios selpro = new CLS_Usuarios();
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
            gridColumn5.OptionsColumn.AllowEdit = false;
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
                    string tact = row["UsuariosActivo"].ToString();
                    if (row["UsuariosActivo"].ToString() == "True")
                    {
                        checkactivo.Checked = true;
                    }
                    else
                    {
                        checkactivo.Checked = false;
                    }

                    usuariosLogin.Enabled = false;
                    nuevo = 0;
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
            if (checkactivo.Checked == true)
            {
                UdpUsu.UsuariosActivo = 1;
            }
            else
            {
                UdpUsu.UsuariosActivo = 0;
            }
            UdpUsu.nuevo = nuevo;


            UdpUsu.MtdInsertarUsuarios();
            if (UdpUsu.Exito.ToString() == "True")
            {
               if (UdpUsu.Datos.Rows[0][0].ToString() == "Ya existe el usuario")
                {
                    MessageBox.Show("Ya existe este nickname, favor de verificar.","Aviso");
                }
            }
            else
            {

            }
            actualizarGrid();
            usuariosLogin.Enabled = true;
            nuevo = 1;
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            limpiarFormulario();
            usuariosLogin.Enabled = true;
            nuevo = 1;
        }

        private void btninactivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (activo == 1)
            {
                activo = 0;
                actualizarGrid();
                btninactivos.Caption = "Mostrar activos";
            }
            else
            {
                activo = 1;
                actualizarGrid();
                btninactivos.Caption = "Mostrar inactivos";
            }
        }
    }
}