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
    public partial class Frm_ReportePedidos : DevExpress.XtraEditors.XtraForm
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


        public string GusuariosLogin;
        public char GusuariosClase;

        public Frm_ReportePedidos()
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
            column.ColumnName = "Column1";
            column.AutoIncrement = false;
            column.Caption = "Codigo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column2";
            column.AutoIncrement = false;
            column.Caption = "Descripcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Column3";
            column.AutoIncrement = false;
            column.Caption = "Costo Reposicion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Column4";
            column.AutoIncrement = false;
            column.Caption = "Familia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column5";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column6";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column7";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column8";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column9";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column10";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column11";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column12";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column13";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column14";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column15";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column16";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column17";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column18";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column19";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column20";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column21";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column22";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column23";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column24";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column25";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column26";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column27";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column28";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column29";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column30";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column31";
            column.AutoIncrement = false;
            column.Caption = "V";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column32";
            column.AutoIncrement = false;
            column.Caption = "E";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column33";
            column.AutoIncrement = false;
            column.Caption = "TotalV";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column34";
            column.AutoIncrement = false;
            column.Caption = "TotalE";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column35";
            column.AutoIncrement = false;
            column.Caption = "Pedido Ideal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column36";
            column.AutoIncrement = false;
            column.Caption = "Pedido Sugerido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column37";
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
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn3.DisplayFormat.FormatString = "$ ###,###0.00";
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
            gridColumn6.Visible = Mostrar;
            gridColumn8.Visible = Mostrar;
            gridColumn10.Visible = Mostrar;
            gridColumn12.Visible = Mostrar;
            gridColumn14.Visible = Mostrar;
            gridColumn16.Visible = Mostrar;
            gridColumn18.Visible = Mostrar;
            gridColumn20.Visible = Mostrar;
            gridColumn22.Visible = Mostrar;
            gridColumn24.Visible = Mostrar;
            gridColumn26.Visible = Mostrar;
            gridColumn28.Visible = Mostrar;
            gridColumn30.Visible = Mostrar;
            gridColumn32.Visible = Mostrar;
        }
        private void ColumnsCosto(Boolean Mostrar)
        {
            gridColumn3.Visible = Mostrar;
        }
        private void ColumnsFamilia(Boolean Mostrar)
        {
            gridColumn4.Visible = Mostrar;
        }
        private void ColumnsVentas(Boolean Mostrar)
        {
            gridColumn5.Visible = Mostrar;
            gridColumn7.Visible = Mostrar;
            gridColumn9.Visible = Mostrar;
            gridColumn11.Visible = Mostrar;
            gridColumn13.Visible = Mostrar;
            gridColumn15.Visible = Mostrar;
            gridColumn19.Visible = Mostrar;
            gridColumn21.Visible = Mostrar;
            gridColumn23.Visible = Mostrar;
            gridColumn25.Visible = Mostrar;
            gridColumn27.Visible = Mostrar;
            gridColumn29.Visible = Mostrar;
            gridColumn31.Visible = Mostrar;
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
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column1"], ArticuloCodigo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column2"], ArticuloDescripcion);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column3"], ArticuloCostoReposicion);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column4"], FamiliaNombre);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column5"], VAlmacen);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column6"], EAlmacen);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column7"], VCentro);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column8"], ECentro);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column9"], VMorelos);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column10"], EMorelos);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column11"], VFCoVilla);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column12"], EFcoVilla);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column13"], VSarabiaI);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column14"], ESarabiaI);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column15"], VSarabiaII);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column16"], ESarabiaII);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column17"], VPaseo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column18"], EPaseo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column19"], VEstocolmo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column20"], EEstocolmo);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column21"], VCostaRica);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column22"], ECostaRica);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column23"], VCalzada);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column24"], ECalzada);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column25"], VLombardia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column26"], ELombardia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column27"], VNvaItalia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column28"], ENvaItalia);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column29"], VApatzingan);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column30"], EApatzingan);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column31"], VReyes);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column32"], EReyes);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column33"], TotalV);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column34"], TotalE);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column35"], PIdeal);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column36"], PSugerido);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column37"], TPedido);
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
                        string Sugerido = dtgValVentaExistencia.GetRowCellValue(xRow, "Column36").ToString();
                        dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["Column37"], Sugerido);
                    }
                    XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                XtraMessageBox.Show("Es necesario generar un pedido", "No Existe Pedido Generado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        public void llenarusuario(string usuario, char clase)
        {
            GusuariosLogin = usuario;
            GusuariosClase = clase;
        }

        public void controlbotones()
        {
            CLS_Pantallas clspantbotones = new CLS_Pantallas();
            clspantbotones.UsuariosLogin = GusuariosLogin;
            clspantbotones.pantallasid = 2;
            clspantbotones.Mtdselecionarbotonespantalla();
            if (clspantbotones.Exito.ToString() == "True")
            {
                int t;
                for (t = 0; t < clspantbotones.Datos.Rows.Count; t++)
                {
                    switch (clspantbotones.Datos.Rows[t][0].ToString())
                    {
                        case "5":
                            btnFolios.Enabled = true;
                            break;
                        case "6":
                            barLargeButtonItem6.Enabled = true;
                            break;
                        case "7":
                            btnBuscar.Enabled = true;
                            break;
                        case "8":
                            barLargeButtonItem3.Enabled = true;
                            break;
                        case "9":
                            btnLimpiar.Enabled = true;
                            break;
                        case "10":
                            barLargeButtonItem5.Enabled = true;
                            break;
                        case "11":
                            barLargeButtonItem4.Enabled = true;
                            break;
                        case "12":
                            btnImpProveedor.Enabled = true;
                            break;
                    }
                }

            }
            else
            {

            }
        }

        public void accesosuperusuario()
        {
            btnFolios.Enabled = true;
            barLargeButtonItem6.Enabled = true;
            btnBuscar.Enabled = true;
            barLargeButtonItem3.Enabled = true;
            btnLimpiar.Enabled = true;
            barLargeButtonItem5.Enabled = true;
            barLargeButtonItem4.Enabled = true;
            btnImpProveedor.Enabled = true;
        }

        private void Frm_ReportePedidos_Load(object sender, EventArgs e)
        {
            if (GusuariosClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                controlbotones();
            }
        }
    }
}