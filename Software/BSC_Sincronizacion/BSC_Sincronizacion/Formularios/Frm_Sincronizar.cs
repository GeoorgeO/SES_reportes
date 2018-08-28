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
            //for (int i = 0; i < length; i++)
            //{
            //    switch (switch_on)
            //    {
            //        case "Articulo":
            //            MtdArticulo();
            //            break;
            //        default:
            //    }
            //} 
            

            
            //MtdArticuloMedidas();
            //MtdCaja();
            //MtdCCliente();
            //MtdCliente();
            //MtdCondicionesPagos();
            //MtdCProveedor();
            //MtdEntradaMercanciaTipo();
            //MtdFamilia();
            //MtdFormasdePago();
            //MtdIva();
            //MtdLocalidad();
            //MtdMedidas();
            //MtdMetodoPagos();
            //MtdMoneda();
            //MtdProveedor();
            //MtdRoles();
            //MtdSalidaMercanciaTipo();
            //MtdSucursales();
            //MtdTarifa();
            //MtdUsuarios();
            //MtdVendedor();

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
        private string RecorreGrid(string NombreJLSV)
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
                            AplicaCambiosArticulo();
                            break;
                        case "ArticuloMedidas":
                            AplicaCambiosArticulo();
                            break;
                        case "Caja":
                            AplicaCambiosArticulo();
                            break;
                        case "Cliente":
                            AplicaCambiosArticulo();
                            break;
                        case "CCliente":
                            AplicaCambiosArticulo();
                            break;
                        case "ComprasSugeridas":
                            AplicaCambiosArticulo();
                            break;
                        case "CondicionesPagos":
                            AplicaCambiosArticulo();
                            break;
                        case "CProveedor":
                            AplicaCambiosArticulo();
                            break;
                        case "Documentos":
                            AplicaCambiosArticulo();
                            break;
                        case "EntradaMercanciaTipo":
                            AplicaCambiosArticulo();
                            break;
                        case "Familia":
                            AplicaCambiosArticulo();
                            break;
                        case "FormasdePago":
                            AplicaCambiosArticulo();
                            break;
                        case "Iva":
                            AplicaCambiosArticulo();
                            break;
                        case "Localidad":
                            AplicaCambiosArticulo();
                            break;
                        case "Medidas":
                            AplicaCambiosArticulo();
                            break;
                        case "MetodoPagos":
                            AplicaCambiosArticulo();
                            break;
                        case "Moneda":
                            AplicaCambiosArticulo();
                            break;
                        case "Proveedor":
                            AplicaCambiosArticulo();
                            break;
                        case "Roles":
                            AplicaCambiosArticulo();
                            break;
                        case "SalidaMercanciaTipo":
                            AplicaCambiosArticulo();
                            break;
                        case "Sucursales":
                            AplicaCambiosArticulo();
                            break;
                        case "Tarifa":
                            AplicaCambiosArticulo();
                            break;
                        case "Usuarios":
                            AplicaCambiosArticulo();
                            break;
                        case "Vendedor":
                            AplicaCambiosArticulo();
                            break;
                    }
                }
            }
            return Cadena;
        }

        private void AplicaCambiosArticulo()
        {
            CLSArticulosLocal SelArt = new CLSArticulosLocal();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticulos();
            if(SelArt.Exito==true)
            {
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    SincronizaArticulos(SelArt.Datos.Rows[i][0].ToString(),SelArt.Datos.Rows[i][1].ToString());
                }
            }
        }

        private void SincronizaArticulos(string Codigo, string Descripcion)
        {
            
        }
    }
}