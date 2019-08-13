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
using DevExpress.XtraSplashScreen;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace BSC_Inventarios
{
    public partial class Frm_Inventario_Ciego : DevExpress.XtraEditors.XtraForm
    {
        public int Rotacion { get; private set; }
        public int Periodo { get; private set; }
        public int ArticuloInventario { get; private set; }
        public int ArticulosActivos { get; private set; }
        public int ArticuloDiarios { get; private set; }
        public bool Valido { get; private set; }
        public int alea { get; private set; }
        public int v_Sucursalnum { get; private set; }
        public int FoliosEnviados { get; private set; }
        public bool GeneraFolios { get; private set; }
        public string UsuariosLogin { get; set; }
        int[] valores;
        private static Frm_Inventario_Ciego m_FormDefInstance;
        public static Frm_Inventario_Ciego DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Inventario_Ciego();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public int CodigoAleatorios { get; private set; }

        public Frm_Inventario_Ciego()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Numero";
            column.AutoIncrement = false;
            column.Caption = "Num";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "ArticuloCodigo";
            column.AutoIncrement = false;
            column.Caption = "Codigo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "ArticuloDescripcion";
            column.AutoIncrement = false;
            column.Caption = "Descripcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ArticuloCantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "FamiliaNombre";
            column.AutoIncrement = false;
            column.Caption = "Costo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PrimerConteo";
            column.AutoIncrement = false;
            column.Caption = "Sub0";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SegundoConteo";
            column.AutoIncrement = false;
            column.Caption = "Sub16";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgInventarioCiego.DataSource = table;
        }
        private void Frm_Inventario_Ciego_Shown(object sender, EventArgs e)
        {
            dtFecha.DateTime = DateTime.Now;
            MakeTablaPedidos();
            CargarSucursales();
            CargarParametros();
        }

        private void CargarParametros()
        {
            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarConfiguracion();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    FoliosEnviados = Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoFoliosEnviados"].ToString());
                    if (sel.Datos.Rows[0]["InventarioCiegoGeneraFolios"].ToString() == "True")
                    {
                        GeneraFolios = true;
                    }
                    else
                    {
                        GeneraFolios = false;
                    }
                }
            }
        }

        private void CargarSucursales()
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();
            string v_Sucursal = RegOut.GetSetting("ConexionSQL", "Sucursal");
            if (v_Sucursal != null)
            {
                v_Sucursalnum = Convert.ToInt32(DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Sucursal")));
                CargarSucursales(v_Sucursalnum);
            }
        }
        private void CargarSucursales(int? Valor)
        {
            ConfigConexion conSucursales = new ConfigConexion();
            conSucursales.MtdSeleccionarSucursales();
            if (conSucursales.Exito)
            {
                cboSucursales.Properties.DisplayMember = "SucursalesNombre";
                cboSucursales.Properties.ValueMember = "SucursalesId";
                cboSucursales.EditValue = Valor;
                cboSucursales.Properties.DataSource = conSucursales.Datos;
            }
        }
        private void btnGenera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Iniciado())
            {
                if (!Enviados())
                {
                    MensajeCargando(1);
                    if (CalculaParametros())
                    {
                        if ((ArticulosActivos - ArticuloInventario) < ArticuloDiarios)
                        {
                            valores = new int[ArticuloDiarios];
                            ArticuloDiarios = ArticulosActivos - ArticuloInventario;
                            for (int i = 0; i < ArticuloDiarios; i++)
                            {
                                valores[i] = i;
                            }
                        }
                        else
                        {
                            valores = new int[ArticuloDiarios];
                            for (int i = 0; i < ArticuloDiarios; i++)
                            {
                                do
                                {
                                    Random r = new Random();
                                    alea = r.Next(0, (ArticulosActivos - ArticuloInventario - 1));
                                    ValidaValor(alea, i);
                                } while (!Valido);
                                valores[i] = alea;
                            }
                        }
                    }
                    GeneraGrid();
                    OrdenarArticulos();
                    CrearFolio();
                    MensajeCargando(2);
                    XtraMessageBox.Show("Se ha generado Folio de Inventario");
                }
            }
            else
            {
                XtraMessageBox.Show("Existe Folio Iniciado, debera capturar un folio y enviarlo para poder generar otro");
            }
        }

        private bool Enviados()
        {
            Boolean Valor = false;
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.EEstatus = "Enviado";
            sel.MtdSeleccionarFolioPendiente();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > FoliosEnviados && GeneraFolios == false)
                {
                    //EnviarCorreo();
                    Valor = true;
                }
                else
                {
                    Valor = false;
                }
            }
            return Valor;
        }

        private void CrearFolio()
        {
            CLS_InventarioCiego ins = new CLS_InventarioCiego();
            ins.SucursalesId = v_Sucursalnum;
            ins.MtdInsertarFolio();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    int vfolio = Convert.ToInt32(ins.Datos.Rows[0]["Folio"].ToString());

                    txtFolio.Text = vfolio.ToString();
                    CreaFolioDetalles(vfolio);
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void CreaFolioDetalles(int Folio)
        {
            Bar.Properties.Maximum = dtgValInventarioCiego.RowCount;
            for (int i = 0; i < dtgValInventarioCiego.RowCount; i++)
            {
                Bar.Position = i + 1;
                Application.DoEvents();
                int xRow = dtgValInventarioCiego.GetVisibleRowHandle(i);
                //Inserta Detalles
                CLS_InventarioCiego det = new CLS_InventarioCiego();
                det.InventarioCiegoFolio = Folio;
                det.InventarioCiegoCodigo = dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["ArticuloCodigo"]).ToString();
                det.InventarioCiegoCantidad = Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["ArticuloCantidad"]).ToString());
                det.InventarioCiegoCantidadPrimerConteo = 0;
                det.InventarioCiegoCantidadSegundoConteo = 0;
                det.InventarioCiegoCantidadSistema = 0;
                det.InventarioCiegoCantidadContraloria = 0;
                det.MtdInsertarFolioDetalles();
                if (!det.Exito)
                {
                    XtraMessageBox.Show(det.Mensaje);
                }
                else
                {
                    MarcarArticuloInventario(det.InventarioCiegoCodigo);
                }
            }
            Bar.Position = 0;
        }

        private bool Iniciado()
        {
            Boolean Valor = false;
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.MtdSeleccionarFoliosIniciados();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    Valor = true;
                }
                else
                {
                    Valor = false;
                }
            }
            return Valor;
        }

        private void OrdenarArticulos()
        {
            dtgValInventarioCiego.BeginSort();

            try
            {
                dtgValInventarioCiego.ClearSorting();
                dtgValInventarioCiego.Columns["ArticuloDescripcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }

            finally
            {
                dtgValInventarioCiego.EndSort();
            }
        }

        private void GeneraGrid()
        {
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.MtdSeleccionarArticulosPendientes();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    int fila = 0;
                    foreach (int valor in valores)
                    {
                        fila++;
                        string Numero = fila.ToString();
                        string vArticuloCodigo = sel.Datos.Rows[valor]["ArticuloCodigo"].ToString();
                        string vArticuloDescripcion = sel.Datos.Rows[valor]["ArticuloDescripcion"].ToString();
                        string vArticuloCantidad = sel.Datos.Rows[valor]["ArticuloCantidad"].ToString();
                        string vFamiliaNombre = sel.Datos.Rows[valor]["FamiliaNombre"].ToString();
                        string vPrimerConteo = sel.Datos.Rows[valor]["PrimerConteo"].ToString();
                        string vSegundoConteo = sel.Datos.Rows[valor]["SegundoConteo"].ToString();
                        CreatNewRowArticulo(Numero, vArticuloCodigo, vArticuloDescripcion, vFamiliaNombre, vArticuloCantidad, vPrimerConteo, vSegundoConteo);
                    }
                }
            }
        }
        private void GeneraAleatorio()
        {
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoFolio =Convert.ToInt32(txtFolio.Text);
            sel.MtdSeleccionarArticulosAleatorios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count >= CodigoAleatorios)
                {
                    CLS_InventarioCiego udp = new CLS_InventarioCiego();

                    foreach (int valor in valores)
                    {
                        udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
                        udp.InventarioCiegoCodigo = sel.Datos.Rows[valor]["ArticuloCodigo"].ToString();
                        udp.MtdActualizarDetallesAleatorio();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                }
                else if (sel.Datos.Rows.Count > 0)
                {
                    CLS_InventarioCiego udp = new CLS_InventarioCiego();
                    for (int i = 0; i < sel.Datos.Rows.Count; i++)
                    {
                        udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
                        udp.InventarioCiegoCodigo = sel.Datos.Rows[i]["ArticuloCodigo"].ToString();
                        udp.MtdActualizarDetallesAleatorio();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                }
            }
        }

        private void MarcarArticuloInventario(string vArticuloCodigo)
        {
            CLS_InventarioCiego udp = new CLS_InventarioCiego();
            udp.InventarioCiegoCodigo = vArticuloCodigo;
            udp.MtdActualizarInventarioCodigo();
            if (!udp.Exito)
            {
                XtraMessageBox.Show(udp.Mensaje);
            }
        }

        private void CreatNewRowArticulo(string Numero, string ArticuloCodigo, string ArticuloDescripcion, string FamiliaNombre, string ArticuloCantidad, string PrimerConteo, string SegundoConteo)
        {
            dtgValInventarioCiego.AddNewRow();
            int rowHandle = dtgValInventarioCiego.GetRowHandle(dtgValInventarioCiego.DataRowCount);
            if (dtgValInventarioCiego.IsNewItemRow(rowHandle))
            {
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["Numero"], Numero);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["ArticuloCodigo"], ArticuloCodigo);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["ArticuloDescripcion"], ArticuloDescripcion);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["ArticuloCantidad"], ArticuloCantidad);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["FamiliaNombre"], FamiliaNombre);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["PrimerConteo"], PrimerConteo);
                dtgValInventarioCiego.SetRowCellValue(rowHandle, dtgValInventarioCiego.Columns["SegundoConteo"], SegundoConteo);
            }
        }
        private void ValidaValor(int aleatorio, int pos)
        {
            Valido = true;
            for (int i = 0; i < pos; i++)
            {
                if (Convert.ToInt32(valores[i]) == aleatorio)
                {
                    Valido = false;
                    break;
                }
            }
        }

        private Boolean CalculaParametros()
        {
            Boolean Valor = false;
            CalculaActivos();
            if (ArticulosActivos > 0)
            {
                CLS_ConfigInventario sel = new CLS_ConfigInventario();
                sel.MtdSeleccionarConfiguracion();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0)
                    {
                        Rotacion = Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoRotacion"].ToString());
                        Periodo = Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoPeriodo"].ToString());

                        if (Rotacion > 0)
                        {
                            if (ArticulosActivos > 1)
                            {
                                if (Periodo == 0)
                                {
                                    ArticuloDiarios = (ArticulosActivos / ((365 * (Rotacion * 12)) / 12));
                                }
                                else if (Periodo == 2)
                                {
                                    ArticuloDiarios = (ArticulosActivos / ((365 * Rotacion) / 12));
                                }
                                if (Periodo == 3)
                                {
                                    ArticuloDiarios = (ArticulosActivos / Rotacion);
                                }
                                Valor = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("La articulos activos deben ser mayor a 0");
                            }
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Los articulos activos debe ser mayores a 0");
            }
            return Valor;
        }
        private void CalculaActivos()
        {
            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarAvance();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    ArticuloInventario = Convert.ToInt32(sel.Datos.Rows[0]["TotalArticulosInventario"].ToString());
                    ArticulosActivos = Convert.ToInt32(sel.Datos.Rows[0]["TotalArticulos"].ToString());
                }
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

        private void btnAbrir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
            Frm_Inventario_Ciego_Buscar frm = new Frm_Inventario_Ciego_Buscar();
            frm.Estatus = "Iniciado";
            frm.vFolio = 0;
            frm.ShowDialog();
            if (frm.vFolio > 0)
            {
                txtFolio.Text = frm.vFolio.ToString();
                CargarEncabezado();
                CargarDetalles();
            }
        }

        private void CargarDetalles()
        {
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            sel.MtdSeleccionarFolioDetallesInicio();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgInventarioCiego.DataSource = sel.Datos;
                }
            }
        }

        private void CargarEncabezado()
        {
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            sel.MtdSeleccionarFolio();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtFecha.DateTime = Convert.ToDateTime(sel.Datos.Rows[0]["InventarioCiegoFecha"].ToString());
                    lblEstatus.Text = sel.Datos.Rows[0]["InventarioCiegoEstatus"].ToString();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtFolio.Text = string.Empty;
            dtFecha.DateTime = DateTime.Now;
            dtgInventarioCiego.DataSource = null;
            MakeTablaPedidos();
            lblEstatus.Text = string.Empty;
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty && cboSucursales.EditValue != null)
            {
                long folio = Convert.ToInt32(txtFolio.Text);
                decimal Sucursal = Convert.ToInt32(cboSucursales.EditValue.ToString());
                rpt_InventarioCiego_Inicial rpt = new rpt_InventarioCiego_Inicial(folio);
                ((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
                ReportPrintTool print = new ReportPrintTool(rpt);
                rpt.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Falta seleccionar un folio de inventario");
            }
        }
        private void Form1_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();

            string valServer = RegOut.GetSetting("ConexionSQL", "Server");
            string valDB = RegOut.GetSetting("ConexionSQL", "DBase");
            string valLogin = RegOut.GetSetting("ConexionSQL", "User");
            string valPass = RegOut.GetSetting("ConexionSQL", "Password");

            if (valServer != string.Empty && valDB != string.Empty && valLogin != string.Empty && valPass != string.Empty)
            {
                valServer = DesencriptarTexto.Desencriptar(valServer);
                valDB = DesencriptarTexto.Desencriptar(valDB);
                valLogin = DesencriptarTexto.Desencriptar(valLogin);
                valPass = DesencriptarTexto.Desencriptar(valPass);
                e.ConnectionParameters = new MsSqlConnectionParameters(valServer, valDB, valLogin, valPass, MsSqlAuthorizationType.SqlServer);
            }
        }

        private void dtgValInventarioCiego_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                CLS_InventarioCiego udp = new CLS_InventarioCiego();
                GridView gv = sender as GridView;
                udp.InventarioCiegoCodigo = gv.GetRowCellValue(e.RowHandle, gv.Columns["ArticuloCodigo"]).ToString();
                udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);

                if (e.Column.FieldName == "PrimerConteo")
                {
                    udp.InventarioCiegoCantidadPrimerConteo = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["PrimerConteo"]).ToString());
                    udp.MtdActualizarFolioDetallesPrimer();
                    if (!udp.Exito)
                    {
                        XtraMessageBox.Show(udp.Mensaje);
                    }
                }
                else if (e.Column.FieldName == "SegundoConteo")
                {
                    udp.InventarioCiegoCantidadSegundoConteo = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["SegundoConteo"]).ToString());
                    udp.MtdActualizarFolioDetallesSegundo();
                    if (!udp.Exito)
                    {
                        XtraMessageBox.Show(udp.Mensaje);
                    }
                }
            }
        }

        private void btnEnviar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea enviar la captura de inventario", "Inventario Ciego", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                MensajeCargando(1);
                CLS_ConfigInventario sel = new CLS_ConfigInventario();
                sel.MtdSeleccionarConfiguracion();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0)
                    {
                        if (sel.Datos.Rows[0]["InventarioRutaArchivosPDF"].ToString() != string.Empty)
                        {
                            AgregarAleatorios();
                            string NombreArchivo = sel.Datos.Rows[0]["InventarioRutaArchivosPDF"].ToString() + "\\" + cboSucursales.Text + "_Folio_" + txtFolio.Text + ".pdf";
                            CrearPDF(NombreArchivo);
                            CLS_Email send = new CLS_Email();
                            send.SendMailReportes("Inventario Ciego", 6, NombreArchivo);
                            if (send.Exito)
                            {
                                MarcarEnviado();
                                XtraMessageBox.Show("Se ha enviado el Inventario con exito");
                                LimpiarCampos();
                                MensajeCargando(2);
                            }
                            else
                            {
                                MensajeCargando(2);
                                XtraMessageBox.Show(send.Mensaje);
                            }
                        }
                        else
                        {
                            MensajeCargando(2);
                            XtraMessageBox.Show("No se ha establecido la ruta de Archivos PDF en parametros de Inventario");
                        }
                    }
                    else
                    {
                        MensajeCargando(2);
                    }
                }
                else
                {
                    MensajeCargando(2);
                    XtraMessageBox.Show(sel.Mensaje);
                }
            }
        }

        private void AgregarAleatorios()
        {

            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarConfiguracion();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    CodigoAleatorios = Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoCodigosAleatorios"].ToString());
                    int Sindiferencias = ArticulosSinDiferencias();
                    if (Sindiferencias > 0 && CodigoAleatorios > 0)
                    {
                        valores = new int[CodigoAleatorios];
                        for (int i = 0; i < CodigoAleatorios; i++)
                        {
                            do
                            {
                                Random r = new Random();
                                alea = r.Next(0, (ArticulosSinDiferencias() - 1));
                                ValidaValor(alea, i);
                            } while (!Valido);
                            valores[i] = alea;
                        }
                        GeneraAleatorio();
                    }
                    else
                    {
                        XtraMessageBox.Show("No existen articulos sin diferencias o no se ha configurado el parametro de codigo Aleatorios");
                    }
                }
            }
        }

        private int ArticulosSinDiferencias()
        {
            int Valor = 0;
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            sel.MtdSeleccionarArticulosAleatorios();
            if (sel.Exito)
            {
                Valor = sel.Datos.Rows.Count;
            }
            return Valor;
        }

        private void MarcarEnviado()
        {
            CLS_InventarioCiego udp = new CLS_InventarioCiego();
            udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            udp.Status = "Enviado";
            udp.MtdActualizarFolioStatus();
            if (!udp.Exito)
            {
                XtraMessageBox.Show(udp.Mensaje);
            }
        }

        private void Imprimir()
        {
            if (txtFolio.Text != string.Empty && cboSucursales.EditValue != null)
            {
                long folio = Convert.ToInt32(txtFolio.Text);
                decimal Sucursal = Convert.ToInt32(cboSucursales.EditValue.ToString());
                rpt_InventarioCiego_Enviado rpt = new rpt_InventarioCiego_Enviado(folio);
                ((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
                ReportPrintTool print = new ReportPrintTool(rpt);
                rpt.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Falta seleccionar una Entrada");
            }
        }

        private void CrearPDF(string fileNamepdf)
        {
            int folio = Convert.ToInt32(txtFolio.Text);
            rpt_InventarioCiego_Enviado rpt = new rpt_InventarioCiego_Enviado(folio);
            PdfExportOptions pdfOptions = rpt.ExportOptions.Pdf;
            pdfOptions.PageRange = "1-1000";

            // Specify the quality of exported images.
            pdfOptions.ConvertImagesToJpeg = false;
            pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

            // Specify the PDF/A-compatibility.
            pdfOptions.PdfACompatibility = PdfACompatibility.PdfA3b;

            // The following options are not compatible with PDF/A.
            // The use of these options will result in errors on PDF validation.
            //pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New";
            //pdfOptions.ShowPrintDialogOnOpen = true;

            // If required, you can specify the security and signature options. 
            //pdfOptions.PasswordSecurityOptions
            //pdfOptions.SignatureOptions

            // If required, specify necessary metadata and attachments
            // (e.g., to produce a ZUGFeRD-compatible PDF).
            //pdfOptions.AdditionalMetadata
            //pdfOptions.Attachments

            // Specify the document options.
            pdfOptions.DocumentOptions.Application = "Reporte Inventario Ciego";
            pdfOptions.DocumentOptions.Author = "NexusSoft";
            pdfOptions.DocumentOptions.Keywords = "SES_Inventarios, Reporte, PDF";
            pdfOptions.DocumentOptions.Producer = Environment.UserName.ToString();
            pdfOptions.DocumentOptions.Subject = "Documento Inventario";
            pdfOptions.DocumentOptions.Title = "Reporte Inventario Ciego";

            // Checks the validity of PDF export options 
            // and return a list of any detected inconsistencies.
            IList<string> result = pdfOptions.Validate();
            if (result.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, result));
            }
            else
            {
                rpt.ExportToPdf(fileNamepdf, pdfOptions);
            }
        }
        private void btnIgualar_Click(object sender, EventArgs e)
        {
            if (txtFolio.Text != string.Empty && dtgValInventarioCiego.RowCount>0)
            {
                DialogResult = XtraMessageBox.Show("¿Desea igualar el Segundo Conteo con el Primer Conteo", "Igualar Captura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    Boolean Exito = true;
                    MensajeCargando(1);
                    Bar.Position = 0;
                    Bar.Properties.Maximum = dtgValInventarioCiego.RowCount;
                    for (int i = 0; i < dtgValInventarioCiego.RowCount; i++)
                    {
                        try
                        {
                            int xRow = dtgValInventarioCiego.GetVisibleRowHandle(i);
                            string Valor = dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["PrimerConteo"]).ToString();
                            dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["SegundoConteo"], Valor);
                            Bar.Position = i + 1;
                            Application.DoEvents();
                        }
                        catch (Exception)
                        {
                            Exito = false;
                        }
                    }
                    Bar.Position = 0;
                    if (Exito == true)
                    {
                        MensajeCargando(2);
                        XtraMessageBox.Show("Proceso Aplicado con Exito");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha cargado Folio de Captura");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}