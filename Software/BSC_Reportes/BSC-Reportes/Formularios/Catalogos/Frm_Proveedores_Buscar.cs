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
    public partial class Frm_Proveedores_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Proveedores_Buscar()
        {
            InitializeComponent();
        }

        private void dtgProveedores_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Proveedores_Buscar_Shown(object sender, EventArgs e)
        {
            CLS_Proveedores selpro = new CLS_Proveedores();
            selpro.MtdSeleccionarProveedores();
            if (selpro.Exito)
            {
                if(selpro.Datos.Rows.Count>0)
                {
                    dtgProveedores.DataSource = selpro.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(selpro.Mensaje);
            }
        }
    }
}