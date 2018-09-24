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

namespace BSC_Coorporativo
{
    public partial class Frm_Sincronizar : DevExpress.XtraEditors.XtraForm
    {
        public int ArticulosActualizados { get; set; }
        public int ArticulosError { get; set; }

        StreamWriter escritura;

        public Frm_Sincronizar()
        {
            InitializeComponent();
        }
        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void limpiarFormulario()
        {
            lEstatus.Text = "";
            pbProgreso.Position = 0;

            int xRow2 = 0;
            for (int i = 0; i < GValCatalogos.RowCount; i++)
            {
                xRow2 = GValCatalogos.GetVisibleRowHandle(i);
                GValCatalogos.SetRowCellValue(xRow2, "Column1", false);

            }

        }

        private void MakeFirstTable()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();
            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Column0";
            column.AutoIncrement = false;
            column.Caption = "Catalogos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "Column1";
            column.AutoIncrement = false;
            column.Caption = "Reenviar";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column2";
            column.AutoIncrement = false;
            column.Caption = "Total Articulos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column3";
            column.AutoIncrement = false;
            column.Caption = "Total Actualizados";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column4";
            column.AutoIncrement = false;
            column.Caption = "Status";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            GCatalogos.DataSource = table;

        }
        private void Frm_Sincronizar_Shown(object sender, EventArgs e)
        {
            this.ClientSize = new Size(672, 712);
            dtFechaInicio.EditValue = DateTime.Now;
            dtFechaFin.EditValue = DateTime.Now;
            MakeFirstTable();
            LlenarListaCatalogo();
            pbProgreso.Position = 0;
            lEstatus.Text = string.Empty;
            GValCatalogos.Columns[0].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[2].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[3].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[4].OptionsColumn.AllowEdit = false;
        }

        private void LlenarListaCatalogo()
        {
            CLSTablasSincronizarServer gst = new CLSTablasSincronizarServer();

            gst.MtdSeleccionarCatalogos();
            if (gst.Exito)
            {
                string vCatalogos = string.Empty;
                Boolean VActualiza = false;
                string vTotalArticulos = string.Empty;
                string vTotalActualizados = string.Empty;
                string vStatus = string.Empty;

                for (int x = 0; x < gst.Datos.Rows.Count; x++)
                {
                    vCatalogos = gst.Datos.Rows[x][0].ToString();
                    VActualiza = false;
                    vTotalArticulos = "0";
                    vTotalActualizados = "0";
                    vStatus = "No Actualizado";
                    CreatNewRow(vCatalogos, VActualiza, vTotalArticulos, vTotalActualizados, vStatus);
                }
            }
        }
        private void CreatNewRow(string vCatalogos, Boolean VActualiza, string vTotalArticulos, string vTotalActualizados, String vStatus)
        {
            GValCatalogos.AddNewRow();

            int rowHandle = GValCatalogos.GetRowHandle(GValCatalogos.DataRowCount);
            if (GValCatalogos.IsNewItemRow(rowHandle))
            {
                GValCatalogos.SetRowCellValue(rowHandle, GValCatalogos.Columns[0], vCatalogos);
                GValCatalogos.SetRowCellValue(rowHandle, GValCatalogos.Columns[1], VActualiza);
                GValCatalogos.SetRowCellValue(rowHandle, GValCatalogos.Columns[2], vTotalArticulos);
                GValCatalogos.SetRowCellValue(rowHandle, GValCatalogos.Columns[3], vTotalActualizados);
                GValCatalogos.SetRowCellValue(rowHandle, GValCatalogos.Columns[4], vStatus);
            }
        }
        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            Boolean seleccionocat;
            seleccionocat = false;
            for (int i = 0; i < GValCatalogos.RowCount; i++)
            {
                if (Convert.ToBoolean(GValCatalogos.GetRowCellValue(i, "Column1")))
                {
                    seleccionocat = true;
                    break;
                }
            }
            if (seleccionocat == true)
            {
                Directory.CreateDirectory(@"C:\\Registros");
                string tvar = @"C:\\Registros\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";

                escritura = File.CreateText(tvar);
                ModificaActualizaCentral();
            }
            else
            {
                MessageBox.Show("No has seleccionado ninguna tabla de la lista, slecciona las que deseas sincronizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            
        }

        private void btnDataBase_Click(object sender, EventArgs e)
        {
            Frm_Conexiones frm = new Frm_Conexiones();
            frm.ShowDialog();
        }

        private void ModificaActualizaCentral()
        {
            RecorreGrid();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                int xRow = 0;
                for (int i = 0; i < GValCatalogos.RowCount; i++)
                {
                    xRow = GValCatalogos.GetVisibleRowHandle(i);
                    GValCatalogos.SetRowCellValue(xRow, "Column1", true);
                }
            }
            else
            {
                int xRow = 0;
                for (int i = 0; i < GValCatalogos.RowCount; i++)
                {
                    xRow = GValCatalogos.GetVisibleRowHandle(i);
                    GValCatalogos.SetRowCellValue(xRow, "Column1", false);
                }
            }
        }
        private string RecorreGrid()
        {
            int xRow = 0;
            string Cadena = string.Empty;

            for (int i = 0; i < GValCatalogos.RowCount; i++)
            {
                xRow = GValCatalogos.GetVisibleRowHandle(i);
                ArticulosError = 0;
                if (Convert.ToBoolean(GValCatalogos.GetRowCellValue(xRow, "Column1")))
                {
                    pbProgreso.Position = 0;
                    switch (GValCatalogos.GetRowCellValue(xRow, "Column0").ToString())
                    {
                        case "ArticuloKardex":
                            ArticuloKardex(xRow);
                            break;
                    }
                }
            }
            limpiarFormulario();
            escritura.Close();
            MessageBox.Show("El proceso Finalizo.", "Información", MessageBoxButtons.OK,MessageBoxIcon.Information);
            return Cadena;
        }
        /******* Articulos *****/
        private void ArticuloKardex(int Fila)
        {
            CLSArticuloKardex SelArt = new CLSArticuloKardex();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();

            SelArt.MtdSeleccionarArticuloKardex();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo Articulo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaArticulos(SelArt.Datos.Rows[i][0].ToString(), 
                                        SelArt.Datos.Rows[i][1].ToString(),
                                        SelArt.Datos.Rows[i][2].ToString(),
                                        SelArt.Datos.Rows[i][3].ToString(),
                                        SelArt.Datos.Rows[i][4].ToString());
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Articulos.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Articulos.");
            }
        }
        private void SincronizaArticulos(string Codigo, string Existencia,string ArticuloCosto,string ArticuloIVA,string FechaExistencia)
        {
            CLS_Articulo_Central UdpArt = new CLS_Articulo_Central();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.ArticuloDescripcion = Descripcion;
            UdpArt.MtdActualizarArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine("No se logro actualizar el articulo ["+ Codigo + "] "+ Descripcion);
            }
        }
    }
}