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

namespace BSC_Sincronizacion
{
    public partial class Frm_Sincronizar : DevExpress.XtraEditors.XtraForm
    {
        public int ArticulosActualizados { get; set; }

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
        private void MakeFirstTable()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();
            // DataRow row;
            column = new DataColumn();
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
        }

        private void LlenarListaCatalogo()
        {
            CLSTablasSincronizarCentral gst = new CLSTablasSincronizarCentral();

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
                    vStatus = "Not updated";
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
            ModificaActualizaCentral();
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

                if (Convert.ToBoolean(GValCatalogos.GetRowCellValue(xRow, "Column1")) )
                {
                    switch (GValCatalogos.GetRowCellValue(xRow, "Column0").ToString())
                    {
                        case "Articulo":
                            AplicaCambiosArticulo(xRow);
                            break;
                        case "ArticuloMedidas":
                            AplicaCambiosArticuloMedidas(xRow);
                            break;
                        case "Caja":
                            
                            break;
                        case "Cliente":
                            
                            break;
                        case "CCliente":
                            
                            break;
                        case "ComprasSugeridas":
                            
                            break;
                        case "CondicionesPagos":
                            
                            break;
                        case "CProveedor":
                            
                            break;
                        case "Documentos":
                            
                            break;
                        case "EntradaMercanciaTipo":
                            
                            break;
                        case "Familia":
                            
                            break;
                        case "FormasdePago":
                            
                            break;
                        case "Iva":
                            
                            break;
                        case "Localidad":
                            
                            break;
                        case "Medidas":
                            
                            break;
                        case "MetodoPagos":
                            
                            break;
                        case "Moneda":
                            
                            break;
                        case "Proveedor":
                            
                            break;
                        case "Roles":
                            
                            break;
                        case "SalidaMercanciaTipo":
                            
                            break;
                        case "Sucursales":
                            
                            break;
                        case "Tarifa":
                            
                            break;
                        case "Usuarios":
                            
                            break;
                        case "Vendedor":
                            
                            break;
                    }
                }
            }
            return Cadena;
        }
        /******* Articulos *****/
        private void AplicaCambiosArticulo(int Fila)
        {
            CLSArticulosLocal SelArt = new CLSArticulosLocal();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticulos();
            if(SelArt.Exito==true)
            {
                ArticulosActualizados = 1;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    lEstatus.Text = "Actualizando Articulos "+ArticulosActualizados+" de "+ SelArt.Datos.Rows.Count;
                    SincronizaArticulos(SelArt.Datos.Rows[i][0].ToString(),SelArt.Datos.Rows[i][1].ToString());
                    pbProgreso.Position = ArticulosActualizados;
                }
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
            }
        }
        private void SincronizaArticulos(string Codigo, string Descripcion)
        {
            CLS_Articulo_Central UdpArt = new CLS_Articulo_Central();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.ArticuloDescripcion = Descripcion;
            UdpArt.MtdActualizarArticulo();
            if(UdpArt.Exito==true)
            {
                ArticulosActualizados++;
            }
        }
        /******* ArticulosMedidas *****/
        private void AplicaCambiosArticuloMedidas(int Fila)
        {
            CLSArticulosMedidasLocal SelArt = new CLSArticulosMedidasLocal();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticulosMedida();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 1;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    lEstatus.Text = "Actualizando Articulos " + ArticulosActualizados + " de " + SelArt.Datos.Rows.Count;
                    SincronizaArticulosMedidas(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString());
                    pbProgreso.Position = ArticulosActualizados;
                }
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
            }
        }
        private void SincronizaArticulosMedidas(string Codigo, string MedidaId)
        {
            CLS_ArticuloMedida_Central UdpArt = new CLS_ArticuloMedida_Central();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.MedidasId = Convert.ToInt32(MedidaId);
            UdpArt.MtdActualizarArticuloMedidas();
            if (UdpArt.Exito == true)
            {
                ArticulosActualizados++;
            }
        }
    }
}