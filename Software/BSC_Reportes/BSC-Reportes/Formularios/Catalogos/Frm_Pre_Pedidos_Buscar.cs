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

namespace BSC_Reportes.Formularios.Catalogos
{
    public partial class Frm_Pre_Pedidos_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pre_Pedidos_Buscar()
        {
            InitializeComponent();
        }

        private void Frm_Proveedores_Buscar_Shown(object sender, EventArgs e)
        {
            dtgValPrePedidos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValPrePedidos.OptionsSelection.EnableAppearanceFocusedCell = false;
            CLS_Pedidos selpro = new CLS_Pedidos();
            selpro.MtdSeleccionarPrePedidos();
            if (selpro.Exito)
            {
                if (selpro.Datos.Rows.Count > 0)
                {
                    dtgPrePedidos.DataSource = selpro.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(selpro.Mensaje);
            }
            lblProveedor.Caption = "Proveedor:";
        }
    }
}