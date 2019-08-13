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
    public partial class Frm_Inventario_Ciego_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public int vFolio { get; set; }
        public string Estatus { get;  set; }

        public Frm_Inventario_Ciego_Buscar()
        {
            InitializeComponent();
        }

        private void Frm_Inventario_Ciego_Buscar_Shown(object sender, EventArgs e)
        {
            dtgValFoliosInventario.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValFoliosInventario.OptionsSelection.EnableAppearanceFocusedCell = false;
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.EEstatus = Estatus;
            sel.MtdSeleccionarFolioPendiente();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    dtgFoliosInventario.DataSource = sel.Datos;
                }
            }
        }

        private void dtgFoliosInventario_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFoliosInventario.GetSelectedRows())
                {
                    DataRow row = this.dtgValFoliosInventario.GetDataRow(i);
                    vFolio =Convert.ToInt32(row["InventarioCiegoFolio"].ToString());
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}