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
using DevExpress.Utils;
using CapaDeDatos;

namespace BSC_Inventarios
{
    public partial class Frm_Entradas_Existencia : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Entradas_Existencia()
        {
            InitializeComponent();
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValExistencia.RowCount > 0)
            {
                XtraFolderBrowserDialog saveFileDialog = new XtraFolderBrowserDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string Cadena = saveFileDialog.SelectedPath;
                    XtraInputBoxArgs args = new XtraInputBoxArgs();
                    // set required Input Box options 
                    args.Caption = "Ingrese Nombre del Archivo Excel";
                    args.Prompt = "Nombre Archivo";
                    args.DefaultButtonIndex = 0;
                    //args.Showing += Args_Showing;
                    // initialize a DateEdit editor with custom settings 
                    TextEdit editor = new TextEdit();
                    args.Editor = editor;
                    // a default DateEdit value 
                    args.DefaultResponse = "Nombre_Archivo_Excel";
                    // display an Input Box with the custom editor 
                    string result = string.Empty;
                    result = XtraInputBox.Show(args).ToString();
                    if (result != string.Empty)
                    {
                        string path = Cadena + "\\" + result + ".xls";
                        dtgValExistencia.ExportToXlsx(path, new DevExpress.XtraPrinting.XlsxExportOptionsEx
                        {
                            AllowGrouping = DefaultBoolean.False,
                            AllowFixedColumnHeaderPanel = DefaultBoolean.False
                        });
                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        XtraMessageBox.Show("No se ingreso Nombre para el Archivo a exportar");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No existen registros para exportar");
            }
        }

        private void Frm_Entradas_Existencia_Shown(object sender, EventArgs e)
        {
            dtgValExistencia.Columns[0].OptionsColumn.AllowEdit = false;
            dtgValExistencia.Columns[1].OptionsColumn.AllowEdit = false;
            dtgValExistencia.Columns[2].OptionsColumn.AllowEdit = false;
            dtgValExistencia.OptionsView.ShowIndicator = false;
            dtgValExistencia.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            dtgValExistencia.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValExistencia.OptionsSelection.EnableAppearanceFocusedRow = false;
            dtgValExistencia.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValExistencia.OptionsFind.AlwaysVisible = true;
            CargarExistencia();
        }

        private void CargarExistencia()
        {
            CLS_Entradas sel = new CLS_Entradas();
            sel.MtdSeleccionarEntradaExistencia();
            if(sel.Exito)
            {
                dtgExistencia.DataSource = sel.Datos;
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}