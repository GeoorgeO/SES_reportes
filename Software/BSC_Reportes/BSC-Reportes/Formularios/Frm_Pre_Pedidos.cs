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

namespace BSC_Reportes
{
    public partial class Frm_Pre_Pedidos : DevExpress.XtraEditors.XtraForm
    {

        public string vArticuloCodigo { get; private set; }
        public string vArticuloDescripcion { get; private set; }
        public string vArticuloCostoReposicion { get; private set; }
        public string vFamiliaNombre { get; private set; }
        public string vTVentasAlmacen { get; private set; }
        public string vExisAlmacen { get; private set; }
        public string vTVentasApatzingan { get; private set; }
        public string vExisApatzingan { get; private set; }
        public string vTVentasCalzada { get; private set; }
        public string vExisCalzada { get; private set; }
        public string vTVentasCentro { get; private set; }
        public string vExisCentro { get; private set; }
        public string vTVentasCostaRica { get; private set; }
        public string vExisCostaRica { get; private set; }
        public string vTVentasEstocolmo { get; private set; }
        public string vExisEstocolmo { get; private set; }
        public string vTVentasFcoVilla { get; private set; }
        public string vExisFcoVilla { get; private set; }
        public string vTVentasLombardia { get; private set; }
        public string vExisLombardia { get; private set; }
        public string vTVentasLosReyes { get; private set; }
        public string vExisLosReyes { get; private set; }
        public string vTVentasMorelos { get; private set; }
        public string vExisMorelos { get; private set; }
        public string vTVentasNvaItalia { get; private set; }
        public string vExisNvaItalia { get; private set; }
        public string vTVentasPaseo { get; private set; }
        public string vExisPaseo { get; private set; }
        public string vTVentasSarabiaI { get; private set; }
        public string vExisSarabiaI { get; private set; }
        public string vTVentasSarabiaII { get; private set; }
        public string vExisSarabiaII { get; private set; }
        public decimal mesesT { get; private set; }
        public decimal sugerido { get; private set; }
        public decimal Ideal { get; private set; }
        public string UsuariosLogin { get;  set; }
        public char UsuarioClase { get; set; }
        public int PrePedidosId { get; private set; }
        public int xRow { get; private set; }
        public int IdPantallaBotones { get;  set; }
        private static Frm_Pre_Pedidos m_FormDefInstance;
        public static Frm_Pre_Pedidos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pre_Pedidos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public object PeriodoPedido { get; private set; }

        public Frm_Pre_Pedidos()
        {
            InitializeComponent();
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
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();
            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Codigo";
            column.AutoIncrement = false;
            column.Caption = "Codigo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Descripcion";
            column.AutoIncrement = false;
            column.Caption = "Descripcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "CostoReposicion";
            column.AutoIncrement = false;
            column.Caption = "Costo Reposicion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Familia";
            column.AutoIncrement = false;
            column.Caption = "Familia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "AlmacenV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "AlmacenE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CentroV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CentroE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "MorelosV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "MorelosE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "FcoVillaV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "FcoVillaE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaIV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaIE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaIIV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SarabiaIIE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PaseoV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PaseoE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "EstocolmoV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "EstocolmoE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CostaRicaV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CostaRicaE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CalzadaV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "CalzadaE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "LombardiaV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "LombardiaE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "NvaItaliaV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "NvaItaliaE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ApatzinganV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ApatzinganE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ReyesV";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "ReyesE";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TotalV";
            column.AutoIncrement = false;
            column.Caption = "TotalV";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TotalE";
            column.AutoIncrement = false;
            column.Caption = "TotalE";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PIdeal";
            column.AutoIncrement = false;
            column.Caption = "Pedido Ideal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "PSugerido";
            column.AutoIncrement = false;
            column.Caption = "Pedido Sugerido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TPedido";
            column.AutoIncrement = false;
            column.Caption = "Total Pedido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgVentaExistencia.DataSource = table;
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkVentas.Checked = true;
            chkExistencia.Checked = true;
            rdbTipo.SelectedIndex = 0;
            dtgVentaExistencia.DataSource = null;
        }
        private void txtProveedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BuscarProveedor(txtProveedorId.Text);
            }
        }
        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
        }
        public void BuscarPrePedido(string vPrePedidoId)
        {
            txtFolio.Text = vPrePedidoId;
        }
        private void Frm_ReportePedidos_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkVentas.Checked = true;
            chkExistencia.Checked = true;
            chkCosto.Checked = true;
            chkFamilia.Checked = true;
            rdbTipo.SelectedIndex = 0;
            dtgVentaExistencia.DataSource = null;
            MakeTablaPedidos();
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValVentaExistencia.OptionsSelection.MultiSelect = true;
            dtgValVentaExistencia.OptionsView.ShowGroupPanel = false;
            CostoReposicion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            CostoReposicion.DisplayFormat.FormatString = "$ ###,###0.00";
            pbProgreso.Position = 0;
        }
        private void rdbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbTipo.SelectedIndex == 0)
            {
                DetalladoGrids();
                chkVentas.Enabled = true;
                chkExistencia.Enabled = true;
                chkVentas.Checked = true;
                chkExistencia.Checked = true;
            }
            else
            {
                ConcentradoGrids();
                chkVentas.Enabled = false;
                chkExistencia.Enabled = false;
                chkVentas.Checked = false;
                chkExistencia.Checked = false;
            }
        }
        private void DetalladoGrids()
        {
            ColumnsVentas(true);
            ColumnsExistencia(true);
            ColumnsBands(true);
        }
        private void ConcentradoGrids()
        {
            ColumnsVentas(false);
            ColumnsExistencia(false);
            ColumnsBands(false);
        }
        private void ColumnsBands(Boolean Mostrar)
        {
            gridBand2.Visible = Mostrar;
            gridBand3.Visible = Mostrar;
            gridBand4.Visible = Mostrar;
            gridBand5.Visible = Mostrar;
            gridBand6.Visible = Mostrar;
            gridBand7.Visible = Mostrar;
            gridBand8.Visible = Mostrar;
            gridBand9.Visible = Mostrar;
            gridBand10.Visible = Mostrar;
            gridBand11.Visible = Mostrar;
            gridBand12.Visible = Mostrar;
            gridBand13.Visible = Mostrar;
            gridBand14.Visible = Mostrar;
            gridBand15.Visible = Mostrar;
        }
        private void ColumnsExistencia(Boolean Mostrar)
        {
            AlmacenE.Visible = Mostrar;
            CentroE.Visible = Mostrar;
            MorelosE.Visible = Mostrar;
            FcoVillaE.Visible = Mostrar;
            SarabiaIE.Visible = Mostrar;
            SarabiaIIE.Visible = Mostrar;
            PaseoE.Visible = Mostrar;
            EstocolmoE.Visible = Mostrar;
            CostaRicaE.Visible = Mostrar;
            CalzadaE.Visible = Mostrar;
            LombardiaE.Visible = Mostrar;
            NvaItaliaE.Visible = Mostrar;
            ApatzinganE.Visible = Mostrar;
            ReyesE.Visible = Mostrar;
        }
        private void ColumnsCosto(Boolean Mostrar)
        {
            CostoReposicion.Visible = Mostrar;
        }
        private void ColumnsFamilia(Boolean Mostrar)
        {
            Familia.Visible = Mostrar;
        }
        private void ColumnsVentas(Boolean Mostrar)
        {
            AlmacenV.Visible = Mostrar;
            CentroV.Visible = Mostrar;
            MorelosV.Visible = Mostrar;
            FcoVillaV.Visible = Mostrar;
            SarabiaIV.Visible = Mostrar;
            SarabiaIIV.Visible = Mostrar;
            EstocolmoV.Visible = Mostrar;
            CostaRicaV.Visible = Mostrar;
            CalzadaV.Visible = Mostrar;
            LombardiaV.Visible = Mostrar;
            NvaItaliaV.Visible = Mostrar;
            ApatzinganV.Visible = Mostrar;
            ReyesV.Visible = Mostrar;
        }
        private void chkVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentas.Checked == true)
            {
                ColumnsBands(true);
                ColumnsVentas(true);
            }
            else if (chkVentas.Checked == false)
            {
                ColumnsVentas(false);
            }
            if (chkVentas.Checked == false && chkExistencia.Checked == false)
            {
                ColumnsBands(false);
            }
        }
        private void chkExistencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExistencia.Checked == true)
            {
                ColumnsBands(true);
                ColumnsExistencia(true);
            }
            else if (chkExistencia.Checked == false)
            {
                ColumnsExistencia(false);
            }
            if (chkVentas.Checked == false && chkExistencia.Checked == false)
            {
                ColumnsBands(false);
            }
        }
        private void chkCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCosto.Checked == true)
            {
                ColumnsCosto(true);
            }
            else
            {
                ColumnsCosto(false);
            }
        }
        private void chkFamilia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFamilia.Checked == true)
            {
                ColumnsFamilia(true);
            }
            else
            {
                ColumnsFamilia(false);
            }
        }
        private void btnImpProveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmReportePedidos = this;
            frmpro.ShowDialog();
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
        private void CreatNewRowProveedor(string ArticuloCodigo, string ArticuloDescripcion, string ArticuloCostoReposicion, string FamiliaNombre, string VAlmacen, string EAlmacen,
                                    string VCentro, string ECentro, string VMorelos, string EMorelos, string VFCoVilla, string EFcoVilla, string VSarabiaI, string ESarabiaI,
                                    string VSarabiaII, string ESarabiaII, string VPaseo, string EPaseo, string VEstocolmo, string EEstocolmo, string VCostaRica, string ECostaRica,
                                    string VCalzada, string ECalzada, string VLombardia, string ELombardia, string VNvaItalia, string ENvaItalia, string VApatzingan, string EApatzingan,
                                    string VReyes, string EReyes, string TotalV, string TotalE, string TPedido, string PSugerido, string PIdeal)
        {
            dtgValVentaExistencia.AddNewRow();

            int rowHandle = dtgValVentaExistencia.GetRowHandle(dtgValVentaExistencia.DataRowCount);
            if (dtgValVentaExistencia.IsNewItemRow(rowHandle))
            {
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Codigo"], ArticuloCodigo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Descripcion"], ArticuloDescripcion);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CostoReposicion"], ArticuloCostoReposicion);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Familia"], FamiliaNombre);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["AlmacenV"], VAlmacen);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["AlmacenE"], EAlmacen);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CentroV"], VCentro);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CentroE"], ECentro);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["MorelosV"], VMorelos);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["MorelosE"], EMorelos);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["FcoVillaV"], VFCoVilla);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["FcoVillaE"], EFcoVilla);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["SarabiaIV"], VSarabiaI);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["SarabiaIE"], ESarabiaI);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["SarabiaIIV"], VSarabiaII);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["SarabiaIIE"], ESarabiaII);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["PaseoV"], VPaseo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["PaseoE"], EPaseo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["EstocolmoV"], VEstocolmo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["EstocolmoE"], EEstocolmo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CostaRicaV"], VCostaRica);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CostaRicaE"], ECostaRica);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CalzadaV"], VCalzada);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["CalzadaE"], ECalzada);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["LombardiaV"], VLombardia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["LombardiaE"], ELombardia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["NvaItaliaV"], VNvaItalia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["NvaItaliaE"], ENvaItalia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["ApatzinganV"], VApatzingan);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["ApatzinganE"], EApatzingan);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["ReyesV"], VReyes);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["ReyesE"], EReyes);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["TotalV"], TotalV);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["TotalE"], TotalE);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["PIdeal"], PIdeal);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["PSugerido"], PSugerido);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["TPedido"], TPedido);
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ExistenPrePedidos(txtProveedorId.Text))
            {
                if (txtProveedorId.Text != string.Empty)
                {
                    if (Convert.ToInt32(txtProveedorId.Text) > 0)
                    {
                        DateTime dInicio = Convert.ToDateTime(dtInicio.EditValue);
                        DateTime dFin = Convert.ToDateTime(dtFin.EditValue);
                        int result = DateTime.Compare(dInicio, dFin);
                        if (result < 1)
                        {
                            if (txtPeriodo.Text != string.Empty)
                            {
                                if (Convert.ToInt32(txtPeriodo.Text) > 0)
                                {
                                    MensajeCargando(1);
                                    CLS_Pedidos selped = new CLS_Pedidos();
                                    DateTime FInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
                                    DateTime FFin = Convert.ToDateTime(dtFin.EditValue.ToString());
                                    TimeSpan diferencia = FFin.Subtract(FInicio);
                                    int diasT = diferencia.Days;
                                    mesesT = Math.Round((Convert.ToDecimal(diasT) / 30), 0);
                                    selped.FechaInicio = string.Format("{0}{1}{2} 00:00:00", FInicio.Year, DosCeros(FInicio.Month.ToString()), DosCeros(FInicio.Day.ToString()));
                                    selped.FechaFin = string.Format("{0}{1}{2} 23:59:59", FFin.Year, DosCeros(FFin.Month.ToString()), DosCeros(FFin.Day.ToString()));
                                    selped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
                                    selped.MtdGenerarPedidoProveedor();
                                    if (selped.Exito)
                                    {
                                        if (selped.Datos.Rows.Count > 0)
                                        {
                                            CargandoPedido(selped.Datos);
                                        }
                                    }
                                    MensajeCargando(2);
                                }
                                else
                                {
                                    XtraMessageBox.Show("El Periodo debe ser mayor a 0");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("No se ha capturado Periodo para el pedido");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Debe seleccionar un proveedor");
                }
            }
            else
            {
                XtraMessageBox.Show("Existe Pedido pendiente con este proveedor./nNo se puede generar un nuevo pedido hasta no finalizar o eliminar este pedido");
            }
        }
        private bool ExistenPrePedidos(string vProveedorId)
        {
            Boolean Valor = false;
            CLS_Pedidos selexi = new CLS_Pedidos();
            selexi.ProveedorId = Convert.ToInt32(vProveedorId);
            if (Convert.ToInt32(selexi.MtdExistePedidoProveedor()) > 0)
            {
                Valor = true;
            }
            return Valor;
        }
        private void CargandoPedido(DataTable datos)
        {
            int TVentas = 0;
            int TExistencia = 0;
            pbProgreso.Properties.Maximum = datos.Rows.Count;

            for (int x = 0; x < datos.Rows.Count; x++)
            {
                pbProgreso.Position = x + 1;
                Application.DoEvents();
                TVentas = 0;
                TExistencia = 0;
                vArticuloCodigo = datos.Rows[x]["ArticuloCodigo"].ToString();
                vArticuloDescripcion = datos.Rows[x]["ArticuloDescripcion"].ToString();
                vArticuloCostoReposicion = datos.Rows[x]["ArticuloCostoReposicion"].ToString();
                vFamiliaNombre = datos.Rows[x]["FamiliaNombre"].ToString();

                vTVentasAlmacen = datos.Rows[x]["TVentasAlmacen"].ToString();
                TVentas += Convert.ToInt32(vTVentasAlmacen);
                vExisAlmacen = datos.Rows[x]["ExisAlmacen"].ToString();
                TExistencia += Convert.ToInt32(vExisAlmacen);

                vTVentasApatzingan = datos.Rows[x]["TVentasApatzingan"].ToString();
                TVentas += Convert.ToInt32(vTVentasApatzingan);
                vExisApatzingan = datos.Rows[x]["ExisApatzingan"].ToString();
                TExistencia += Convert.ToInt32(vExisApatzingan);

                vTVentasCalzada = datos.Rows[x]["TVentasCalzada"].ToString();
                TVentas += Convert.ToInt32(vTVentasCalzada);
                vExisCalzada = datos.Rows[x]["ExisCalzada"].ToString();
                TExistencia += Convert.ToInt32(vExisCalzada);

                vTVentasCentro = datos.Rows[x]["TVentasCentro"].ToString();
                TVentas += Convert.ToInt32(vTVentasCentro);
                vExisCentro = datos.Rows[x]["ExisCentro"].ToString();
                TExistencia += Convert.ToInt32(vExisCentro);

                vTVentasCostaRica = datos.Rows[x]["TVentasCostaRica"].ToString();
                TVentas += Convert.ToInt32(vTVentasCostaRica);
                vExisCostaRica = datos.Rows[x]["ExisCostaRica"].ToString();
                TExistencia += Convert.ToInt32(vExisCostaRica);

                vTVentasEstocolmo = datos.Rows[x]["TVentasEstocolmo"].ToString();
                TVentas += Convert.ToInt32(vTVentasEstocolmo);
                vExisEstocolmo = datos.Rows[x]["ExisEstocolmo"].ToString();
                TExistencia += Convert.ToInt32(vExisEstocolmo);

                vTVentasFcoVilla = datos.Rows[x]["TVentasFcoVilla"].ToString();
                TVentas += Convert.ToInt32(vTVentasFcoVilla);
                vExisFcoVilla = datos.Rows[x]["ExisFcoVilla"].ToString();
                TExistencia += Convert.ToInt32(vExisFcoVilla);

                vTVentasLombardia = datos.Rows[x]["TVentasLombardia"].ToString();
                TVentas += Convert.ToInt32(vTVentasLombardia);
                vExisLombardia = datos.Rows[x]["ExisLombardia"].ToString();
                TExistencia += Convert.ToInt32(vExisLombardia);

                vTVentasLosReyes = datos.Rows[x]["TVentasLosReyes"].ToString();
                TVentas += Convert.ToInt32(vTVentasLosReyes);
                vExisLosReyes = datos.Rows[x]["ExisLosReyes"].ToString();
                TExistencia += Convert.ToInt32(vExisLosReyes);

                vTVentasMorelos = datos.Rows[x]["TVentasMorelos"].ToString();
                TVentas += Convert.ToInt32(vTVentasMorelos);
                vExisMorelos = datos.Rows[x]["ExisMorelos"].ToString();
                TExistencia += Convert.ToInt32(vExisMorelos);

                vTVentasNvaItalia = datos.Rows[x]["TVentasNvaItalia"].ToString();
                TVentas += Convert.ToInt32(vTVentasNvaItalia);
                vExisNvaItalia = datos.Rows[x]["ExisNvaItalia"].ToString();
                TExistencia += Convert.ToInt32(vExisNvaItalia);

                vTVentasPaseo = datos.Rows[x]["TVentasPaseo"].ToString();
                TVentas += Convert.ToInt32(vTVentasPaseo);
                vExisPaseo = datos.Rows[x]["ExisPaseo"].ToString();
                TExistencia += Convert.ToInt32(vExisPaseo);

                vTVentasSarabiaI = datos.Rows[x]["TVentasSarabiaI"].ToString();
                TVentas += Convert.ToInt32(vTVentasSarabiaI);
                vExisSarabiaI = datos.Rows[x]["ExisSarabiaI"].ToString();
                TExistencia += Convert.ToInt32(vExisSarabiaI);

                vTVentasSarabiaII = datos.Rows[x]["TVentasSarabiaII"].ToString();
                TVentas += Convert.ToInt32(vTVentasSarabiaII);
                vExisSarabiaII = datos.Rows[x]["ExisSarabiaII"].ToString();
                TExistencia += Convert.ToInt32(vExisSarabiaII);

                Decimal MesesPedido = 0;
                if (rdbPeriodo.SelectedIndex == 0)
                {
                    MesesPedido = Math.Round((Convert.ToDecimal(txtPeriodo.Text) / 30), 0);
                }
                else if (rdbPeriodo.SelectedIndex == 1)
                {
                    MesesPedido = Convert.ToDecimal(txtPeriodo.Text);
                }
                else if (rdbPeriodo.SelectedIndex == 2)
                {
                    MesesPedido = Convert.ToDecimal(txtPeriodo.Text) * 12;
                }
                if (mesesT > 0)
                {
                    sugerido = Math.Round((Convert.ToDecimal(TVentas / mesesT) * MesesPedido) - TExistencia, 0);
                    Ideal = Math.Round((Convert.ToDecimal(TVentas / mesesT) * MesesPedido), 0);
                    if (sugerido < 0)
                    {
                        sugerido = 0;
                    }
                }
                else
                {
                    sugerido = Math.Round(((TVentas / 1) * MesesPedido) - TExistencia, 0);
                    Ideal = Math.Round((Convert.ToDecimal(TVentas / 1) * MesesPedido), 0);
                    if (sugerido < 0)
                    {
                        sugerido = 0;
                    }
                }

                CreatNewRowProveedor(vArticuloCodigo, vArticuloDescripcion, vArticuloCostoReposicion, vFamiliaNombre, vTVentasAlmacen, vExisAlmacen, vTVentasCentro, vExisCentro, vTVentasMorelos, vExisMorelos
                                    , vTVentasFcoVilla, vExisFcoVilla, vTVentasSarabiaI, vExisSarabiaI, vTVentasSarabiaII, vExisSarabiaII
                                    , vTVentasPaseo, vExisPaseo, vTVentasEstocolmo, vExisEstocolmo, vTVentasCostaRica, vExisCostaRica
                                    , vTVentasCalzada, vExisCalzada, vTVentasLombardia, vExisLombardia, vTVentasNvaItalia, vExisNvaItalia
                                    , vTVentasApatzingan, vExisApatzingan, vTVentasLosReyes, vExisLosReyes, TVentas.ToString(), TExistencia.ToString(), "0", sugerido.ToString(), Ideal.ToString());
            }
            XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        private void btnIgualar_Click(object sender, EventArgs e)
        {
            if (dtgValVentaExistencia.RowCount > 0)
            {
                DialogResult = XtraMessageBox.Show("¿Desea Igualar el pedido sugerido con el pedido Final?\nLos cambios no se podran revertir", "Igualar sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    pbProgreso.Properties.Maximum = dtgValVentaExistencia.RowCount;
                    for (int i = 0; i < dtgValVentaExistencia.RowCount; i++)
                    {
                        pbProgreso.Position = i + 1;
                        Application.DoEvents();
                        int xRow = dtgValVentaExistencia.GetVisibleRowHandle(i);
                        string Sugerido = dtgValVentaExistencia.GetRowCellValue(xRow, "PSugerido").ToString();
                        dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["TPedido"], Sugerido);
                    }
                    XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                XtraMessageBox.Show("Es necesario generar un pedido", "No Existe Pedido Generado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MensajeCargando(1);
            EliminarPedido();
            GuardarPrepedido();
            MensajeCargando(2);
        }

        private void GuardarPrepedido()
        {
            CLS_Pedidos insped = new CLS_Pedidos();
            insped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
            insped.ProveedorNombre = txtProveedorNombre.Text;
            insped.FechaInicio = dtInicio.DateTime.Year + DosCeros(dtInicio.DateTime.Month.ToString()) + DosCeros(dtInicio.DateTime.Day.ToString());
            insped.FechaFin = dtFin.DateTime.Year + DosCeros(dtFin.DateTime.Month.ToString()) + DosCeros(dtFin.DateTime.Day.ToString());
            insped.UsuariosLogin = UsuariosLogin;
            insped.PeriodoPedido = Convert.ToInt32(txtPeriodo.Text);
            if (rdbPeriodo.SelectedIndex == 0)
            {
                insped.PeriodoTipo = 1;
            }
            else if (rdbPeriodo.SelectedIndex == 1)
            {
                insped.PeriodoTipo = 2;
            }
            else if (rdbPeriodo.SelectedIndex == 2)
            {
                insped.PeriodoTipo = 3;
            }
            insped.MtdInsertPrePedidoProveedor();
            if (insped.Exito)
            {
                if (insped.Datos.Rows.Count > 0)
                {
                    PrePedidosId = Convert.ToInt32(insped.Datos.Rows[0][0].ToString());
                    GuardarDetalles();
                }
            }
        }

        private void GuardarDetalles()
        {
            pbProgreso.Properties.Maximum = dtgValVentaExistencia.RowCount;
            for (int i = 0; i < dtgValVentaExistencia.RowCount; i++)
            {
                pbProgreso.Position = i + 1;
                Application.DoEvents();
                CLS_Pedidos insdetped = new CLS_Pedidos();
                xRow = dtgValVentaExistencia.GetVisibleRowHandle(i);
                insdetped.PrePedidosId = PrePedidosId;
                insdetped.ArticuloCodigo = dtgValVentaExistencia.GetRowCellValue(xRow, "Codigo").ToString();
                insdetped.ArticuloDescripcion = dtgValVentaExistencia.GetRowCellValue(xRow, "Descripcion").ToString();
                insdetped.ArticuloCostoReposicion =Convert.ToDecimal(dtgValVentaExistencia.GetRowCellValue(xRow, "CostoReposicion").ToString());
                insdetped.FamiliaNombre = dtgValVentaExistencia.GetRowCellValue(xRow, "Familia").ToString();
                insdetped.VAlmacen = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "AlmacenV").ToString());
                insdetped.EAlmacen = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "AlmacenE").ToString());
                insdetped.VCentro = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CentroV").ToString());
                insdetped.ECentro = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CentroE").ToString());
                insdetped.VApatzingan = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ApatzinganV").ToString());
                insdetped.EApatzingan = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ApatzinganE").ToString());
                insdetped.VCalzada = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CalzadaV").ToString());
                insdetped.ECalzada = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CalzadaE").ToString());
                insdetped.VCostaRica = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CostaRicaV").ToString());
                insdetped.ECostaRica = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CostaRicaE").ToString());
                insdetped.VEstocolmo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "EstocolmoV").ToString());
                insdetped.EEstocolmo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "EstocolmoE").ToString());
                insdetped.VFCoVilla = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "FcoVillaV").ToString());
                insdetped.EFcoVilla = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "FcoVillaE").ToString());
                insdetped.VLombardia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "LombardiaV").ToString());
                insdetped.ELombardia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "LombardiaE").ToString());
                insdetped.VReyes = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ReyesV").ToString());
                insdetped.EReyes = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ReyesE").ToString());
                insdetped.VMorelos = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "MorelosV").ToString());
                insdetped.EMorelos = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "MorelosE").ToString());
                insdetped.VNvaItalia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "NvaItaliaV").ToString());
                insdetped.ENvaItalia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "NvaItaliaE").ToString());
                insdetped.VPaseo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PaseoV").ToString());
                insdetped.EPaseo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PaseoE").ToString());
                insdetped.VSarabiaI = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIV").ToString());
                insdetped.ESarabiaI = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIE").ToString());
                insdetped.VSarabiaII = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIIV").ToString());
                insdetped.ESarabiaII = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIIE").ToString());
                insdetped.TotalV = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TotalV").ToString());
                insdetped.TotalE = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TotalE").ToString());
                insdetped.PIdeal = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PIdeal").ToString());
                insdetped.PSugerido = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PSugerido").ToString());
                insdetped.Pedido = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TPedido").ToString());
                insdetped.MtdInsertPrePedidoDetalleProveedor();
                if(!insdetped.Exito)
                {
                    XtraMessageBox.Show(insdetped.Mensaje, "Error al guardar el Registro");
                }
            }
        }

        private void EliminarPedido()
        {
            CLS_Pedidos delped = new CLS_Pedidos();
            delped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
            delped.MtdEliminarPrePedidoProveedor();
        }
        public void OcultarBotones()
        {
            btnFolios.Links[0].Visible = false;
            btnBuscarPedidoCerrado.Links[0].Visible = false;
            btnBuscar.Links[0].Visible = false;
            btnGuardar.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
            btnActualizarPedido.Links[0].Visible = false;
            btnCerrarPedido.Links[0].Visible = false;
            btnImpProveedor.Links[0].Visible = false;
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
                        case "5":
                            btnFolios.Links[0].Visible = true;
                            break;
                        case "6":
                            btnBuscarPedidoCerrado.Links[0].Visible = true;
                            break;
                        case "7":
                            btnBuscar.Links[0].Visible = true;
                            break;
                        case "8":
                            btnGuardar.Links[0].Visible = true;
                            break;
                        case "9":
                            btnLimpiar.Links[0].Visible = true;
                            break;
                        case "10":
                            btnActualizarPedido.Links[0].Visible = true;
                            break;
                        case "11":
                            btnCerrarPedido.Links[0].Visible = true;
                            break;
                        case "12":
                            btnImpProveedor.Links[0].Visible = true;
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
            btnFolios.Links[0].Visible = true;
            btnBuscarPedidoCerrado.Links[0].Visible = true;
            btnBuscar.Links[0].Visible = true;
            btnGuardar.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
            btnActualizarPedido.Links[0].Visible = true;
            btnCerrarPedido.Links[0].Visible = true;
            btnImpProveedor.Links[0].Visible = true;
        }

        private void Frm_ReportePedidos_Load(object sender, EventArgs e)
        {
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

        private void btnFolios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Pre_Pedidos_Buscar frmpro = new Frm_Pre_Pedidos_Buscar();
            frmpro.FrmReportePedidos = this;
            frmpro.ShowDialog();
        }
    }
}