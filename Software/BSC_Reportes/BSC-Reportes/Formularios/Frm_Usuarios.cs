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
        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        private void LlenarListaCatalogo()
        {
            CLS_Usuarios gst = new CLS_Usuarios();

            gst.MtdSeleccionarUsuarios();
            if (gst.Exito)
            {
                string UsuariosLogin = string.Empty;
                string UsuariosNombre = string.Empty;
                string UsuariosPassword = string.Empty;
                string UsuariosClase = string.Empty;
                

                for (int x = 0; x < gst.Datos.Rows.Count; x++)
                {
                    UsuariosLogin = gst.Datos.Rows[x][0].ToString();
                    UsuariosNombre = gst.Datos.Rows[x][0].ToString();
                    UsuariosPassword = gst.Datos.Rows[x][0].ToString();
                    if (gst.Datos.Rows[x][0].ToString() == "S")
                    {
                        UsuariosClase = "Super";
                    }
                    if (gst.Datos.Rows[x][0].ToString() == "A")
                    {
                        UsuariosClase = "Administrador";
                    }
                    if (gst.Datos.Rows[x][0].ToString() == "N")
                    {
                        UsuariosClase = "Normal";
                    }
                    
                    
                    CreatNewRow(UsuariosLogin, UsuariosNombre, UsuariosPassword, UsuariosClase);
                }
            }
        }
        private void CreatNewRow(string UsuariosLogin, string UsuariosNombre, string UsuariosPassword, string UsuariosClase)
        {
            gridView1.AddNewRow();

            int rowHandle = gridView1.GetRowHandle(gridView1.DataRowCount);
            if (gridView1.IsNewItemRow(rowHandle))
            {
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[0], UsuariosLogin);
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[1], UsuariosNombre);
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[2], UsuariosPassword);
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[3], UsuariosClase);
                
            }
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            //LlenarListaCatalogo();
            CLS_Usuarios selpro = new CLS_Usuarios();
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
            

            gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            gridView1.Columns[3].OptionsColumn.AllowEdit = false;
        }
    }
}