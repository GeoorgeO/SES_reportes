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
using DevExpress.Utils;

namespace BSC_Reportes
{
    public partial class Frm_Pedidos_Sucursales : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        private static Frm_Pedidos_Sucursales m_FormDefInstance;
        public static Frm_Pedidos_Sucursales DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pedidos_Sucursales();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Pedidos_Sucursales()
        {
            InitializeComponent();
        }

        private void Frm_Pedidos_Sucursales_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            MakeTablaPedidos();
            CargarSucursales(1);
            CoberturaA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            CoberturaA.DisplayFormat.FormatString = "###0.000";
            CoberturaN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            CoberturaN.DisplayFormat.FormatString = "###0.000";
            Promed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            Promed.DisplayFormat.FormatString = "###0.000";
            OcultarBotones();
            if (UsuarioClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                MostrarBotones();
            }
        }
        public void OcultarBotones()
        {
            btnGenerarReporte.Links[0].Visible = false;
            btnExportarExcel.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
        }
        public void MostrarBotones()
        {
            CLS_Pantallas clspantbotones = new CLS_Pantallas();
            clspantbotones.UsuariosLogin = UsuariosLogin;
            clspantbotones.pantallasid = IdPantallaBotones;
            clspantbotones.Mtdselecionarbotonespantalla();
            if (clspantbotones.Exito)
            {
                for (int t = 0; t < clspantbotones.Datos.Rows.Count; t++)
                {
                    switch (clspantbotones.Datos.Rows[t][0].ToString())
                    {
                        case "44":
                            btnGenerarReporte.Links[0].Visible = true;
                            break;
                        case "45":
                            btnExportarExcel.Links[0].Visible = true;
                            break;
                        case "46":
                            btnLimpiar.Links[0].Visible = true;
                            break;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(clspantbotones.Mensaje);
            }
        }
        public void accesosuperusuario()
        {
            btnGenerarReporte.Links[0].Visible = true;
            btnExportarExcel.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
        }
        private void LimpiarCampos()
        {
            CargarSucursales(1);
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            dtgPedidos.DataSource = null;
            cmbTiendasSurtir.SelectedIndex = 0;
            txtMesesVenta.Text = string.Empty;
        }

        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Registros";
            column.AutoIncrement = false;
            column.Caption = "#";
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
            column.DataType = typeof(int);
            column.ColumnName = "ArticuloCantidad";
            column.AutoIncrement = false;
            column.Caption = "Existencia Almacen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "EPed";
            column.AutoIncrement = false;
            column.Caption = "Disponible";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Existencia";
            column.AutoIncrement = false;
            column.Caption = "Existencia Sucursal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Tic";
            column.AutoIncrement = false;
            column.Caption = "Menuedo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "May";
            column.AutoIncrement = false;
            column.Caption = "Mayoreo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "vTotal";
            column.AutoIncrement = false;
            column.Caption = "Venta Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Prom";
            column.AutoIncrement = false;
            column.Caption = "Promedio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Ideal";
            column.AutoIncrement = false;
            column.Caption = "Ideal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "IdReal";
            column.AutoIncrement = false;
            column.Caption = "Ideal Real";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Falt";
            column.AutoIncrement = false;
            column.Caption = "Faltante";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Pedido";
            column.AutoIncrement = false;
            column.Caption = "Pedido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "CobAct";
            column.AutoIncrement = false;
            column.Caption = "Cobertura Actual";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "CobNva";
            column.AutoIncrement = false;
            column.Caption = "Cobertura Nueva";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgPedidos.DataSource = table;
        }
        private void CargarSucursales(int? Valor)
        {
            ConexionesSucursales conSucursales = new ConexionesSucursales();
            conSucursales.MtdSeleccionarSucursales();
            if (conSucursales.Exito)
            {
                cboSucursales.Properties.DisplayMember = "SucursalesNombre";
                cboSucursales.Properties.ValueMember = "SucursalesId";
                cboSucursales.EditValue = Valor;
                cboSucursales.Properties.DataSource = conSucursales.Datos;
            }
        }

        private void btnGenerarReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dInicio = Convert.ToDateTime(dtInicio.EditValue);
            DateTime dFin = Convert.ToDateTime(dtFin.EditValue);
            int result = DateTime.Compare(dInicio, dFin);
            if (result < 1)
            {
                var dateSpan = DateTimeSpan.CompareDates(dInicio, dFin);
                CLS_Pedidos_Sucursales selped = new CLS_Pedidos_Sucursales();
                selped.Sucursal = Convert.ToInt32(cboSucursales.EditValue.ToString());
                decimal meses = dateSpan.Months;
                decimal dias = Convert.ToDecimal(dateSpan.Days)/30;
                decimal tmeses = decimal.Round((meses + dias),0);
                if(tmeses==0)
                {
                    tmeses = 1;
                }
                txtMesesVenta.Text = tmeses.ToString();
                selped.MesesVenta = Convert.ToInt32(tmeses);
                selped.FechaInicio = string.Format("{0}{1}{2} 00:00:00", dInicio.Year, DosCeros(dInicio.Month.ToString()), DosCeros(dInicio.Day.ToString()));
                selped.FechaFin = string.Format("{0}{1}{2} 23:59:59", dFin.Year, DosCeros(dFin.Month.ToString()), DosCeros(dFin.Day.ToString()));
                MensajeCargando(1);
                selped.MtdGenerarPedidoSucursal();
                if(selped.Exito)
                {
                    if(selped.Datos.Rows.Count>0)
                    {
                        dtgPedidos.DataSource = selped.Datos;
                        CalcularCampos();
                    }
                    else
                    {
                        XtraMessageBox.Show("No existe registros para mostrar");
                    }
                }
                else
                {
                    XtraMessageBox.Show(selped.Mensaje);
                }
                MensajeCargando(2);
            }
            else
            {
                XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
            }
        }

        private void CalcularCampos()
        {
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                int EPEd = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "ArticuloCantidad").ToString())/Convert.ToInt32(cmbTiendasSurtir.EditValue.ToString());
                int Falt = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Falt").ToString());
                decimal Prom = Convert.ToDecimal(dtgValPedidos.GetRowCellValue(xRow, "Prom").ToString());
                decimal ESuc = Convert.ToDecimal(dtgValPedidos.GetRowCellValue(xRow, "Existencia").ToString());
                dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["EPed"], EPEd);
                if(Falt>EPEd)
                {
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["Pedido"], EPEd);
                }
                else
                {
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["Pedido"], Falt);
                }
                if(Prom==0)
                {
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["CobAct"], Prom);
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["CobNva"], Prom);
                }
                else
                {
                    decimal CobAct = Convert.ToDecimal(ESuc) / Convert.ToDecimal(Prom);
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["CobAct"], CobAct);
                    int Pedido = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Pedido").ToString());
                    decimal CobNva = (Convert.ToDecimal(ESuc) + Convert.ToDecimal(Pedido)) / Convert.ToDecimal(Prom);
                    dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["CobNva"], CobNva);
                }
            }
        }

        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        public struct DateTimeSpan{
            private readonly int years;
            private readonly int months;
            private readonly int days;
            private readonly int hours;
            private readonly int minutes;
            private readonly int seconds;
            private readonly int milliseconds;
            public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
            {
                this.years = years;
                this.months = months;
                this.days = days;
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
                this.milliseconds = milliseconds;
            }
            public int Years
            {
                get { return years;}
            }
            public int Months
            {
                get { return months;}
            }
            public int Days
            {
                get { return days;}
            }
            public int Hours
            {
                get { return hours; }
            }
            public int Minutes
            {
                get { return minutes; }
            }
            public int Seconds
            {
                get { return seconds; }
            }
            public int Milliseconds
            {
                get { return milliseconds; }
            }
            enum Phase { Years, Months, Days, Done }
            public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
            {
                if (date2 < date1)
                {
                    var sub = date1; date1 = date2; date2 = sub;
                }
                DateTime current = date1;
                int years = 0;
                int months = 0;
                int days = 0;
                Phase phase = Phase.Years;
                DateTimeSpan span = new DateTimeSpan();
                while (phase != Phase.Done)
                {
                    switch (phase)
                    {
                        case Phase.Years:
                            if (current.AddYears(years + 1) > date2)
                            {
                                phase = Phase.Months; current = current.AddYears(years);
                            }
                            else
                            {
                                years++;
                            }
                            break;
                        case Phase.Months:
                            if (current.AddMonths(months + 1) > date2)
                            {
                                phase = Phase.Days; current = current.AddMonths(months);
                            }
                            else
                            {
                                months++;
                            }
                            break;
                        case Phase.Days:
                            if (current.AddDays(days + 1) > date2)
                            {
                                current = current.AddDays(days);
                                var timespan = date2 - current;
                                span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                                phase = Phase.Done;
                            }
                            else
                            {
                                days++;
                            }
                            break;
                    }
                }
                return span;
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
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

        private void cmbTiendasSurtir_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress=true;
        }

        private void btnExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValPedidos.RowCount > 0)
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
                        dtgPedidos.ExportToXlsx(path, new DevExpress.XtraPrinting.XlsxExportOptionsEx
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
    }
}