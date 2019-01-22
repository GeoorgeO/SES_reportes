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
using DevExpress.XtraSplashScreen;

namespace BSC_Sincronizacion
{
    public partial class Frm_Sincronizar : DevExpress.XtraEditors.XtraForm
    {
        public int ArticulosActualizados { get; set; }
        public int ArticulosError { get; set; }
        public int IdFolio { get; private set; }

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
        public void MensajeCargando(int opcion)
        {
            if (opcion == 1)
            {
                SplashScreenManager.ShowForm(this, typeof(Frm_CargandoConsulta), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Procesando...");
                SplashScreenManager.Default.SetWaitFormDescription("Espere por favor...");
            }
            else
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
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
            GValCatalogos.Columns[0].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[2].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[3].OptionsColumn.AllowEdit = false;
            GValCatalogos.Columns[4].OptionsColumn.AllowEdit = false;
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
                        case "Articulo":
                            AplicaCambiosArticulo(xRow);
                            break;
                        case "ArticuloMedidas":
                            AplicaCambiosArticuloMedidas(xRow);
                            break;
                        case "ArticuloProveedores":
                            AplicaCambiosArticuloProveedores(xRow);
                            break;
                        case "Caja":
                            AplicaCambiosCaja(xRow);
                            break;
                        case "Cliente":
                            AplicaCambiosCliente(xRow);
                            break;
                        case "CCliente":
                            AplicaCambiosCCliente(xRow);
                            break;
                        case "ComprasSugeridas":

                            break;
                        case "CondicionesPagos":
                            AplicaCambiosCondicionesPagos(xRow);
                            break;
                        case "CProveedor":
                            AplicaCambiosCProveedor(xRow);
                            break;
                        case "Documentos":

                            break;
                        case "EntradaMercanciaTipo":
                            AplicaCambiosEntradaMercanciaTipo(xRow);
                            break;
                        case "Familia":
                            AplicaCambiosFamilia(xRow);
                            break;
                        case "FormasdePago":
                            AplicaCambiosFormasdePago(xRow);
                            break;
                        case "Iva":
                            AplicaCambiosIva(xRow);
                            break;
                        case "Localidad":
                            AplicaCambiosLocalidad(xRow);
                            break;
                        case "Medidas":
                             AplicaCambiosMedidas(xRow);
                            break;
                        case "MetodoPagos":
                            AplicaCambiosMetodoPagos(xRow);
                            break;
                        case "Moneda":
                            AplicaCambiosMoneda(xRow);
                            break;
                        case "Proveedor":
                            AplicaCambiosProveedor(xRow);
                            break;
                        case "Roles":
                            AplicaCambiosRoles(xRow);
                            break;
                        case "SalidaMercanciaTipo":
                            AplicaCambiosSalidaMercanciaTipo(xRow);
                            break;
                        case "Sucursales":
                            AplicaCambiosSucursales(xRow);
                            break;
                        case "Tarifa":
                            AplicaCambiosTarifa(xRow);
                            break;
                        case "Usuarios":
                            AplicaCambiosUsuarios(xRow);
                            break;
                        case "Vendedor":
                            AplicaCambiosVendedor(xRow);
                            break;
                    }
                }
            }
            limpiarFormulario();
            escritura.Close();
            MessageBox.Show("El proceso Finalizo correctamente.", "Información", MessageBoxButtons.OK,MessageBoxIcon.Information);
            return Cadena;
        }
        /******* Articulos *****/
        private void AplicaCambiosArticulo(int Fila)
        {
            CLSArticulosLocal SelArt = new CLSArticulosLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();

            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticulos();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo Articulo [" + SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString().Trim() + "]";
                    SincronizaArticulos(SelArt.Datos.Rows[i]["ArticuloCodigo"].ToString(), SelArt.Datos.Rows[i]["ArticuloDescripcion"].ToString(),
                                        SelArt.Datos.Rows[i]["ArticuloCostoReposicion"].ToString(), SelArt.Datos.Rows[i]["FamiliaId"].ToString());
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
        private void SincronizaArticulos(string Codigo, string Descripcion, string CostoReposicion,string FamiliaId)
        {
            CLS_Articulo_Central UdpArt = new CLS_Articulo_Central();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.ArticuloDescripcion = Descripcion;
            UdpArt.ArticuloCostoReposicion = Convert.ToDecimal(CostoReposicion);
            UdpArt.FamiliaId = Convert.ToInt32(FamiliaId);
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
        /******* ArticulosMedidas *****/
        private void AplicaCambiosArticuloMedidas(int Fila)
        {
            CLSArticuloMedidasLocal SelArt = new CLSArticuloMedidasLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticuloMedidas();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo Articulo - Medidas [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaArticulosMedidas(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString());
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores ArticulosMedidas.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                    
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }

            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla ArticulosMedidas.");
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
            else
            {
                escritura.WriteLine("No se logro actualizar el ArticulosMedidas [" + Codigo + "] MedidaId=" + MedidaId);
                ArticulosError++;
            }
        }

        /******* ArticuloProveedores *****/
        private void AplicaCambiosArticuloProveedores(int Fila)
        {
            CLSArticuloProveedoresLocal SelArt = new CLSArticuloProveedoresLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarArticuloProveedores();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo ArticuloProveedores [" + SelArt.Datos.Rows[i][0].ToString().Trim() + "]";
                    SincronizaArticuloProveedores(SelArt.Datos.Rows[i][0].ToString(),
                                        SelArt.Datos.Rows[i][1].ToString(),
                                        SelArt.Datos.Rows[i][2].ToString(),
                                        SelArt.Datos.Rows[i][3].ToString());
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores ArticuloProveedores.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla ArticuloProveedores.");
            }

        }
        private void SincronizaArticuloProveedores(string ArticuloCodigo, string ArticuloProveedoresIde, string ProveedorId, string ArticuloProveedoresFechaUdp)
        {
            CLS_ArticuloProveedores_Central UdpArt = new CLS_ArticuloProveedores_Central();
            UdpArt.ArticuloCodigo = ArticuloCodigo;
            UdpArt.ArticuloProveedoresIde = Convert.ToInt32(ArticuloProveedoresIde);
            UdpArt.ProveedorId = Convert.ToInt32(ProveedorId);
            DateTime Fecha = Convert.ToDateTime(ArticuloProveedoresFechaUdp);
            UdpArt.ArticuloProveedoresFechaUdp = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            UdpArt.MtdActualizarArticuloProveedores();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                escritura.WriteLine("No se logro actualizar el Articulo Proveedores [" + ArticuloCodigo + "] " + ArticuloProveedoresIde);
            }
        }


        /******* Caja *****/
        private void AplicaCambiosCaja(int Fila)
        {
            CLSCajaLocal SelArt = new CLSCajaLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCaja();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                   
                    lEstatus.Text = "Codigo Caja [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCaja(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString(), SelArt.Datos.Rows[i][6].ToString(), SelArt.Datos.Rows[i][7].ToString(),
                        SelArt.Datos.Rows[i][8].ToString(), Convert.ToDateTime( SelArt.Datos.Rows[i][9]), SelArt.Datos.Rows[i][10].ToString(), SelArt.Datos.Rows[i][11].ToString(),
                        SelArt.Datos.Rows[i][12].ToString(), SelArt.Datos.Rows[i][13].ToString(), SelArt.Datos.Rows[i][14].ToString(), SelArt.Datos.Rows[i][15].ToString(),
                        SelArt.Datos.Rows[i][16].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Caja.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Caja.");
            }
        }
        private void SincronizaCaja(string CajaId, string SucursalesId, string CajaNumero, string CajaDescripcion, string CajaReciboInicial, string CajaFondo, string CajaMontoEfectivo,
            string CajaMontoTarjeta, string CajaMontoVale, DateTime CajaFecha, string CajaUltimoTicket, string CajaUltimaDevolucion, string CajaUltimaCancelacion,
            string CajaUltimoCorte, string CajaUltimoRetiro, string CajaUltimoTicketMayoreo, string CajaUltimoDevolucionMayoreo)
        {
            CLS_Caja_Central UdpArt = new CLS_Caja_Central();



            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.CajaNumero = Convert.ToInt32(CajaNumero);
            UdpArt.CajaDescripcion = CajaDescripcion;
            UdpArt.CajaReciboInicial = Convert.ToInt32(CajaReciboInicial);
            UdpArt.CajaFondo = Convert.ToDecimal(CajaFondo);
            UdpArt.CajaMontoEfectivo = Convert.ToDecimal(CajaMontoEfectivo);
            UdpArt.CajaMontoTarjeta = Convert.ToDecimal(CajaMontoTarjeta);
            UdpArt.CajaMontoVale = Convert.ToDecimal(CajaMontoVale);
            UdpArt.CajaFecha = CajaFecha.Date.Year.ToString() + DosCero(CajaFecha.Date.Month.ToString()) + DosCero(CajaFecha.Date.Day.ToString());            
            UdpArt.CajaUltimoTicket = Convert.ToInt32(CajaUltimoTicket);
            UdpArt.CajaUltimaDevolucion = Convert.ToInt32(CajaUltimaDevolucion);
            UdpArt.CajaUltimaCancelacion = Convert.ToInt32(CajaUltimaCancelacion);
            UdpArt.CajaUltimoCorte = Convert.ToInt32(CajaUltimoCorte);
            UdpArt.CajaUltimoRetiro = Convert.ToInt32(CajaUltimoRetiro);
            UdpArt.CajaUltimoTicketMayoreo = Convert.ToInt32(CajaUltimoTicketMayoreo);
            UdpArt.CajaUltimoDevolucionMayoreo = Convert.ToInt32(CajaUltimoDevolucionMayoreo);
           

            UdpArt.MtdActualizarCaja();

            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la caja [" + CajaId + "]"+ CajaDescripcion);
                ArticulosError++;
            }
        }
        /******* CCliente *****/
        private void AplicaCambiosCCliente(int Fila)
        {
            CLSCClienteLocal SelArt = new CLSCClienteLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCCliente();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                   
                    lEstatus.Text = "Codigo CCliente [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCCliente(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores CCliente.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla CCliente.");
            }
        }
        private void SincronizaCCliente(string CClienteId, string CClienteNombre, DateTime CClienteFecha, String CClienteActivo, string CClientePadreId, string CClienteTieneElementos)
        {
            CLS_CCliente_Central UdpArt = new CLS_CCliente_Central();


            UdpArt.CClienteId = Convert.ToInt32(CClienteId);
            UdpArt.CClienteNombre = CClienteNombre;
            UdpArt.CClienteFecha = CClienteFecha.Date.Year.ToString() + DosCero(CClienteFecha.Date.Month.ToString()) + DosCero(CClienteFecha.Date.Day.ToString());  
            UdpArt.CClienteActivo = CClienteActivo;
            if (CClientePadreId != String.Empty)
            {
                UdpArt.CClientePadreId = Convert.ToInt32(CClientePadreId);
            }
            else
            {
                UdpArt.CClientePadreId = 0;
            }
            if (Convert.ToBoolean( CClienteTieneElementos)==false) {
                UdpArt.CClienteTieneElementos = 0;
            }
            else
            {
                UdpArt.CClienteTieneElementos = 1;
            }
            
            


            UdpArt.MtdActualizarCCliente();

            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la CCliente [" + CClienteId + "]" + CClienteNombre);
                ArticulosError++;
            }
        }
        /******* Cliente *****/
        private void AplicaCambiosCliente(int Fila)
        {
            CLSClienteLocal SelArt = new CLSClienteLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCliente();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo Cliente [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCliente(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString(), SelArt.Datos.Rows[i][6].ToString(), SelArt.Datos.Rows[i][7].ToString(),
                        SelArt.Datos.Rows[i][8].ToString(), SelArt.Datos.Rows[i][9].ToString(), SelArt.Datos.Rows[i][10].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][11]),
                        SelArt.Datos.Rows[i][12].ToString(), SelArt.Datos.Rows[i][13].ToString(), SelArt.Datos.Rows[i][14].ToString(), SelArt.Datos.Rows[i][15].ToString(),
                        SelArt.Datos.Rows[i][16].ToString(), SelArt.Datos.Rows[i][17].ToString(), SelArt.Datos.Rows[i][18].ToString(), Convert.ToInt32(SelArt.Datos.Rows[i][19]),
                        Convert.ToInt32(SelArt.Datos.Rows[i][20]), SelArt.Datos.Rows[i][21].ToString(), SelArt.Datos.Rows[i][22].ToString(), SelArt.Datos.Rows[i][23].ToString(),
                        SelArt.Datos.Rows[i][24].ToString(), Convert.ToBoolean(SelArt.Datos.Rows[i][25]), SelArt.Datos.Rows[i][26].ToString(), SelArt.Datos.Rows[i][27].ToString(),
                        SelArt.Datos.Rows[i][28].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Cliente.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Cliente.");
            }
        }
        private void SincronizaCliente(string ClienteId, string ClienteNombre, DateTime ClienteFecha, string ClientePaterno, string ClienteMaterno, string ClienteRfc, string ClienteCalle,
            string ClienteNInterior, string ClienteNExterior, string ClienteColonia, string LocalidadId, DateTime ClienteFechaActualizacion, string ClienteTelefono1,
            string ClienteTelefono2, string ClienteTelefono3, string ClienteEmail, string ClienteEmailFiscal, string ClienteTipoPersona, string ClienteActivo, int CClienteId,
            int ClienteImpresion, string ClienteLimiteCredito, string ClienteSobregiro, string VendedorId, string CondicionesPagosId, Boolean ClienteTieneCredito,
            string ClienteDescuento, string ClienteObservaciones, string ClienteSaldoActual)
        {
            CLS_Cliente_Central UdpArt = new CLS_Cliente_Central();



            UdpArt.ClienteId = Convert.ToInt32(ClienteId);
            UdpArt.ClienteNombre = ClienteNombre;
            UdpArt.ClienteFecha = ClienteFecha.Date.Year.ToString() + DosCero(ClienteFecha.Date.Month.ToString()) + DosCero(ClienteFecha.Date.Day.ToString());
            UdpArt.ClientePaterno = ClientePaterno;
            UdpArt.ClienteMaterno = ClienteMaterno;
            UdpArt.ClienteRfc = ClienteRfc;
            UdpArt.ClienteCalle = ClienteCalle;
            UdpArt.ClienteNInterior = ClienteNInterior;
            UdpArt.ClienteNExterior = ClienteNExterior;
            UdpArt.ClienteColonia = ClienteColonia;
            if (LocalidadId==string.Empty)
            {
                UdpArt.LocalidadId = 0;
            }
            else
            {
                UdpArt.LocalidadId = Convert.ToInt32(LocalidadId);
            }
            
            UdpArt.ClienteFechaActualizacion = ClienteFechaActualizacion.Date.Year.ToString() + DosCero(ClienteFechaActualizacion.Date.Month.ToString()) + DosCero(ClienteFechaActualizacion.Date.Day.ToString());
            UdpArt.ClienteTelefono1 = ClienteTelefono1;
            UdpArt.ClienteTelefono2 = ClienteTelefono2;
            UdpArt.ClienteTelefono3 = ClienteTelefono3;
            UdpArt.ClienteEmail = ClienteEmail;
            UdpArt.ClienteEmailFiscal = ClienteEmailFiscal;
            UdpArt.ClienteTipoPersona = ClienteTipoPersona;
            UdpArt.ClienteActivo = ClienteActivo;
            UdpArt.CClienteId = CClienteId;
            UdpArt.ClienteImpresion = ClienteImpresion;
            if (ClienteLimiteCredito == string.Empty)
            {
                UdpArt.ClienteLimiteCredito = 0;
            }
            else
            {
                UdpArt.ClienteLimiteCredito = Convert.ToDecimal(ClienteLimiteCredito);
            }
            if (ClienteSobregiro==string.Empty)
            {
                UdpArt.ClienteSobregiro = 0;
            }
            else
            {
                UdpArt.ClienteSobregiro = Convert.ToDecimal(ClienteSobregiro);
            }
            
            UdpArt.VendedorId = Convert.ToInt32(VendedorId);
            UdpArt.CondicionesPagosId = Convert.ToInt32(CondicionesPagosId);
            if (ClienteTieneCredito == false)
            {
                UdpArt.ClienteTieneCredito = 0;
            }
            else
            {
                UdpArt.ClienteTieneCredito = 1;
            }
            
            UdpArt.ClienteDescuento = Convert.ToDecimal(ClienteDescuento);
            UdpArt.ClienteObservaciones = ClienteObservaciones;
            if (ClienteSaldoActual==string.Empty)
            {
                UdpArt.ClienteSaldoActual = 0;
            }
            else
            {
                UdpArt.ClienteSaldoActual = Convert.ToDecimal(ClienteSaldoActual);
            }
            

            UdpArt.MtdActualizarCliente();

            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la CCliente [" + ClienteId + "]" + ClienteNombre);
                ArticulosError++;
            }
        }
        /******* CondicionesPagos *****/
        private void AplicaCambiosCondicionesPagos(int Fila)
        {
            CLSCondicionesPagosLocal SelArt = new CLSCondicionesPagosLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCondicionesPagos();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo CondicionesPagos [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCondicionesPagos(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), Convert.ToBoolean(SelArt.Datos.Rows[i][3]),
                        Convert.ToDateTime( SelArt.Datos.Rows[i][4]), SelArt.Datos.Rows[i][5].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores CondicionesPagos.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla CondicionesPagos.");
            }
        }
        private void SincronizaCondicionesPagos(string CondicionesPagosId, string CondicionesPagosNombre, string CondicionesPagosCantidad, Boolean CondicionesPagosAfectacion, DateTime CondicionesPagosFecha, string CondicionesPagosActivo)
        {
            CLS_CondicionesPagos_Central UdpArt = new CLS_CondicionesPagos_Central();
            UdpArt.CondicionesPagosId = Convert.ToInt32(CondicionesPagosId);
            UdpArt.CondicionesPagosNombre = CondicionesPagosNombre;
            UdpArt.CondicionesPagosCantidad = Convert.ToInt32(CondicionesPagosCantidad);
            if (CondicionesPagosAfectacion==true)
            {
                UdpArt.CondicionesPagosAfectacion = 1;
            }
            else
            {
                UdpArt.CondicionesPagosAfectacion = 0;
            }
            
            UdpArt.CondicionesPagosFecha = CondicionesPagosFecha.Date.Year.ToString() + DosCero(CondicionesPagosFecha.Date.Month.ToString()) + DosCero(CondicionesPagosFecha.Date.Day.ToString()); 
            UdpArt.CondicionesPagosActivo = CondicionesPagosActivo;

            UdpArt.MtdActualizarCondicionesPagos();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la CondicionesPagos [" + CondicionesPagosId + "]" + CondicionesPagosNombre);
                ArticulosError++;
            }
        }
        /******* CProveedor *****/
        private void AplicaCambiosCProveedor(int Fila)
        {
            CLSCProveedorLocal SelArt = new CLSCProveedorLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarCProveedor();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo CProveedor [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCProveedor(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), Convert.ToBoolean(SelArt.Datos.Rows[i][5])
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);

                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores CProveedor.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla CProveedor.");
            }
        }
        private void SincronizaCProveedor(string CProveedorId, string CProveedorNombre, DateTime CProveedorFecha, string CProveedorActivo, string CProveedorPadreId, Boolean CProveedorTieneElementos)
        {
            CLS_CProveedor_Central UdpArt = new CLS_CProveedor_Central();
            UdpArt.CProveedorId = Convert.ToInt32(CProveedorId);
            UdpArt.CProveedorNombre = CProveedorNombre;
            UdpArt.CProveedorFecha = CProveedorFecha.Date.Year.ToString() + DosCero(CProveedorFecha.Date.Month.ToString()) + DosCero(CProveedorFecha.Date.Day.ToString());
            UdpArt.CProveedorActivo = CProveedorActivo;
            if (CProveedorPadreId == string.Empty)
            {
                UdpArt.CProveedorPadreId = 0;
            }
            else
            {
                UdpArt.CProveedorPadreId = Convert.ToInt32(CProveedorPadreId);
            }
            
            if (CProveedorTieneElementos==true)
            {
                UdpArt.CProveedorTieneElementos = 1;
            }
            else
            {
                UdpArt.CProveedorTieneElementos = 0;
            }

            UdpArt.MtdActualizarCProveedor();
            
            if (UdpArt.Exito.ToString() == "True" )
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la CProveedor [" + CProveedorId + "]" + CProveedorNombre);
                ArticulosError++;
            }
        }
        /******* EntradaMercanciaTipo *****/
        private void AplicaCambiosEntradaMercanciaTipo(int Fila)
        {
            CLSEntradaMercanciaTipoLocal SelArt = new CLSEntradaMercanciaTipoLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarEntradaMercanciaTipo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    
                    lEstatus.Text = "Codigo EntradaMercanciaTipo [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaEntradaMercanciaTipo(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores EntradaMercanciaTipo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla EntradaMercanciaTipo.");
            }
        }
        private void SincronizaEntradaMercanciaTipo(string EntradaMercanciaTipoId, string EntradaMercanciaTipoDescripcion)
        {
            CLS_EntradaMercanciaTipo_Central UdpArt = new CLS_EntradaMercanciaTipo_Central();
            UdpArt.EntradaMercanciaTipoId = Convert.ToInt32(EntradaMercanciaTipoId);
            UdpArt.EntradaMercanciaTipoDescripcion = EntradaMercanciaTipoDescripcion;
            

            UdpArt.MtdActualizarEntradaMercanciaTipo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la entreda mercancia tipo [" + EntradaMercanciaTipoId + "]" + EntradaMercanciaTipoDescripcion);
                ArticulosError++;
            }
        }
        /******* Familia *****/
        private void AplicaCambiosFamilia(int Fila)
        {
            CLSFamiliaLocal SelArt = new CLSFamiliaLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarFamilia();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Familia [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaFamilia(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString(), SelArt.Datos.Rows[i][6].ToString(), SelArt.Datos.Rows[i][7].ToString(),
                        SelArt.Datos.Rows[i][8].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Familia.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Familia.");
            }
        }
        private void SincronizaFamilia(string FamiliaId, string FamiliaNombre, DateTime FamiliaFecha, String FamiliaTipo, String FamiliaActivo, string FamiliaPadreId, string IvaId, string Espadre, string TieneArticulos)
        {
            CLS_Familia_central UdpArt = new CLS_Familia_central();
            UdpArt.FamiliaId = Convert.ToInt32(FamiliaId);
            UdpArt.FamiliaNombre = FamiliaNombre;
            UdpArt.FamiliaFecha = FamiliaFecha.Date.Year.ToString() + DosCero(FamiliaFecha.Date.Month.ToString()) + DosCero(FamiliaFecha.Date.Day.ToString()); 
            UdpArt.FamiliaTipo = FamiliaTipo;
            UdpArt.FamiliaActivo = FamiliaActivo;
            if (FamiliaPadreId==string.Empty)
            {
                UdpArt.FamiliaPadreId = 0;
            }
            else
            {
                UdpArt.FamiliaPadreId = Convert.ToInt32(FamiliaPadreId);
            }
            if (IvaId==string.Empty)
            {
                UdpArt.IvaId = 0;
            }
            else
            {
                UdpArt.IvaId = Convert.ToInt32(IvaId);
            }
            
            if (Convert.ToBoolean(Espadre) == true)
            {
                UdpArt.Espadre = 1;
            }
            else
            {
                UdpArt.Espadre = 0;
            }
            if (Convert.ToBoolean(TieneArticulos) == true)
            {
                UdpArt.TieneArticulos = 1;
            }
            else
            {
                UdpArt.TieneArticulos = 0;
            }

           

            UdpArt.MtdActualizarFamilia();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la Familia [" + FamiliaId + "]" + FamiliaNombre);
                ArticulosError++;
            }
        }
        /******* FormasdePago *****/
        private void AplicaCambiosFormasdePago(int Fila)
        {
            CLSFormasdePagoLocal SelArt = new CLSFormasdePagoLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarFormasdePago();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo FormasdePago [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaFormasdePago(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores FormasdePago.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else{
                escritura.WriteLine("No se obtubieron datos de la tabla FormasdePago.");
            }
        }
        private void SincronizaFormasdePago(string FormasdePagoId, string FormasdePagoDescripcion)
        {
            CLS_FormasdePago_Central UdpArt = new CLS_FormasdePago_Central();
            UdpArt.FormasdePagoId = Convert.ToInt32(FormasdePagoId);
            UdpArt.FormasdePagoDescripcion = FormasdePagoDescripcion;


            UdpArt.MtdActualizarFormasdePagoGeneral();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la Familia [" + FormasdePagoId + "]" + FormasdePagoDescripcion);
                ArticulosError++;
            }
        }
        /******* Iva *****/
        private void AplicaCambiosIva(int Fila)
        {
            CLSIvaLocal SelArt = new CLSIvaLocal();
            
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarIva();

            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Iva [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaIva(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Iva.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else{
                escritura.WriteLine("No se obtubieron datos de la tabla Iva.");
            }
        }
        private void SincronizaIva(string IvaId, string IvaNombre, string IvaFactor, string IvaPorcentaje)
        {
            CLS_Iva_Central UdpArt = new CLS_Iva_Central();
            UdpArt.IvaId = Convert.ToInt32(IvaId);
            UdpArt.IvaNombre = IvaNombre;
            UdpArt.IvaFactor = Convert.ToDecimal(IvaFactor);
            UdpArt.IvaPorcentaje = Convert.ToInt32(IvaPorcentaje);

            UdpArt.MtdActualizarIva();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la Familia [" + IvaId + "]" + IvaNombre);
                ArticulosError++;
            }
        }
        /******* Localidad *****/
        private void AplicaCambiosLocalidad(int Fila)
        {
            CLSLocalidadLocal SelArt = new CLSLocalidadLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarLocalidad();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Localidad [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaLocalidad(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Localidad.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else{
                escritura.WriteLine("No se obtubieron datos de la tabla Localidad.");
            }
        }
        private void SincronizaLocalidad(string LocalidadId, string LocalidadNombre, string LocalidadCP, string MunicipioId)
        {
            CLS_Localidad_Central UdpArt = new CLS_Localidad_Central();
            UdpArt.LocalidadId = Convert.ToInt32(LocalidadId);
            UdpArt.LocalidadNombre = LocalidadNombre;
            UdpArt.LocalidadCP = LocalidadCP;
            if (MunicipioId == string.Empty)
            {
                UdpArt.MunicipioId = 0;
            }
            else
            {
                UdpArt.MunicipioId = Convert.ToInt32(MunicipioId);
            }
            

            UdpArt.MtdActualizarLocalidad();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la Localidad [" + LocalidadId + "]" + LocalidadNombre);
                ArticulosError++;
            }
        }
        /******* Medidas *****/
        private void AplicaCambiosMedidas(int Fila)
        {
            CLSMedidasLocal SelArt = new CLSMedidasLocal();

            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarMedidas();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Medidas [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaMedidas(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Medidas.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Medidas.");
            }
        }
        private void SincronizaMedidas(string MedidasId, string MedidasNombre, string MedidasAlias)
        {
            CLS_Medidas_Central UdpArt = new CLS_Medidas_Central();
            UdpArt.MedidasId = Convert.ToInt32(MedidasId);
            UdpArt.MedidasNombre = MedidasNombre;
            UdpArt.MedidasAlias = MedidasAlias;
            


            UdpArt.MtdActualizarMedidas();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la Medida [" + MedidasId + "]" + MedidasNombre);
                ArticulosError++;
            }
        }
        /******* MetodoPagos *****/
        private void AplicaCambiosMetodoPagos(int Fila)
        {
            CLSMetodoPagosLocal SelArt = new CLSMetodoPagosLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarMetodoPagos();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Metodo pago [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaMetodoPagos(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][2].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Metodo pago.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla MetodoPagos.");
            }
        }
        private void SincronizaMetodoPagos(string MetodoPagosId, string MetodoPagosNombre, DateTime MetodoPagosFecha,string MetodoPagosActivo)
        {
            CLS_MetodoPagos_Central UdpArt = new CLS_MetodoPagos_Central();
            UdpArt.MetodoPagosId = Convert.ToInt32(MetodoPagosId);
            UdpArt.MetodoPagosNombre = MetodoPagosNombre;
            UdpArt.MetodoPagosFecha = MetodoPagosFecha.Date.Year.ToString() + DosCero(MetodoPagosFecha.Date.Month.ToString()) + DosCero(MetodoPagosFecha.Date.Day.ToString()); 
            UdpArt.MetodoPagosActivo = MetodoPagosActivo;


            UdpArt.MtdActualizarMetodoPagos();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar el metodo pago [" + MetodoPagosId + "]" + MetodoPagosNombre);
                ArticulosError++;
            }
        }
        /******* Moneda *****/
        private void AplicaCambiosMoneda(int Fila)
        {
            CLSMonedaLocal SelArt = new CLSMonedaLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarMoneda();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Moneda [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaMoneda(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString(), SelArt.Datos.Rows[i][4].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Moneda.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Moneda.");
            }
        }
        private void SincronizaMoneda(string MonedaId, string MonedaNombre, string MonedaSimbolo, string MonedaActivo, string MonedaTipoCambio)
        {
            CLS_Moneda_Central UdpArt = new CLS_Moneda_Central();
            UdpArt.MonedaId = Convert.ToInt32(MonedaId);
            UdpArt.MonedaNombre = MonedaNombre;
            UdpArt.MonedaSimbolo = MonedaSimbolo;
            UdpArt.MonedaActivo = MonedaActivo;
            if (MonedaTipoCambio==string.Empty)
            {
                UdpArt.MonedaTipoCambio =0;
            }
            else
            {
                UdpArt.MonedaTipoCambio = Convert.ToDecimal(MonedaTipoCambio);
            }
            

            UdpArt.MtdActualizarMoneda();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la moneda [" + MonedaId + "]" + MonedaNombre);
                ArticulosError++;
            }
        }
        /******* Proveedor *****/
        private void AplicaCambiosProveedor(int Fila)
        {
            CLSProveedorLocal SelArt = new CLSProveedorLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarProveedor();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Proveedor [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaProveedor(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Proveedor.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Proveedor.");
            }
        }
        private void SincronizaProveedor(string ProveedorId, string ProveedorNombre, string ProveedorPaterno, string ProveedorMaterno)
        {
            CLS_Proveedor_Central UdpArt = new CLS_Proveedor_Central();
            UdpArt.ProveedorId = Convert.ToInt32(ProveedorId);
            UdpArt.ProveedorNombre = ProveedorNombre;
            UdpArt.ProveedorPaterno = ProveedorPaterno;
            UdpArt.ProveedorMaterno = ProveedorMaterno;


            UdpArt.MtdActualizarProveedor();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar el proveedor [" + ProveedorId + "]" + ProveedorNombre);
                ArticulosError++;
            }
        }
        /******* Roles *****/
        private void AplicaCambiosRoles(int Fila)
        {
            CLSRolesLocal SelArt = new CLSRolesLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarRoles();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Rol [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaRoles(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][3])
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Roles.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Roles.");
            }
        }
        private void SincronizaRoles(string RolesId, string RolesNombre, string RolesActivo, DateTime RolesFecha)
        {
            CLS_Roles_Central UdpArt = new CLS_Roles_Central();
            UdpArt.RolesId = Convert.ToInt32(RolesId);
            UdpArt.RolesNombre = RolesNombre;
            UdpArt.RolesActivo = RolesActivo;
            UdpArt.RolesFecha = RolesFecha.Date.Year.ToString() + DosCero(RolesFecha.Date.Month.ToString()) + DosCero(RolesFecha.Date.Day.ToString());  


            UdpArt.MtdActualizarRoles();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar el Rol [" + RolesId + "]" + RolesNombre);
                ArticulosError++;
            }
        }
        /******* SalidaMercanciaTipo *****/
        private void AplicaCambiosSalidaMercanciaTipo(int Fila)
        {
            CLSSalidaMercanciaTipoLocal SelArt = new CLSSalidaMercanciaTipoLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.MtdSeleccionarSalidaMercanciaTipo();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo SalidaMercanciaTipo [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaSalidaMercanciaTipo(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores SalidaMercanciaTipo.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla SalidaMercanciaTipo.");
            }
        }
        private void SincronizaSalidaMercanciaTipo(string SalidaMercanciaTipoId, string SalidaMercanciaTipoDescripcion)
        {
            CLS_SalidaMercanciaTipo_Central UdpArt = new CLS_SalidaMercanciaTipo_Central();
            UdpArt.SalidaMercanciaTipoId = Convert.ToInt32(SalidaMercanciaTipoId);
            UdpArt.SalidaMercanciaTipoDescripcion = SalidaMercanciaTipoDescripcion;
            


            UdpArt.MtdActualizarSalidaMercanciaTipo();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la salida mercancia tipo [" + SalidaMercanciaTipoId + "]" + SalidaMercanciaTipoDescripcion);
                ArticulosError++;
            }
        }
        /******* Sucursales *****/
        private void AplicaCambiosSucursales(int Fila)
        {
            CLSSucursalesLocal SelArt = new CLSSucursalesLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarSucursales();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Sucursales [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaSucursales(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString(), SelArt.Datos.Rows[i][6].ToString(), SelArt.Datos.Rows[i][7].ToString(),
                        SelArt.Datos.Rows[i][8].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Sucursales.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Sucursales.");
            }
        }
        private void SincronizaSucursales(string SucursalesId, string SucursalesNombre,DateTime SucursalesFecha, string SucursalesActivo, string SucursalesCalle, string SucursalesNInterior, 
            string SucursalesnNExterior, string SucursalesColonia,string LocalidadId)
        {
            CLS_Sucursales_Central UdpArt = new CLS_Sucursales_Central();
            UdpArt.SucursalesId = Convert.ToInt32(SucursalesId);
            UdpArt.SucursalesNombre = SucursalesNombre;
            UdpArt.SucursalesFecha = SucursalesFecha.Date.Year.ToString() + DosCero(SucursalesFecha.Date.Month.ToString()) + DosCero(SucursalesFecha.Date.Day.ToString()); 
            UdpArt.SucursalesActivo = SucursalesActivo;
            UdpArt.SucursalesCalle = SucursalesCalle;
            UdpArt.SucursalesNInterior = SucursalesNInterior;
            UdpArt.SucursalesnNExterior = SucursalesnNExterior;
            UdpArt.SucursalesColonia = SucursalesColonia;
            if (LocalidadId==string.Empty)
            {
                UdpArt.LocalidadId = 0;
            }
            else
            {
                UdpArt.LocalidadId = Convert.ToInt32(LocalidadId);
            }
            
            


            UdpArt.MtdActualizarSucursales();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la sucursal [" + SucursalesId + "]" + SucursalesNombre);
                ArticulosError++;
            }
        }
        /******* Tarifa *****/
        private void AplicaCambiosTarifa(int Fila)
        {
            CLSTarifaLocal SelArt = new CLSTarifaLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarTarifa();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Tarifa [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaTarifa(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Tarifa.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Tarifa.");
            }
        }
        private void SincronizaTarifa(string TarifaId, string TarifaNombre, DateTime TarifaFecha, string TarifaActivo)
        {
            CLS_Tarifa_Central UdpArt = new CLS_Tarifa_Central();
            UdpArt.TarifaId = Convert.ToInt32(TarifaId);
            UdpArt.TarifaNombre = TarifaNombre;
            UdpArt.TarifaFecha = TarifaFecha.Date.Year.ToString() + DosCero(TarifaFecha.Date.Month.ToString()) + DosCero(TarifaFecha.Date.Day.ToString()); ;
            UdpArt.TarifaActivo = TarifaActivo;


            UdpArt.MtdActualizarTarifa();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar la tarifa [" + TarifaId + "]" + TarifaNombre);
                ArticulosError++;
            }
        }
        /******* Usuarios *****/
        private void AplicaCambiosUsuarios(int Fila)
        {
            CLSUsuariosLocal SelArt = new CLSUsuariosLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();

            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarUsuarios();
          
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Usuario [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaUsuarios(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][2]), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString(), SelArt.Datos.Rows[i][5].ToString(), SelArt.Datos.Rows[i][6].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Usuarios.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Usuarios.");
            }
        }
        private void SincronizaUsuarios(string UsuariosId, string UsuariosNombre, DateTime UsuariosRegistroFecha, string UsuariosLogin,string UsuariosPassword,string UsuariosActivo,string RolesId)
        {
            CLS_Usuarios_Central UdpArt = new CLS_Usuarios_Central();
            UdpArt.UsuariosId = Convert.ToInt32(UsuariosId);
            UdpArt.UsuariosNombre = UsuariosNombre;
            UdpArt.UsuariosRegistroFecha = UsuariosRegistroFecha.Date.Year.ToString() + DosCero(UsuariosRegistroFecha.Date.Month.ToString()) + DosCero(UsuariosRegistroFecha.Date.Day.ToString()); 
            UdpArt.UsuariosLogin = UsuariosLogin;
            UdpArt.UsuariosPassword = UsuariosPassword;
            UdpArt.UsuariosActivo = UsuariosActivo;
            if (RolesId==string.Empty)
            {
                UdpArt.RolesId = 0;
            }
            else
            {
                UdpArt.RolesId = Convert.ToInt32(RolesId);
            }
            

            UdpArt.MtdActualizarUsuarios();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar el usuario [" + UsuariosId + "]" + UsuariosNombre);
                ArticulosError++;
            }
        }
        /******* Vendedor *****/
        private void AplicaCambiosVendedor(int Fila)
        {
            CLSVendedorLocal SelArt = new CLSVendedorLocal();
            lEstatus.Text = "Recolectando datos";
            Application.DoEvents();
            SelArt.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCero(dtFechaInicio.DateTime.Month.ToString()) + DosCero(dtFechaInicio.DateTime.Day.ToString());
            SelArt.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCero(dtFechaFin.DateTime.Month.ToString()) + DosCero(dtFechaFin.DateTime.Day.ToString());
            SelArt.MtdSeleccionarVendedor();
            if (SelArt.Exito == true)
            {
                ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();

                    lEstatus.Text = "Codigo Vendedor [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaVendedor(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(), SelArt.Datos.Rows[i][3].ToString(),
                        SelArt.Datos.Rows[i][4].ToString()
                        );
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    escritura.WriteLine("Finalizo sin errores Vendedor.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Sincronizacion Correcta");
                }
                else
                {
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                escritura.WriteLine("No se obtubieron datos de la tabla Vendedor.");
            }
        }
        private void SincronizaVendedor(string VendedorId, string VendedorNombre,  string VendedorApellidos, string VendedorActivo, string VendedorNombreCompleto)
        {
            CLS_Vendedor_Central UdpArt = new CLS_Vendedor_Central();
            UdpArt.VendedorId = Convert.ToInt32(VendedorId);
            UdpArt.VendedorNombre = VendedorNombre;
            
            UdpArt.VendedorApellidos = VendedorApellidos;
            UdpArt.VendedorActivo = VendedorActivo;
            UdpArt.VendedorNombreCompleto = VendedorNombreCompleto;
            


            UdpArt.MtdActualizarVendedor();
            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                escritura.WriteLine("No se logro actualizar el Vendedor [" + VendedorId + "]" + VendedorNombre);
                ArticulosError++;
            }
        }

        private void btn_CierreVentas_Click(object sender, EventArgs e)
        {
            MensajeCargando(1);
            InsertarServer();
        }

        private void InsertarServer()
        {
            DateTime FechaActual = DateTime.Now;
            CLSVentasAcumuladas ins = new CLSVentasAcumuladas();
            if(rdbCoincide.SelectedIndex==0)
            {
                ins.opcion = 1;
            }
            else
            {
                ins.opcion = 2;
            }
            ins.fecha = string.Format("{0}{1}{2} 00:00:00", FechaActual.Year, DosCero(FechaActual.Month.ToString()), DosCero(FechaActual.Day.ToString()));
            ins.MtdInsertarVentaAcumulada();
            if (ins.Exito == true)
            {
                MensajeCargando(2);
                XtraMessageBox.Show("Proceso Completado con Exito");
            }
            else
            {
                MensajeCargando(2);
                XtraMessageBox.Show("No se puedo insertar venta local");
            }
        }
    }
}