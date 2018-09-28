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
                        case "Cancelacion":
                            Cancelacion(xRow);
                            break;
                        case "CancelacionArticulo":
                            CancelacionArticulo(xRow);
                            break;
                        case "CortesZ":
                            CorteZ(xRow);
                            break;
                        case "CortesZRecargas":
                            CorteZRecargas(xRow);
                            break;
                        case "CortesZRecargasTickets":
                            CortesZRecargasTickets(xRow);
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
            CLSArticuloKardexLocal SelArt = new CLSArticuloKardexLocal();

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
            CLSArticuloKardexCentral UdpArt = new CLSArticuloKardexCentral();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.Existencia = Convert.ToInt32(Existencia);
            UdpArt.ArticuloCosto = Convert.ToDecimal(ArticuloCosto);
            UdpArt.ArticuloIVA = Convert.ToDecimal(ArticuloIVA);
            DateTime Fecha = Convert.ToDateTime(FechaExistencia);
            UdpArt.FechaExistencia = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.MtdActualizarArticuloKardex();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine("No se logro actualizar el articulo ["+ Codigo + "] "+ FechaExistencia);
            }
        }

        /****** Cancelacion ******/
        private void Cancelacion(int Fila)
        {
            CLSCancelacionLocal SelArt = new CLSCancelacionLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCancelacion();
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
                    SincronizaCancelacion(SelArt.Datos.Rows[i][0].ToString(),
                                        SelArt.Datos.Rows[i][1].ToString(),
                                        SelArt.Datos.Rows[i][2].ToString(),
                                        SelArt.Datos.Rows[i][3].ToString(),
                                        SelArt.Datos.Rows[i][4].ToString(),
                                        SelArt.Datos.Rows[i][5].ToString(),
                                        SelArt.Datos.Rows[i][6].ToString(),
                                        SelArt.Datos.Rows[i][7].ToString(),
                                        SelArt.Datos.Rows[i][8].ToString(),
                                        SelArt.Datos.Rows[i][9].ToString(),
                                        SelArt.Datos.Rows[i][10].ToString(),
                                        SelArt.Datos.Rows[i][11].ToString(),
                                        SelArt.Datos.Rows[i][12].ToString());
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
        private void SincronizaCancelacion(string CancelacionId , string CajaId, string TicketId, string UsuarioId,string CancelacionFecha, string CancelacionSubtotal0,
                                            string CancelacionSubtotal16, string CancelacionIva, string CancelacionTotal, string CancelacionAsignadoCorte,
                                            string CorteZId, string CancelacionesTotal, string TicketMayoreoId)
        {
            CLSCancelacionCentral UdpArt = new CLSCancelacionCentral();
            UdpArt.CancelacionId = Convert.ToInt32(CancelacionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.UsuarioId = Convert.ToInt32(UsuarioId);
            DateTime Fecha = Convert.ToDateTime(CancelacionFecha);
            UdpArt.CancelacionFecha = Fecha.Year.ToString()+DosCero(Fecha.Month.ToString())+DosCero(Fecha.Day.ToString());
            UdpArt.CancelacionSubtotal0 = Convert.ToDecimal(CancelacionSubtotal0);
            UdpArt.CancelacionSubtotal16 = Convert.ToDecimal(CancelacionSubtotal16);
            UdpArt.CancelacionIva = Convert.ToDecimal(CancelacionIva);
            UdpArt.CancelacionTotal = Convert.ToDecimal(CancelacionTotal);
            if(CancelacionAsignadoCorte.ToString()=="True")
            {
                UdpArt.CancelacionAsignadoCorte = 1;
            }
            else
            {
                UdpArt.CancelacionAsignadoCorte = 0;
            }
            UdpArt.CorteZId=Convert.ToInt32(CorteZId);
            if (CancelacionesTotal.ToString() == "True")
            {
                UdpArt.CancelacionesTotal = 1;
            }
            else
            {
                UdpArt.CancelacionesTotal = 0;
            }
            UdpArt.TicketMayoreoId= Convert.ToInt32(TicketMayoreoId);
            UdpArt.MtdActualizarCancelacion();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el articulo [{0}] ", CancelacionId));
            }
        }
        /**** Cancelacion Articulo*****/
        private void CancelacionArticulo(int Fila)
        {
            CLSCancelacionArticuloLocal SelArt = new CLSCancelacionArticuloLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCancelacionArticulo();
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
                    SincronizaCancelacionArticulo(SelArt.Datos.Rows[i]["CancelacionId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloUltimoIde"].ToString(),
                                        SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                        SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloPrecio"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloCantidad"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloSubtotal"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloIva"].ToString(),
                                        SelArt.Datos.Rows[i]["CancelacionArticuloTotalLinea"].ToString());
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
        private void SincronizaCancelacionArticulo(string CancelacionId, string CajaId, string CancelacionArticuloUltimoIde, string TicketId,
                                                    string ArticuloCodigo, string CancelacionArticuloPrecio, string CancelacionArticuloCantidad,
                                                    string CancelacionArticuloSubtotal, string CancelacionArticuloIva, string CancelacionArticuloTotalLinea)
        {
            CLSCancelacionArticuloCentral UdpArt = new CLSCancelacionArticuloCentral();
            UdpArt.CancelacionId = Convert.ToInt32(CancelacionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.CancelacionArticuloUltimoIde = Convert.ToInt32(CancelacionArticuloUltimoIde);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.CancelacionArticuloPrecio = Convert.ToDecimal(CancelacionArticuloPrecio);
            UdpArt.CancelacionArticuloCantidad = Convert.ToInt32(CancelacionArticuloCantidad);
            UdpArt.CancelacionArticuloSubtotal=Convert.ToDecimal(CancelacionArticuloSubtotal);
            UdpArt.CancelacionArticuloIva= Convert.ToDecimal(CancelacionArticuloIva);
            UdpArt.CancelacionArticuloTotalLinea= Convert.ToDecimal(CancelacionArticuloTotalLinea);
            UdpArt.MtdActualizarCancelacionArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el articulo [{0}] ", CancelacionId));
            }
        }
        /**** Corte Z*****/
        private void CorteZ(int Fila)
        {
            CLSCorteZLocal SelArt = new CLSCorteZLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCorteZ();
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
                    SincronizaCorteZ(SelArt.Datos.Rows[i]["CortesZId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZFecha"].ToString(),
                                        SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZSub0"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZSub16"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZIva"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZTotal"].ToString());
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
        private void SincronizaCorteZ(string CortesZId, string CajaId, string CortesZFecha, string UsuariosId,
                                                    string CortesZSub0, string CortesZSub16, string CortesZIva,
                                                    string CortesZTotal)
        {
            CLSCorteZCentral UdpArt = new CLSCorteZCentral();
            UdpArt.CortesZId = Convert.ToInt32(CortesZId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            DateTime Fecha = Convert.ToDateTime(CortesZFecha);
            UdpArt.CortesZFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.CortesZSub0 = Convert.ToDecimal(CortesZSub0);
            UdpArt.CortesZSub16 = Convert.ToDecimal(CortesZSub16);
            UdpArt.CortesZIva = Convert.ToDecimal(CortesZIva);
            UdpArt.CortesZTotal = Convert.ToDecimal(CortesZTotal);
            UdpArt.MtdActualizarCorteZ();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el articulo [{0}] ", CortesZId));
            }
        }
        /**** Corte ZRecargas*****/
        private void CorteZRecargas(int Fila)
        {
            CLSCorteZRecargasLocal SelArt = new CLSCorteZRecargasLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCorteZRecargas();
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
                    SincronizaCorteZRecargas(SelArt.Datos.Rows[i]["CortesZRecargasId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasFecha"].ToString(),
                                        SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasSub0"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasSub16"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasIva"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasTotal"].ToString(),
                                        SelArt.Datos.Rows[i]["FacturaGlobalFolio"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasFacturado"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasTotalCosto"].ToString());

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
        private void SincronizaCorteZRecargas(string CortesZRecargasId, string CajaId,string CortesZRecargasFecha,string UsuariosId,
                                                string CortesZRecargasSub0,string CortesZRecargasSub16,string CortesZRecargasIva,
                                                string CortesZRecargasTotal,string FacturaGlobalFolio,string CortesZRecargasFacturado,string CortesZRecargasTotalCosto)
        {

            CLSCorteZRecargasCentral UdpArt = new CLSCorteZRecargasCentral();
            UdpArt.CortesZRecargasId = Convert.ToInt32(CortesZRecargasId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            DateTime Fecha = Convert.ToDateTime(CortesZRecargasFecha);
            UdpArt.CortesZRecargasFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.CortesZRecargasSub0 = Convert.ToDecimal(CortesZRecargasSub0);
            UdpArt.CortesZRecargasSub16 = Convert.ToDecimal(CortesZRecargasSub16);
            UdpArt.CortesZRecargasIva = Convert.ToDecimal(CortesZRecargasIva);
            UdpArt.CortesZRecargasTotal = Convert.ToDecimal(CortesZRecargasTotal);
            UdpArt.FacturaGlobalFolio = Convert.ToInt32(FacturaGlobalFolio);
            if (CortesZRecargasFacturado.ToString() == "True")
            {
                UdpArt.CortesZRecargasFacturado = 1;
            }
            else
            {
                UdpArt.CortesZRecargasFacturado = 0;
            }
            UdpArt.CortesZRecargasTotalCosto = Convert.ToDecimal(CortesZRecargasTotalCosto);
            
            UdpArt.MtdActualizarCorteZRecargas();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el articulo [{0}] ", CortesZRecargasId));
            }
        }
        /**** Corte ZRecargasTickets*****/
        private void CortesZRecargasTickets(int Fila)
        {
            CLSCorteZRecargasTicketsLocal SelArt = new CLSCorteZRecargasTicketsLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCorteZRecargasTickets();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecargasTickets [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaCorteZRecargasTickets(SelArt.Datos.Rows[i]["CortesZRecargasId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasTicketsInicio"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecargasTicketsFin"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores CortesZRecargasTickets.");
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
        private void SincronizaCorteZRecargasTickets(string CortesZRecargasId, string CajaId, string CortesZRecargasTicketsInicio, string CortesZRecargasTicketsFin)
        {

            CLSCortesZRecargasTicketsCentral UdpArt = new CLSCortesZRecargasTicketsCentral();
            UdpArt.CortesZRecargasId = Convert.ToInt32(CortesZRecargasId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.CortesZRecargasTicketsInicio = Convert.ToInt32(CortesZRecargasTicketsInicio);
            UdpArt.CortesZRecargasTicketsFin = Convert.ToInt32(CortesZRecargasTicketsFin);
            UdpArt.MtdActualizarCortesZRecargasTickets();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el articulo [{0}] ", CortesZRecargasId));
            }
        }

    }
}