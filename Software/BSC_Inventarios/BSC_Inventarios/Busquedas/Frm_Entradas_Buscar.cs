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
    public partial class Frm_Entradas_Buscar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Entradas_Buscar()
        {
            InitializeComponent();
        }

        public string FolioEntrada { get;  set; }
        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void Frm_Entradas_Buscar_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            cmbRegistros.SelectedIndex = 0;
            dtgValEntradas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValEntradas.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
            DateTime FFin = Convert.ToDateTime(dtFin.EditValue.ToString());
            CLS_Entradas sel = new CLS_Entradas();
            if (txtEntradaFolio.Text != string.Empty)
            {
                sel.EntradasMercanciaId = Convert.ToInt32(txtEntradaFolio.Text);
            }
            else
            {
                sel.EntradasMercanciaId = null;
            }
            sel.Registros = Convert.ToInt32(cmbRegistros.EditValue.ToString());
            sel.FechaInicio = string.Format("{0}{1}{2} 00:00:00", FInicio.Year, DosCeros(FInicio.Month.ToString()), DosCeros(FInicio.Day.ToString()));
            sel.FechaFin = string.Format("{0}{1}{2} 23:59:59", FFin.Year, DosCeros(FFin.Month.ToString()), DosCeros(FFin.Day.ToString()));
            sel.MtdSeleccionarEntradaBuscar();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    dtgEntradas.DataSource = sel.Datos; 
                }
            }
        }

        private void dtgEntradas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEntradas.GetSelectedRows())
                {
                    DataRow row = this.dtgValEntradas.GetDataRow(i);
                    FolioEntrada = row["EntradaMercanciaId"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (FolioEntrada != string.Empty)
            {
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Entrada");
            }
        }
    }
}