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
            
                //MakeFirstTable();
                cargagrid();
            
        }

        public void cargagrid()
        {
            if (tUsuarioLogin.Text.Length > 0 && luepantallas.EditValue != null)
            {
                CLS_Pantallas clspan = new CLS_Pantallas();
                clspan.UsuariosLogin = tUsuarioLogin.Text;
                clspan.pantallasid = Convert.ToInt32(luepantallas.EditValue);
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

        public void guardarbotones()
        {
            CLS_Pantallas clspantallas = new CLS_Pantallas();
            clspantallas.UsuariosLogin = tUsuarioLogin.Text;
            clspantallas.pantallasid= Convert.ToInt32(luepantallas.EditValue);

            clspantallas.Mtdeliminararbotones();
            int r = 0, xRow;
           
            for (r=0;r< gridView1.RowCount; r++)
            {
                
                xRow = gridView1.GetVisibleRowHandle(r);
                //fr=gridView1.GetRowCellValue(xRow, "gridColumn3").ToString();
                if (gridView1.GetRowCellValue(xRow, "cheked").ToString()=="True")
                {
                    CLS_Pantallas clspantallas2 = new CLS_Pantallas();
                    clspantallas2.UsuariosLogin = tUsuarioLogin.Text;
                    clspantallas2.pantallasid = Convert.ToInt32(luepantallas.EditValue);
                    clspantallas2.botonesId = Convert.ToInt32(gridView1.GetRowCellValue(xRow, "botonesid"));
                    clspantallas2.Mtdinsertarbotones();
                    
                }
            }
        }

        private void guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                luepantallas.Focus();
                guardarbotones();
            }
            
        }

        public void limpiarcampos()
        {
            tUsuarioLogin.Text="";
            checktodos.Checked = false;
            luepantallas.Text = "Seleccione una ventana";
            gridControl1.DataSource = null;
        }
        public void marcartodos(Boolean checa)
        {
            int r = 0, xRow;

            for (r = 0; r < gridView1.RowCount; r++)
            {

                xRow = gridView1.GetVisibleRowHandle(r);
               
                    gridView1.SetRowCellValue(xRow, "cheked", checa);

                
            }
        }


        private void btnlimpia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            limpiarcampos();
        }

        private void checktodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checktodos.Checked == true)
            {
                marcartodos(true);
                checktodos.Text = "Desmarcar todos";
            }
            else
            {
                marcartodos(false);
                checktodos.Text = "Seleccionar Todos";
            }
        }
    }
}