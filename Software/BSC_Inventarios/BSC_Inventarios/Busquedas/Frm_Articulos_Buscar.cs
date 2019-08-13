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
    public partial class Frm_Articulos_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public string vArticuloCodigo { get;  set; }
        public string vArticuloDescripcion { get;  set; }

        public Frm_Articulos_Buscar()
        {
            InitializeComponent();
        }

        private void Frm_Articulos_Buscar_Load(object sender, EventArgs e)
        {
            cmbRegistros.SelectedIndex = 0;
            dtgValArticulos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValArticulos.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Articulos sel = new CLS_Articulos();
            sel.ArticuloDescripcion = txtArticuloDescripcion.Text;
            sel.Registros =Convert.ToInt32(cmbRegistros.EditValue.ToString());
            sel.MtdSeleccionarArticulos();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    dtgArticulos.DataSource = sel.Datos;
                }
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (vArticuloCodigo != string.Empty)
            {
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado un Articulo");
            }
        }

        private void dtgArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValArticulos.GetSelectedRows())
                {
                    DataRow row = this.dtgValArticulos.GetDataRow(i);
                    vArticuloCodigo = row["ArticuloCodigo"].ToString();
                    vArticuloDescripcion = row["ArticuloDescripcion"].ToString();
                    lblProveedor.Caption = string.Format("ArticuloCodigo: {0}", vArticuloCodigo);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgArticulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValArticulos.GetSelectedRows())
                {
                    DataRow row = this.dtgValArticulos.GetDataRow(i);
                    vArticuloCodigo = row["ArticuloCodigo"].ToString();
                    vArticuloDescripcion = row["ArticuloDescripcion"].ToString();
                    lblProveedor.Caption = string.Format("ArticuloCodigo: {0}", vArticuloCodigo);
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