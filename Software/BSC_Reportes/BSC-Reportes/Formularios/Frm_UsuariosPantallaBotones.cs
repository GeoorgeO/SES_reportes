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

        public string GusuariosLogin;
        public char GusuariosClase;


        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }

        public Frm_UsuariosPantallaBotones()
        {
            InitializeComponent();
        }

        private static Frm_UsuariosPantallaBotones m_FormDefInstance;
        public static Frm_UsuariosPantallaBotones DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_UsuariosPantallaBotones();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public void llenarusuario(string usuario, char clase)
        {
            GusuariosLogin = usuario;
            GusuariosClase = clase;
        }


        private void btnselusuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Usuarios frmusu = new Frm_Usuarios();
            frmusu.FrmUsuariosPantallaBotones = this;
            frmusu.IdPantallaBotones = 1;
            frmusu.UsuariosLogin = UsuariosLogin;
            frmusu.UsuarioClase = UsuarioClase;
            //frmusu.llenarusuario(GusuariosLogin, GusuariosClase);
            frmusu.selusu = true;
            frmusu.ShowDialog();
           
        }

        public void cargarusuario(string usuario)
        {
            tUsuarioLogin.Text = usuario;
        }

        private void Frm_UsuariosPantallaBotones_Load(object sender, EventArgs e)
        {

            invisible();

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
            if (GusuariosClase == 'S')
            {
                accesosuperusuario();
            }else
            {
                controlbotones();
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
            Boolean comprueba=false;
           
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
                    if (!clspantallas2.Exito)
                    {
                        comprueba = true;
                    }
                }
            }
            if (comprueba == false)
            {
                XtraMessageBox.Show("Se han guadado los permisos correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                XtraMessageBox.Show("Ha ocurrido un error al intentar guardar los permisos.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        public void controlbotones()
        {
            CLS_Pantallas clspantbotones = new CLS_Pantallas();
            clspantbotones.UsuariosLogin = UsuariosLogin;
            clspantbotones.pantallasid = IdPantallaBotones;
            clspantbotones.Mtdselecionarbotonespantalla();
            if (clspantbotones.Exito.ToString() == "True")
            {
                int t;
                for (t = 0; t < clspantbotones.Datos.Rows.Count; t++)
                {
                    switch (clspantbotones.Datos.Rows[t][0].ToString())
                    {
                        case "13":
                            guardar.Links[0].Visible = true;
                            break;
                        case "14":
                            btnselusuario.Links[0].Visible = true;
                            break;
                        case "15":
                            btnlimpia.Links[0].Visible = true;
                            break;
                        
                    }
                }

            }
            else
            {

            }
        }
        public void accesosuperusuario()
        {
            guardar.Links[0].Visible = true;
            btnselusuario.Links[0].Visible = true;
            btnlimpia.Links[0].Visible = true;
        }
        public void invisible()
        {
            guardar.Links[0].Visible = false;
            btnselusuario.Links[0].Visible = false;
            btnlimpia.Links[0].Visible = false;
        }

    }
}