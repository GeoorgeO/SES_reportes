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
                        case "CortesZRecibos":
                            CortesZRecibos(xRow);
                            break;
                        case "CortesZRecibosDetalles":
                            CortesZRecibosDetalles(xRow);
                            break;
                        case "Devolucion":
                            Devolucion(xRow);
                            break;
                        case "DevolucionArticulo":
                            DevolucionArticulo(xRow);
                            break;
                        case "DevolucionMayoreo":
                            //DevolucionMayoreo(xRow);
                            break;
                        case "DevolucionMayoreoArticulo":
                            //DevolucionMayoreoArticulo(xRow);
                            break;
                        case "DevolucionPre":
                            //DevolucionPre(xRow);
                            break;
                        case "DevolucionPreDetalles":
                            //DevolucionPreDetalles(xRow);
                            break;
                        case "EntradaMercancia":
                            //EntradaMercancia(xRow);
                            break;
                        case "EntradaMercanciaArticulo":
                            //EntradaMercanciaArticulo(xRow);
                            break;
                        case "RecibosRemisiones":
                            //RecibosRemisiones(xRow);
                            break;
                        case "SalidaMercancia":
                            //SalidaMercancia(xRow);
                            break;
                        case "SalidaMercanciaArticulo":
                            //SalidaMercanciaArticulo(xRow);
                            break;
                        case "Ticket":
                            Ticket(xRow);
                            break;
                        case "TicketArticulo":
                            TicketArticulo(xRow);
                            break;
                        case "TicketMayoreo":
                            TicketMayoreo(xRow);
                            break;
                        case "TicketMayoreoArticulo":
                            TicketMayoreoArticulo(xRow);
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
        /**** CortesZRecibos*****/
        private void CortesZRecibos(int Fila)
        {
            CLSCortesZRecibosLocal SelArt = new CLSCortesZRecibosLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCortesZRecibos();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaCortesZRecibos(SelArt.Datos.Rows[i]["CortesZRecibosId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecibosFecha"].ToString(),
                                        SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecibosTotal"].ToString());
               
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
        private void SincronizaCortesZRecibos(string CortesZRecibosId, string CortesZRecibosFecha, string UsuariosId, string CortesZRecibosTotal)
        {
            CLSCortesZRecibosCentral UdpArt = new CLSCortesZRecibosCentral();
            UdpArt.CortesZRecibosId = Convert.ToInt32(CortesZRecibosId);
            DateTime Fecha = Convert.ToDateTime(CortesZRecibosFecha);
            UdpArt.CortesZRecibosFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.CortesZRecibosTotal = Convert.ToDecimal(CortesZRecibosTotal);
            UdpArt.MtdActualizarCortesZRecibos();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el CortesZRecibosId [{0}] ", CortesZRecibosId));
            }
        }
        /**** CortesZRecibosDetalles*****/
        private void CortesZRecibosDetalles(int Fila)
        {
            CLSCortesZRecibosDetallesLocal SelArt = new CLSCortesZRecibosDetallesLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCortesZRecibosDetalles();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaCortesZRecibosDetalles(SelArt.Datos.Rows[i]["CortesZRecibosId"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecibosInicio"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZRecibosFin"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZNCreditoInicio"].ToString(),
                                        SelArt.Datos.Rows[i]["CortesZNCreditoFin"].ToString());

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
        private void SincronizaCortesZRecibosDetalles(string CortesZRecibosId, string CortesZRecibosInicio, string CortesZRecibosFin,
                                                        string CortesZNCreditoInicio,string CortesZNCreditoFin)
        {
            CLSCortesZRecibosDetallesCentral UdpArt = new CLSCortesZRecibosDetallesCentral();
            UdpArt.CortesZRecibosId = Convert.ToInt32(CortesZRecibosId);
            UdpArt.CortesZRecibosInicio = Convert.ToInt32(CortesZRecibosInicio);
            UdpArt.CortesZRecibosFin = Convert.ToInt32(CortesZRecibosFin);
            UdpArt.CortesZNCreditoInicio = Convert.ToInt32(CortesZNCreditoInicio);
            UdpArt.CortesZNCreditoFin = Convert.ToInt32(CortesZNCreditoFin);
            UdpArt.MtdActualizarCortesZRecibosDetalles();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el CortesZRecibosId [{0}] ", CortesZRecibosId));
            }
        }
        /**** Devolucion*****/
        private void Devolucion(int Fila)
        {
            CLSDevolucionLocal SelArt = new CLSDevolucionLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarDevolucion();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaDevolucion(SelArt.Datos.Rows[i]["DevolucionId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                        SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionFecha"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionSubtotal0"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionSubtotal16"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionIva"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionTotal"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionAsignadoCorte"].ToString(),
                                        SelArt.Datos.Rows[i]["CorteZId"].ToString());
 
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
        private void SincronizaDevolucion(string DevolucionId, string CajaId, string TicketId, string UsuariosId, string DevolucionFecha,
                                            string DevolucionSubtotal0, string DevolucionSubtotal16, string DevolucionIva, string DevolucionTotal,
                                            string DevolucionAsignadoCorte, string CorteZId)
        {
            CLSDevolucionCentral UdpArt = new CLSDevolucionCentral();
            UdpArt.DevolucionId = Convert.ToInt32(DevolucionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            DateTime Fecha = Convert.ToDateTime(DevolucionFecha);
            UdpArt.DevolucionFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.DevolucionSubtotal0 = Convert.ToDecimal(DevolucionSubtotal0);
            UdpArt.DevolucionSubtotal16 = Convert.ToDecimal(DevolucionSubtotal16);
            UdpArt.DevolucionIva = Convert.ToDecimal(DevolucionIva);
            UdpArt.DevolucionTotal = Convert.ToDecimal(DevolucionTotal);
            if(Convert.ToBoolean(DevolucionAsignadoCorte))
            {
                UdpArt.DevolucionAsignadoCorte = 1;
            }
            else
            {
                UdpArt.DevolucionAsignadoCorte = 0;
            }
            UdpArt.CorteZId = Convert.ToInt32(CorteZId);
            UdpArt.MtdActualizarDevolucion();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Devolucion [{0}] ", DevolucionId));
            }
        }
        /**** DevolucionArticulo*****/
        private void DevolucionArticulo(int Fila)
        {
            CLSDevolucionLocal SelArt = new CLSDevolucionLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarDevolucion();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaDevolucionArticulo(SelArt.Datos.Rows[i]["DevolucionId"].ToString(),
                                        SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloUltimoIde"].ToString(),
                                        SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloPrecio"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloCantidad"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloSubtotal"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloIva"].ToString(),
                                        SelArt.Datos.Rows[i]["DevolucionArticuloTotalLinea"].ToString());

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
        private void SincronizaDevolucionArticulo(string DevolucionId, string CajaId, string DevolucionArticuloUltimoIde, string ArticuloCodigo,
                                                string DevolucionArticuloPrecio, string DevolucionArticuloCantidad, string DevolucionArticuloSubtotal,
                                                string DevolucionArticuloIva, string DevolucionArticuloTotalLinea)
        {

            CLSDevolucionArticuloCentral UdpArt = new CLSDevolucionArticuloCentral();
            UdpArt.DevolucionId = Convert.ToInt32(DevolucionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.DevolucionArticuloUltimoIde = Convert.ToInt32(DevolucionArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.DevolucionArticuloPrecio = Convert.ToDecimal(DevolucionArticuloPrecio);
            UdpArt.DevolucionArticuloCantidad = Convert.ToInt32(DevolucionArticuloCantidad);
            UdpArt.DevolucionArticuloSubtotal = Convert.ToDecimal(DevolucionArticuloSubtotal);
            UdpArt.DevolucionArticuloIva = Convert.ToDecimal(DevolucionArticuloIva);
            UdpArt.DevolucionArticuloTotalLinea = Convert.ToDecimal(DevolucionArticuloTotalLinea);
            UdpArt.MtdActualizarDevolucionArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Devolucion [{0}] ", DevolucionId));
            }
        }
        /**** DevolucionMayoreo*****/
        private void DevolucionMayoreo(int Fila)
        {
            CLSDevolucionMayoreoLocal SelArt = new CLSDevolucionMayoreoLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarDevolucionMayoreo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaDevolucionMayoreo(SelArt.Datos.Rows[i]["DevolucionId"].ToString(),
                                                SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                                SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                                SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                                SelArt.Datos.Rows[i]["Clienteid"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionFecha"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionSubtotal0"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionSubtotal16"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionIva"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionDescuento"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionTotal"].ToString(),
                                                SelArt.Datos.Rows[i]["TicketTotalLetra"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionConcepto"].ToString(),
                                                SelArt.Datos.Rows[i]["DevolucionAsignado"].ToString(),
                                                SelArt.Datos.Rows[i]["CortesZRecibosId"].ToString(),
                                                SelArt.Datos.Rows[i]["NC_Concepto"].ToString());

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
        private void SincronizaDevolucionMayoreo(string DevolucionId, string CajaId, string TicketId, string UsuariosId, string Clienteid, string DevolucionFecha,
                                            string DevolucionSubtotal0, string DevolucionSubtotal16, string DevolucionIva, string DevolucionDescuento,
                                            string DevolucionTotal, string TicketTotalLetra, string DevolucionConcepto, string DevolucionAsignado, string CortesZRecibosId,
                                            string NC_Concepto)
        {
            CLSDevolucionMayoreoCentral UdpArt = new CLSDevolucionMayoreoCentral();
            UdpArt.DevolucionId = Convert.ToInt32(DevolucionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.Clienteid = Convert.ToInt32(Clienteid);
            DateTime Fecha = Convert.ToDateTime(DevolucionFecha);
            UdpArt.DevolucionFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.DevolucionSubtotal0 = Convert.ToDecimal(DevolucionSubtotal0);
            UdpArt.DevolucionSubtotal16 = Convert.ToDecimal(DevolucionSubtotal16);
            UdpArt.DevolucionIva = Convert.ToDecimal(DevolucionIva);
            UdpArt.DevolucionDescuento = Convert.ToDecimal(DevolucionDescuento);
            UdpArt.DevolucionTotal = Convert.ToDecimal(DevolucionTotal);
            UdpArt.TicketTotalLetra = TicketTotalLetra;
            UdpArt.DevolucionConcepto = DevolucionConcepto;
            UdpArt.DevolucionAsignado = Convert.ToInt32(DevolucionAsignado);
            UdpArt.CortesZRecibosId = Convert.ToInt32(CortesZRecibosId);
            UdpArt.NC_Concepto = NC_Concepto;
            UdpArt.MtdActualizarDevolucionMayoreo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Devolucion [{0}] ", DevolucionId));
            }
        }
        /**** DevolucionMayoreoArticulo*****/
        private void DevolucionMayoreoArticulo(int Fila)
        {
            CLSDevolucionMayoreoLocal SelArt = new CLSDevolucionMayoreoLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarDevolucionMayoreo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaDevolucionMayoreoArticulo(SelArt.Datos.Rows[i][" DevolucionId"].ToString(),
                                                    SelArt.Datos.Rows[i][" CajaId"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloUltimoIde"].ToString(),
                                                    SelArt.Datos.Rows[i][" ArticuloCodigo"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloPrecio"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloCantidad"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloSubtotal"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloIva"].ToString(),
                                                    SelArt.Datos.Rows[i][" DevolucionArticuloTotalLinea"].ToString());

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
        private void SincronizaDevolucionMayoreoArticulo(string DevolucionId, string CajaId, string DevolucionArticuloUltimoIde, string ArticuloCodigo,
                                                string DevolucionArticuloPrecio, string DevolucionArticuloCantidad, string DevolucionArticuloSubtotal,
                                                string DevolucionArticuloIva, string DevolucionArticuloTotalLinea)
        {
            CLSDevolucionMayoreoArticuloCentral UdpArt = new CLSDevolucionMayoreoArticuloCentral();
            UdpArt.DevolucionId = Convert.ToInt32(DevolucionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.DevolucionArticuloUltimoIde = Convert.ToInt32(DevolucionArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.DevolucionArticuloPrecio = Convert.ToDecimal(DevolucionArticuloPrecio);
            UdpArt.DevolucionArticuloCantidad = Convert.ToInt32(DevolucionArticuloCantidad);
            UdpArt.DevolucionArticuloSubtotal = Convert.ToDecimal(DevolucionArticuloSubtotal);
            UdpArt.DevolucionArticuloIva = Convert.ToDecimal(DevolucionArticuloIva);
            UdpArt.DevolucionArticuloTotalLinea = Convert.ToDecimal(DevolucionArticuloTotalLinea);
            UdpArt.MtdActualizarDevolucionMayoreoArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Devolucion [{0}] ", DevolucionId));
            }
        }
        /**** DevolucionPre*****/
        private void DevolucionPre(int Fila)
        {
            CLSDevolucionPreLocal SelArt = new CLSDevolucionPreLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarDevolucionPre();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "CortesZRecibos [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaDevolucionPre(SelArt.Datos.Rows[i][" DevolucionPreId"].ToString(),
                                        SelArt.Datos.Rows[i][" TicketId"].ToString(),
                                        SelArt.Datos.Rows[i][" CajaId"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreFecha"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreTArticulos"].ToString(),
                                        SelArt.Datos.Rows[i][" UsuarioId"].ToString(),
                                        SelArt.Datos.Rows[i][" VendedorId"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreSub0"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreSub16"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreIva"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreTotal"].ToString(),
                                        SelArt.Datos.Rows[i][" DevolucionPreProcesada"].ToString());

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
        private void SincronizaDevolucionPre(string DevolucionPreId, string TicketId, string CajaId, string DevolucionPreFecha, string DevolucionPreTArticulos,
                                    string UsuarioId, string VendedorId, string DevolucionPreSub0, string DevolucionPreSub16, string DevolucionPreIva,
                                    string DevolucionPreTotal, string DevolucionPreProcesada)
        {
            CLSDevolucionPreCentral UdpArt = new CLSDevolucionPreCentral();
            UdpArt.DevolucionPreId = Convert.ToInt32(DevolucionPreId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            DateTime Fecha = Convert.ToDateTime(DevolucionPreFecha);
            UdpArt.DevolucionPreFecha = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.DevolucionPreTArticulos = Convert.ToInt32(DevolucionPreTArticulos);
            UdpArt.UsuarioId = Convert.ToInt32(UsuarioId);
            UdpArt.VendedorId = Convert.ToInt32(VendedorId);
            UdpArt.DevolucionPreSub0 = Convert.ToDecimal(DevolucionPreSub0);
            UdpArt.DevolucionPreSub16 = Convert.ToDecimal(DevolucionPreSub16);
            UdpArt.DevolucionPreSub16 = Convert.ToDecimal(DevolucionPreSub16);
            UdpArt.DevolucionPreIva = Convert.ToDecimal(DevolucionPreIva);
            UdpArt.DevolucionPreTotal = Convert.ToDecimal(DevolucionPreTotal);
            UdpArt.DevolucionPreProcesada = Convert.ToInt32(DevolucionPreProcesada);
            UdpArt.MtdActualizarDevolucionPre();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar la DevolucionPre [{0}] ", DevolucionPreId));
            }
        }
        /**** EntradaMercancia*****/
        private void EntradaMercancia(int Fila)
        {
            CLSEntradaMercanciaLocal SelArt = new CLSEntradaMercanciaLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarEntradaMercancia();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "SalidaMercancia [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaEntradaMercancia(SelArt.Datos.Rows[i]["EntradaMercanciaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SucursalesId"].ToString(),
                                                     SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaTipoId"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaFecha"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaUnidades"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaSub0"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaSub16"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaIva"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradaMercanciaTotal"].ToString(),
                                                     SelArt.Datos.Rows[i]["Observaciones"].ToString(),
                                                     SelArt.Datos.Rows[i]["Referencias"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores EntradaMercancia.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla EntradaMercancia.");
            }
        }
        private void SincronizaEntradaMercancia(string EntradaMercanciaId, string SucursalesId, string UsuariosId, string EntradaMercanciaTipoId,
                                                    string EntradaMercanciaFecha, string EntradaMercanciaUnidades, string EntradaMercanciaSub0,
                                                    string EntradaMercanciaSub16, string EntradaMercanciaIva, string EntradaMercanciaTotal, string Observaciones, string Referencias)
        {
            CLSEntradaMercanciaCentral UdpArt = new CLSEntradaMercanciaCentral();
            UdpArt.EntradaMercanciaId = Convert.ToInt32(EntradaMercanciaId);
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.EntradaMercanciaTipoId = Convert.ToInt32(EntradaMercanciaTipoId);
            UdpArt.EntradaMercanciaFecha = EntradaMercanciaFecha;
            UdpArt.EntradaMercanciaUnidades = Convert.ToInt32(EntradaMercanciaUnidades);
            UdpArt.EntradaMercanciaSub0 = Convert.ToDecimal(EntradaMercanciaSub0);
            UdpArt.EntradaMercanciaSub16 = Convert.ToDecimal(EntradaMercanciaSub16);
            UdpArt.EntradaMercanciaIva = Convert.ToInt32(EntradaMercanciaIva);
            UdpArt.EntradaMercanciaTotal = Convert.ToDecimal(EntradaMercanciaTotal);
            UdpArt.Observaciones = Observaciones;
            UdpArt.Referencias = Referencias;


            UdpArt.MtdActualizarEntradaMercancia();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar la Entrada de Mercancia [{0}] ", EntradaMercanciaId));
            }
        }

        /**** EntradaMercanciaArticulo*****/
        private void EntradaMercanciaArticulo(int Fila)
        {
            CLSEntradaMercanciaArticuloLocal SelArt = new CLSEntradaMercanciaArticuloLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarEntradaMercanciaArticulo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "EntradaMercanciaArticulo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaEntradaMercanciaArticulo(SelArt.Datos.Rows[i]["EntradasMercanciaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SucursalesId"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloUltimoIde"].ToString(),
                                                     SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloCantidad"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloSub0"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloSub16"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloIva"].ToString(),
                                                     SelArt.Datos.Rows[i]["EntradasMercanciaArticuloTotal"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores EntradaMercanciaArticulo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla EntradaMercanciaArticulo.");
            }
        }
        private void SincronizaEntradaMercanciaArticulo(string EntradasMercanciaId, string SucursalesId, string EntradasMercanciaArticuloUltimoIde, string ArticuloCodigo,
                                                    string EntradasMercanciaArticuloCantidad, string EntradasMercanciaArticuloSub0, string EntradasMercanciaArticuloSub16,
                                                    string EntradasMercanciaArticuloIva, string EntradasMercanciaArticuloTotal)
        {
            CLSEntradaMercanciaArticuloCentral UdpArt = new CLSEntradaMercanciaArticuloCentral();
            UdpArt.EntradasMercanciaId = Convert.ToInt32(EntradasMercanciaId);
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.EntradasMercanciaArticuloUltimoIde = Convert.ToInt32(EntradasMercanciaArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.EntradasMercanciaArticuloCantidad = Convert.ToInt32(EntradasMercanciaArticuloCantidad);
            UdpArt.EntradasMercanciaArticuloSub0 = Convert.ToInt32(EntradasMercanciaArticuloSub0);
            UdpArt.EntradasMercanciaArticuloSub16 = Convert.ToDecimal(EntradasMercanciaArticuloSub16);
            UdpArt.EntradasMercanciaArticuloIva = Convert.ToDecimal(EntradasMercanciaArticuloIva);
            UdpArt.EntradasMercanciaArticuloTotal = Convert.ToInt32(EntradasMercanciaArticuloTotal);
            UdpArt.MtdActualizarEntradaMercanciaArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el EntradaMercanciaArticulo [{0}] ", EntradasMercanciaId));
            }
        }

        /**** RecibosRemisiones*****/
        private void RecibosRemisiones(int Fila)
        {
            CLSRecibosRemisionesLocal SelArt = new CLSRecibosRemisionesLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarRecibosRemisiones();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "RecibosRemisiones [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaRecibosRemisiones(SelArt.Datos.Rows[i]["RecibosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                                     SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["RecibosTotal"].ToString(),
                                                     SelArt.Datos.Rows[i]["ReciboTotalLetra"].ToString(),
                                                     SelArt.Datos.Rows[i]["ReciboFecha"].ToString(),
                                                     SelArt.Datos.Rows[i]["ClienteId"].ToString(),
                                                     SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["DocumentosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["ReciboConcepto"].ToString(),
                                                     SelArt.Datos.Rows[i]["CortesZRecibosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["FormasdePagoCobranzaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["RecibosAsignado"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores RecibosRemisiones.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla RecibosRemisiones.");
            }
        }
        private void SincronizaRecibosRemisiones(string RecibosId, string TicketId, string CajaId, string RecibosTotal,
                                                    string ReciboTotalLetra, string ReciboFecha, string ClienteId,
                                                    string UsuariosId, string DocumentosId, string ReciboConcepto, string CortesZRecibosId, string FormasdePagoCobranzaId, string RecibosAsignado)
        {
            CLSRecibosRemisionesCentral UdpArt = new CLSRecibosRemisionesCentral();
            UdpArt.RecibosId = Convert.ToInt32(RecibosId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.RecibosTotal = Convert.ToDecimal(RecibosTotal);
            UdpArt.ReciboTotalLetra = ReciboTotalLetra;
            UdpArt.ReciboFecha = ReciboFecha;
            UdpArt.ClienteId = Convert.ToInt32(ClienteId);
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.DocumentosId = Convert.ToInt32(DocumentosId);
            UdpArt.ReciboConcepto = ReciboConcepto;
            UdpArt.CortesZRecibosId = Convert.ToInt32(CortesZRecibosId);
            UdpArt.FormasdePagoCobranzaId = Convert.ToInt32(FormasdePagoCobranzaId);
            UdpArt.RecibosAsignado = Convert.ToInt32(RecibosAsignado);

            UdpArt.MtdActualizarRecibosRemisiones();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Recibo de Remision [{0}] ", RecibosId));
            }
        }

        /**** SalidaMercancia*****/
        private void SalidaMercancia(int Fila)
        {
            CLSSalidaMercanciaLocal SelArt = new CLSSalidaMercanciaLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarSalidaMercancia();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "SalidaMercancia [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaSalidaMercancia(SelArt.Datos.Rows[i]["SalidaMercanciaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SucursalesId"].ToString(),
                                                     SelArt.Datos.Rows[i]["UsuariosId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaTipoId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaFecha"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaUnidades"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaSub0"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaSub16"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaIva"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaTotal"].ToString(),
                                                     SelArt.Datos.Rows[i]["Observaciones"].ToString(),
                                                     SelArt.Datos.Rows[i]["Referencias"].ToString(),
                                                     SelArt.Datos.Rows[i]["ParaSucursal"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores SalidaMercancia.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla SalidaMercancia.");
            }
        }
        private void SincronizaSalidaMercancia(string SalidaMercanciaId, string SucursalesId, string UsuariosId, string SalidaMercanciaTipoId,
                                                    string SalidaMercanciaFecha, string SalidaMercanciaUnidades, string SalidaMercanciaSub0,
                                                    string SalidaMercanciaSub16, string SalidaMercanciaIva, string SalidaMercanciaTotal, string Observaciones, string Referencias, string ParaSucursal)
        {
            CLSSalidaMercanciaCentral UdpArt = new CLSSalidaMercanciaCentral();
            UdpArt.SalidaMercanciaId = Convert.ToInt32(SalidaMercanciaId);
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.SalidaMercanciaTipoId = Convert.ToInt32(SalidaMercanciaTipoId);
            UdpArt.SalidaMercanciaFecha = SalidaMercanciaFecha;
            UdpArt.SalidaMercanciaUnidades = Convert.ToInt32(SalidaMercanciaUnidades);
            UdpArt.SalidaMercanciaSub0 = Convert.ToDecimal(SalidaMercanciaSub0);
            UdpArt.SalidaMercanciaSub16 = Convert.ToDecimal(SalidaMercanciaSub16);
            UdpArt.SalidaMercanciaIva = Convert.ToInt32(SalidaMercanciaIva);
            UdpArt.SalidaMercanciaTotal = Convert.ToDecimal(SalidaMercanciaTotal);
            UdpArt.Observaciones = Observaciones;
            UdpArt.Referencias = Referencias;
            UdpArt.ParaSucursal = ParaSucursal;

            UdpArt.MtdActualizarSalidaMercancia();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Salida de Mercancia [{0}] ", SalidaMercanciaId));
            }
        }

        /**** SalidaMercanciaArticulo*****/
        private void SalidaMercanciaArticulo(int Fila)
        {
            CLSSalidaMercanciaArticuloLocal SelArt = new CLSSalidaMercanciaArticuloLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarSalidaMercanciaArticulo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "SalidaMercanciaArticulo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaSalidaMercanciaArticulo(SelArt.Datos.Rows[i]["SalidaMercanciaId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SucursalesId"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloUltimoIde"].ToString(),
                                                     SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloCantidad"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloSub0"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloSub16"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloIva"].ToString(),
                                                     SelArt.Datos.Rows[i]["SalidaMercanciaArticuloTotal"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores SalidaMercanciaArticulo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla SalidaMercanciaArticulo.");
            }
        }
        private void SincronizaSalidaMercanciaArticulo(string SalidaMercanciaId, string SucursalesId, string SalidaMercanciaArticuloUltimoIde, string ArticuloCodigo,
                                                    string SalidaMercanciaArticuloCantidad, string SalidaMercanciaArticuloSub0, string SalidaMercanciaArticuloSub16,
                                                    string SalidaMercanciaArticuloIva, string SalidaMercanciaArticuloTotal)
        {
            CLSSalidaMercanciaArticuloCentral UdpArt = new CLSSalidaMercanciaArticuloCentral();
            UdpArt.SalidaMercanciaId = Convert.ToInt32(SalidaMercanciaId);
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.SalidaMercanciaArticuloUltimoIde = Convert.ToInt32(SalidaMercanciaArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.SalidaMercanciaArticuloCantidad = Convert.ToInt32(SalidaMercanciaArticuloCantidad);
            UdpArt.SalidaMercanciaArticuloSub0 = Convert.ToInt32(SalidaMercanciaArticuloSub0);
            UdpArt.SalidaMercanciaArticuloSub16 = Convert.ToDecimal(SalidaMercanciaArticuloSub16);
            UdpArt.SalidaMercanciaArticuloIva = Convert.ToDecimal(SalidaMercanciaArticuloIva);
            UdpArt.SalidaMercanciaArticuloTotal = Convert.ToInt32(SalidaMercanciaArticuloTotal);
            UdpArt.MtdActualizarSalidaMercanciaArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el SalidaMercanciaArticulo [{0}] ", SalidaMercanciaId));
            }
        }
        /**** Ticket*****/
        private void Ticket(int Fila)
        {
            CLSTicketLocal SelArt = new CLSTicketLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarTicket();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Ticket [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaTicket(SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                    SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                    SelArt.Datos.Rows[i]["UsuarioId"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketFecha"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketHora"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketSubtotal0"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketSubtotal16"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketIva"].ToString(),
                                    SelArt.Datos.Rows[i]["TicketTotal"].ToString(),
                                    SelArt.Datos.Rows[i]["CorteZId"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Ticket.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Ticket.");
            }
        }
        private void SincronizaTicket(string TicketId, string CajaId, string UsuarioId, string TicketFecha, string TicketHora, string TicketSubtotal0,
                                        string TicketSubtotal16, string TicketIva, string TicketTotal, string CorteZId)
        {
            CLSTicketCentral UdpArt = new CLSTicketCentral();
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.UsuarioId = Convert.ToInt32(UsuarioId);
            UdpArt.TicketFecha = TicketFecha;
            UdpArt.TicketHora = TicketHora;
            UdpArt.TicketSubtotal0 = Convert.ToDecimal(TicketSubtotal0);
            UdpArt.TicketSubtotal16 = Convert.ToDecimal(TicketSubtotal16);
            UdpArt.TicketIva = Convert.ToDecimal(TicketIva);
            UdpArt.TicketTotal = Convert.ToDecimal(TicketTotal);
            UdpArt.CorteZId = Convert.ToInt32(CorteZId);
            UdpArt.MtdActualizarTicket();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el TicketMayoreo [{0}] ", TicketId));
            }
        }
        /**** TicketArticulo*****/
        private void TicketArticulo(int Fila)
        {
            CLSTicketArticuloLocal SelArt = new CLSTicketArticuloLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarTicketArticulo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "TicketArticulo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaTicketArticulo(SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                            SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloUltimoIde"].ToString(),
                                            SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                            SelArt.Datos.Rows[i]["TarifaId"].ToString(),
                                            SelArt.Datos.Rows[i]["MedidasId"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloCosto"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloPrecio"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloCantidad"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloCantidadDevolucion"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloCantidadCancelada"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloSubtotal"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloIva"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloTotalLinea"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloDescuento"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloPrecioDescuento"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloIvaDescuento"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketArticuloTotal"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores TicketArticulo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla TicketArticulo.");
            }
        }
        private void SincronizaTicketArticulo(string TicketId, string CajaId, string TicketArticuloUltimoIde, string ArticuloCodigo,
            string TarifaId, string MedidasId, string TicketArticuloCosto, string TicketArticuloPrecio, string TicketArticuloCantidad,
            string TicketArticuloCantidadDevolucion, string TicketArticuloCantidadCancelada, string TicketArticuloSubtotal, 
            string TicketArticuloIva, string TicketArticuloTotalLinea, string TicketArticuloDescuento, string TicketArticuloPrecioDescuento,
            string TicketArticuloIvaDescuento, string TicketArticuloTotal)
        {

            CLSTicketArticuloCentral UdpArt = new CLSTicketArticuloCentral();
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketArticuloUltimoIde = Convert.ToInt32(TicketArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.TarifaId = Convert.ToInt32(TarifaId);
            UdpArt.MedidasId = Convert.ToInt32(MedidasId);
            UdpArt.TicketArticuloCosto = Convert.ToDecimal(TicketArticuloCosto);
            UdpArt.TicketArticuloPrecio = Convert.ToDecimal(TicketArticuloPrecio);
            UdpArt.TicketArticuloCantidad = Convert.ToInt32(TicketArticuloCantidad);
            UdpArt.TicketArticuloCantidadDevolucion = Convert.ToInt32(TicketArticuloCantidadDevolucion);
            UdpArt.TicketArticuloCantidadCancelada = Convert.ToInt32(TicketArticuloCantidadCancelada);
            UdpArt.TicketArticuloSubtotal = Convert.ToDecimal(TicketArticuloSubtotal);
            UdpArt.TicketArticuloIva = Convert.ToDecimal(TicketArticuloIva);
            UdpArt.TicketArticuloTotalLinea = Convert.ToDecimal(TicketArticuloTotalLinea);
            UdpArt.TicketArticuloDescuento = Convert.ToDecimal(TicketArticuloDescuento);
            UdpArt.TicketArticuloPrecioDescuento = Convert.ToDecimal(TicketArticuloPrecioDescuento);
            UdpArt.TicketArticuloIvaDescuento = Convert.ToDecimal(TicketArticuloIvaDescuento);
            UdpArt.TicketArticuloTotal = Convert.ToDecimal(TicketArticuloTotal);

            UdpArt.MtdActualizarTicketArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Ticket Articulo [{0}] ", TicketId));
            }
        }
        /**** TicketMayoreo*****/
        private void TicketMayoreo(int Fila)
        {
            CLSTicketMayoreoLocal SelArt = new CLSTicketMayoreoLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarTicketMayoreo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "TicketMayoreo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaTicketMayoreo(SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                            SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                            SelArt.Datos.Rows[i]["UsuarioId"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketFecha"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketSubtotal0"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketSubtotal16"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketIva"].ToString(),
                                            SelArt.Datos.Rows[i]["TicketTotal"].ToString(),
                                            SelArt.Datos.Rows[i]["ClienteId"].ToString());

                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores TicketMayoreo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla TicketMayoreo.");
            }
        }
        private void SincronizaTicketMayoreo(string TicketId, string CajaId, string UsuarioId, string TicketFecha, string TicketSubtotal0,
                                            string TicketSubtotal16, string TicketIva, string TicketTotal, string ClienteId)
        {

            CLSTicketMayoreoCentral UdpArt = new CLSTicketMayoreoCentral();
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.UsuarioId = Convert.ToInt32(UsuarioId);
            UdpArt.TicketFecha = TicketFecha;
            UdpArt.TicketSubtotal0 = Convert.ToDecimal(TicketSubtotal0);
            UdpArt.TicketSubtotal16 = Convert.ToDecimal(TicketSubtotal16);
            UdpArt.TicketIva = Convert.ToDecimal(TicketIva);
            UdpArt.TicketTotal = Convert.ToDecimal(TicketTotal);
            UdpArt.ClienteId = Convert.ToInt32(ClienteId);
            UdpArt.MtdActualizarTicketMayoreo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el TicketMayoreo [{0}] ", TicketId));
            }
        }
        /**** TicketMayoreoArticulo*****/
        private void TicketMayoreoArticulo(int Fila)
        {
            CLSTicketMayoreoArticuloLocal SelArt = new CLSTicketMayoreoArticuloLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarTicketMayoreoArticulo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "TicketMayoreoArticulo [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaTicketMayoreoArticulo(SelArt.Datos.Rows[i]["TicketId"].ToString(),
                                                    SelArt.Datos.Rows[i]["CajaId"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloUltimoIde"].ToString(),
                                                    SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(),
                                                    SelArt.Datos.Rows[i]["TarifaId"].ToString(),
                                                    SelArt.Datos.Rows[i]["MedidasId"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloCosto"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloPrecio"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloCantidad"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloCantidadDevolucion"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloCantidadCancelada"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloSubtotal"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloIva"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloTotalLinea"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloDescuento"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloPrecioDescuento"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloIvaDescuento"].ToString(),
                                                    SelArt.Datos.Rows[i]["TicketArticuloTotal"].ToString());


                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores TicketMayoreoArticulo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla TicketMayoreoArticulo.");
            }
        }
        private void SincronizaTicketMayoreoArticulo(string TicketId, string CajaId, string TicketArticuloUltimoIde, string ArticuloCodigo, string TarifaId,
                                                    string MedidasId, string TicketArticuloCosto, string TicketArticuloPrecio, string TicketArticuloCantidad,
                                                    string TicketArticuloCantidadDevolucion, string TicketArticuloCantidadCancelada, string TicketArticuloSubtotal,
                                                    string TicketArticuloIva, string TicketArticuloTotalLinea, string TicketArticuloDescuento, string TicketArticuloPrecioDescuento,
                                                    string TicketArticuloIvaDescuento, string TicketArticuloTotal)
        {
            CLSTicketMayoreoArticuloCentral UdpArt = new CLSTicketMayoreoArticuloCentral();
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketArticuloUltimoIde = Convert.ToInt32(TicketArticuloUltimoIde);
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.TarifaId = Convert.ToInt32(TarifaId);
            UdpArt.MedidasId = Convert.ToInt32(MedidasId);
            UdpArt.TicketArticuloCosto = Convert.ToDecimal(TicketArticuloCosto);
            UdpArt.TicketArticuloPrecio = Convert.ToDecimal(TicketArticuloPrecio);
            UdpArt.TicketArticuloCantidad = Convert.ToInt32(TicketArticuloCantidad);
            UdpArt.TicketArticuloCantidadDevolucion = Convert.ToInt32(TicketArticuloCantidadDevolucion);
            UdpArt.TicketArticuloCantidadCancelada = Convert.ToInt32(TicketArticuloCantidadCancelada);
            UdpArt.TicketArticuloSubtotal = Convert.ToDecimal(TicketArticuloSubtotal);
            UdpArt.TicketArticuloIva = Convert.ToDecimal(TicketArticuloIva);
            UdpArt.TicketArticuloTotalLinea = Convert.ToDecimal(TicketArticuloTotalLinea);
            UdpArt.TicketArticuloDescuento = Convert.ToDecimal(TicketArticuloDescuento);
            UdpArt.TicketArticuloPrecioDescuento = Convert.ToDecimal(TicketArticuloPrecioDescuento);
            UdpArt.TicketArticuloIvaDescuento = Convert.ToDecimal(TicketArticuloIvaDescuento);
            UdpArt.TicketArticuloTotal = Convert.ToDecimal(TicketArticuloTotal);


            UdpArt.MtdActualizarTicketMayoreoArticulo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine(string.Format("No se logro actualizar el Ticket Mayoreo-Articulo [{0}] ", TicketId));
            }
        }
    }
}