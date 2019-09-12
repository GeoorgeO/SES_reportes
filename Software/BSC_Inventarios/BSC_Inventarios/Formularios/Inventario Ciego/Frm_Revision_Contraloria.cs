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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;
using System.IO;

namespace BSC_Inventarios
{
    public partial class Frm_Revision_Contraloria : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public int v_Sucursalnum { get; private set; }
        private static Frm_Revision_Contraloria m_FormDefInstance;
        public static Frm_Revision_Contraloria DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Revision_Contraloria();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public bool PrimeraEdicion { get; private set; }
        public int CantidadActual { get; private set; }
        public int? Diferencia { get; private set; }
        public string RutaArchivos { get; private set; }

        public Frm_Revision_Contraloria()
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
            column.ColumnName = "InventarioCiegoCantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "FamiliaNombre";
            column.AutoIncrement = false;
            column.Caption = "Familia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SegundoConteo";
            column.AutoIncrement = false;
            column.Caption = "SegundoConteo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "InventarioCiegoCantidadSistema";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "InventarioCiegoCantidadContraloria";
            column.AutoIncrement = false;
            column.Caption = "Conteo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "InventarioCiegoEntrada";
            column.AutoIncrement = false;
            column.Caption = "Entrada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "InventarioCiegoSalida";
            column.AutoIncrement = false;
            column.Caption = "Salida";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            dtgInventarioCiego.DataSource = table;
        }
        private void btnAbrir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
            Frm_Inventario_Ciego_Buscar frm = new Frm_Inventario_Ciego_Buscar();
            frm.Estatus = "Enviado,Finalizado";
            frm.vFolio = 0;
            frm.ShowDialog();
            if (frm.vFolio > 0)
            {
                MensajeCargando(1);
                txtFolio.Text = frm.vFolio.ToString();
                CargarEncabezado();
                CargarDetalles();
                MensajeCargando(2);
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
        private void LimpiarCampos()
        {
            txtFolio.Text = string.Empty;
            dtFecha.DateTime = DateTime.Now;
            dtgInventarioCiego.DataSource = null;
            MakeTablaPedidos();
            lblEstatus.Text = string.Empty;
        }
        private void CargarDetalles()
        {
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            sel.MtdSeleccionarFolioDetallesEnviado();
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
                    if(lblEstatus.Text=="Finalizado")
                    {
                        gridColumn7.OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridColumn7.OptionsColumn.AllowEdit = true;
                    }
                }
            }
        }

        private void dtgValInventarioCiego_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (txtFolio.Text != string.Empty)
            {
                if (PrimeraEdicion == false)
                {
                    if (e.Column.FieldName == "InventarioCiegoCantidadContraloria")
                    {
                        PrimeraEdicion = true;
                        GridView gv = sender as GridView;
                        CantidadActual = ExistenciaArticulo(gv.GetRowCellValue(e.RowHandle, gv.Columns["ArticuloCodigo"]).ToString());
                        gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoCantidadSistema"], CantidadActual);
                        Diferencia = CantidadActual - Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoCantidadContraloria"]).ToString());
                        if (Diferencia < 0)
                        {
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoEntrada"],Convert.ToInt32(Math.Abs(Convert.ToDecimal(Diferencia))));
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoSalida"], 0);
                        }
                        else if(Diferencia>0)
                        {
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoEntrada"], 0);
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoSalida"], Convert.ToInt32(Math.Abs(Convert.ToDecimal(Diferencia))));
                        }
                        else
                        {
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoEntrada"], 0);
                            gv.SetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoSalida"], 0);
                        }
                        CLS_InventarioCiego udp = new CLS_InventarioCiego();
                        udp.InventarioCiegoCodigo = gv.GetRowCellValue(e.RowHandle, gv.Columns["ArticuloCodigo"]).ToString();
                        udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
                        udp.InventarioCiegoCantidadContraloria = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoCantidadContraloria"]).ToString());
                        udp.InventarioCiegoEntrada = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoEntrada"]).ToString());
                        udp.InventarioCiegoSalida = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["InventarioCiegoSalida"]).ToString());
                        udp.MtdActualizarFolioDetallesContraloria();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                        PrimeraEdicion = false;
                    }
                }
            }
        }

        private int ExistenciaArticulo(string v)
        {
            int Valor = 0;
            CLS_InventarioCiego sel = new CLS_InventarioCiego();
            sel.InventarioCiegoCodigo = v;
            sel.MtdSeleccionarArticulosExistencia();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    Valor =Convert.ToInt32(sel.Datos.Rows[0]["ArticuloCantidad"].ToString());
                }
            }
            return Valor;
        }

        private void btnFinalizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                MensajeCargando(1);
                VerificarConteo0();
                MarcarFinalizado();
                MensajeCargando(2);
            }
            else
            {
                ; XtraMessageBox.Show("No se ha cargado Folio de Inventario");
            }
        }

        private void VerificarConteo0()
        {
            for (int i = 0; i < dtgValInventarioCiego.RowCount; i++)
            {
                int xRow = dtgValInventarioCiego.GetVisibleRowHandle(i);
                if(Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoCantidadContraloria"]).ToString())==0)
                {
                    CantidadActual = ExistenciaArticulo(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["ArticuloCodigo"]).ToString());
                    dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoCantidadSistema"], CantidadActual);
                    Diferencia = CantidadActual - Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoCantidadContraloria"]).ToString());
                    if (Diferencia < 0)
                    {
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoEntrada"], Convert.ToInt32(Math.Abs(Convert.ToDecimal(Diferencia))));
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoSalida"], 0);
                    }
                    else if (Diferencia > 0)
                    {
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoEntrada"], 0);
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoSalida"], Convert.ToInt32(Math.Abs(Convert.ToDecimal(Diferencia))));
                    }
                    else
                    {
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoEntrada"], 0);
                        dtgValInventarioCiego.SetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoSalida"], 0);
                    }
                    CLS_InventarioCiego udp = new CLS_InventarioCiego();
                    udp.InventarioCiegoCodigo = dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["ArticuloCodigo"]).ToString();
                    udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
                    udp.InventarioCiegoCantidadContraloria = Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoCantidadContraloria"]).ToString());
                    udp.InventarioCiegoEntrada = Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoEntrada"]).ToString());
                    udp.InventarioCiegoSalida = Convert.ToInt32(dtgValInventarioCiego.GetRowCellValue(xRow, dtgValInventarioCiego.Columns["InventarioCiegoSalida"]).ToString());
                    udp.MtdActualizarFolioDetallesContraloria();
                    if (!udp.Exito)
                    {
                        XtraMessageBox.Show(udp.Mensaje);
                    }
                }
            }
        }

        private void MarcarFinalizado()
        {
            CLS_InventarioCiego udp = new CLS_InventarioCiego();
            udp.InventarioCiegoFolio = Convert.ToInt32(txtFolio.Text);
            udp.Status = "Finalizado";
            udp.MtdActualizarFolioStatus();
            if (!udp.Exito)
            {
                XtraMessageBox.Show(udp.Mensaje);
            }
            else
            {
                lblEstatus.Text = "Finalizado";
                gridColumn7.OptionsColumn.AllowEdit = false;
            }
        }

        private void Frm_Revision_Contraloria_Shown(object sender, EventArgs e)
        {
            CargarSucursales();
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

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnHojaChecado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnReporteFinalES_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                if (lblEstatus.Text == "Finalizado")
                {
                    if (cboSucursales.EditValue != null)
                    {
                        long folio = Convert.ToInt32(txtFolio.Text);
                        decimal Sucursal = Convert.ToInt32(cboSucursales.EditValue.ToString());
                        rpt_InventarioCiego_Finalizado rpt = new rpt_InventarioCiego_Finalizado(folio);
                        ((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
                        ReportPrintTool print = new ReportPrintTool(rpt);
                        rpt.ShowPreviewDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se ha configurado Sucursal");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se ha finalizado el folio de inventario");
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha cargado un folio de inventario");
            }
        }
        private static string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void btnGenera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                if (lblEstatus.Text == "Finalizado")
                {
                    MensajeCargando(1);
                    DirectorySucursal();
                    string Ruta = RutaArchivos;
                    string fileName = string.Empty;
                    string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
                    string TipoArch = string.Empty;
                    //Entrada
                    if (ExitenEntradas())
                    {
                        TipoArch = "Entrada";
                        fileName = String.Format("{0}_InventarioCiego[{1}]_{2}.txt", TipoArch, txtFolio.Text, VFecha);
                        Ruta += fileName;
                        FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(stream);
                        for (int x = 0; x < dtgValInventarioCiego.RowCount; x++)
                        {
                            int xRow = dtgValInventarioCiego.GetVisibleRowHandle(x);
                            if (dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoEntrada").ToString() != "0")
                            {
                                string Linea = String.Format(",,,{0},{1}", dtgValInventarioCiego.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoEntrada").ToString());
                                writer.WriteLine(Linea);
                            }
                        }
                        writer.Close();
                    }
                    if (ExitenSalidas())
                    {
                        //Salida
                        Ruta = RutaArchivos;
                        fileName = string.Empty;
                        VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
                        TipoArch = "Salida";
                        fileName = String.Format("{0}_InventarioCiego[{1}]_{2}.txt", TipoArch, txtFolio.Text, VFecha);
                        Ruta += fileName;
                        FileStream stream2 = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer2 = new StreamWriter(stream2);
                        for (int x = 0; x < dtgValInventarioCiego.RowCount; x++)
                        {
                            int xRow = dtgValInventarioCiego.GetVisibleRowHandle(x);
                            if (dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoSalida").ToString() != "0")
                            {
                                string Linea = String.Format(",,,{0},{1}", dtgValInventarioCiego.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoSalida").ToString());
                                writer2.WriteLine(Linea);
                            }
                        }
                        writer2.Close();
                    }
                    MensajeCargando(2);
                    XtraMessageBox.Show("Archivos generados con exito");
                }
                else
                {
                    XtraMessageBox.Show("No se ha finalizado el folio de inventario");
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha cargado un folio de inventario");
            }
        }

        private bool ExitenSalidas()
        {
            Boolean Valor = false;
            for (int x = 0; x < dtgValInventarioCiego.RowCount; x++)
            {
                int xRow = dtgValInventarioCiego.GetVisibleRowHandle(x);
                if (dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoSalida").ToString() != "0")
                {
                    Valor = true;
                    break;
                }
            }
            return Valor;
        }

        private bool ExitenEntradas()
        {
            Boolean Valor = false;
            for (int x = 0; x < dtgValInventarioCiego.RowCount; x++)
            {
                int xRow = dtgValInventarioCiego.GetVisibleRowHandle(x);
                if (dtgValInventarioCiego.GetRowCellValue(xRow, "InventarioCiegoEntrada").ToString() != "0")
                {
                    Valor = true;
                    break;
                }
            }
            return Valor;
        }

        private void DirectorySucursal()
        {
            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarConfiguracion();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    if (sel.Datos.Rows[0]["InventarioRutaArchivosPDF"].ToString() != string.Empty)
                    {

                        RutaArchivos = sel.Datos.Rows[0]["InventarioRutaArchivosPDF"].ToString();
                        if (RutaArchivos != string.Empty)
                        {
                            System.IO.Directory.CreateDirectory(RutaArchivos);
                            RutaArchivos = RutaArchivos + "\\" + txtFolio.Text;
                            System.IO.Directory.CreateDirectory(RutaArchivos);
                            RutaArchivos += "\\";
                        }
                    }
                }
            }
        }
    }
}