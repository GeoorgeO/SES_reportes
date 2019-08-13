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

namespace BSC_Inventarios
{
    public partial class Frm_Usuario_Pantalla : DevExpress.XtraEditors.XtraForm
    {
        public int InventarioPantallaIdDisponible { get;  set; }
        public int InventarioPantallaIdAsignada { get;  set; }

        public Frm_Usuario_Pantalla()
        {
            InitializeComponent();
        }

        private void Frm_Usuario_Pantalla_Shown(object sender, EventArgs e)
        {
            CargarUsuarios(null);
        }
        private void CargarUsuarios(int? Valor)
        {
            CLS_Usuario_Pantalla conUsuarios = new CLS_Usuario_Pantalla();
            conUsuarios.MtdSeleccionarUsuario();
            if (conUsuarios.Exito)
            {
                cmbUsuarios.Properties.DisplayMember = "UsuariosNombre";
                cmbUsuarios.Properties.ValueMember = "UsuariosId";
                cmbUsuarios.EditValue = Valor;
                cmbUsuarios.Properties.DataSource = conUsuarios.Datos;
            }
        }

        private void cmbUsuarios_EditValueChanged(object sender, EventArgs e)
        {
            if(cmbUsuarios.EditValue!=null)
            {
                CargarDisponible();
                CargarAsignadas();
            }
        }

        private void CargarAsignadas()
        {
            CLS_Usuario_Pantalla conUsuarios = new CLS_Usuario_Pantalla();
            conUsuarios.UsuariosId =Convert.ToInt32(cmbUsuarios.EditValue.ToString());
            conUsuarios.MtdSeleccionarPantallasAsignadas();
            if(conUsuarios.Exito)
            {
                dtgAsignadas.DataSource = conUsuarios.Datos;
                dtgValAsignadas.ClearSelection();
                InventarioPantallaIdAsignada = 0;
            }
        }

        private void CargarDisponible()
        {
            CLS_Usuario_Pantalla conUsuarios = new CLS_Usuario_Pantalla();
            conUsuarios.UsuariosId = Convert.ToInt32(cmbUsuarios.EditValue.ToString());
            conUsuarios.MtdSeleccionarPantallasDisponibles();
            if (conUsuarios.Exito)
            {
                dtgDisponibles.DataSource = conUsuarios.Datos;
                dtgValDisponibles.ClearSelection();
                InventarioPantallaIdDisponible = 0;
            }
        }

        private void btnAsignaTodos_Click(object sender, EventArgs e)
        {
            if(dtgValDisponibles.RowCount>0)
            {
                Boolean Exito = true;
                for (int i = 0; i < dtgValDisponibles.RowCount; i++)
                {
                    int xRow = dtgValDisponibles.GetVisibleRowHandle(i);
                    //Inserta Detalles
                    CLS_Usuario_Pantalla ins = new CLS_Usuario_Pantalla();
                    ins.UsuariosId = Convert.ToInt32(cmbUsuarios.EditValue.ToString());
                    ins.InventarioPantallaId =Convert.ToInt32(dtgValDisponibles.GetRowCellValue(xRow, dtgValDisponibles.Columns["InventarioPantallaId"]).ToString());
                    ins.MtdInsertarPantallasDisponibles();
                    if(!ins.Exito)
                    {
                        Exito = false;
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                }
                if(Exito)
                {
                    CargarAsignadas();
                    CargarDisponible();
                    XtraMessageBox.Show("Se han asignado los permisos con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("Todos los permisos ya estan asignados");
            }
        }

        private void btnDisponeTodos_Click(object sender, EventArgs e)
        {
            if (dtgValAsignadas.RowCount > 0)
            {
                Boolean Exito = true;
                for (int i = 0; i < dtgValAsignadas.RowCount; i++)
                {
                    int xRow = dtgValAsignadas.GetVisibleRowHandle(i);
                    //Inserta Detalles
                    CLS_Usuario_Pantalla del = new CLS_Usuario_Pantalla();
                    del.UsuariosId = Convert.ToInt32(cmbUsuarios.EditValue.ToString());
                    del.InventarioPantallaId = Convert.ToInt32(dtgValAsignadas.GetRowCellValue(xRow, dtgValAsignadas.Columns["InventarioPantallaId"]).ToString());
                    del.MtdEliminarPantallasAsignadas();
                    if (!del.Exito)
                    {
                        Exito = false;
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
                if (Exito)
                {
                    CargarAsignadas();
                    CargarDisponible();
                    XtraMessageBox.Show("Se han quitado los permisos con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("Todos los permisos ya estan disponibles");
            }
        }

        private void dtgDisponibles_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValDisponibles.GetSelectedRows())
                {
                    DataRow row = this.dtgValDisponibles.GetDataRow(i);
                    InventarioPantallaIdDisponible =Convert.ToInt32(row["InventarioPantallaId"].ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgAsignadas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValAsignadas.GetSelectedRows())
                {
                    DataRow row = this.dtgValAsignadas.GetDataRow(i);
                    InventarioPantallaIdAsignada = Convert.ToInt32(row["InventarioPantallaId"].ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnAsigna_Click(object sender, EventArgs e)
        {
            if(cmbUsuarios.EditValue!=null && InventarioPantallaIdDisponible>0)
            {
                CLS_Usuario_Pantalla del = new CLS_Usuario_Pantalla();
                del.UsuariosId = Convert.ToInt32(cmbUsuarios.EditValue.ToString());
                del.InventarioPantallaId = InventarioPantallaIdDisponible;
                del.MtdInsertarPantallasDisponibles();
                if (del.Exito)
                {
                    XtraMessageBox.Show("Se ha asignado el permiso con exito");
                    CargarAsignadas();
                    CargarDisponible();
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Usuario o pantalla a asignar");
            }
        }

        private void btnDispone_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.EditValue != null && InventarioPantallaIdAsignada > 0)
            {
                CLS_Usuario_Pantalla del = new CLS_Usuario_Pantalla();
                del.UsuariosId = Convert.ToInt32(cmbUsuarios.EditValue.ToString());
                del.InventarioPantallaId = InventarioPantallaIdAsignada;
                del.MtdEliminarPantallasAsignadas();
                if (del.Exito)
                {
                    XtraMessageBox.Show("Se ha quitado el permiso con exito");
                    CargarAsignadas();
                    CargarDisponible();
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Usuario o pantalla a quitar");
            }
        }
    }
}