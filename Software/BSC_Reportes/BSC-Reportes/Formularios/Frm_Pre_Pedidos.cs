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

        public string vArticuloCodigo { get;  set; }
        public string vArticuloDescripcion { get;  set; }
        public string vArticuloCostoReposicion { get; private set; }
        public string vFamiliaNombre { get; private set; }
        public int VAlmacen { get; private set; }
        public int VApatzingan { get; private set; }
        public int VCalzada { get; private set; }
        public int VCentro { get; private set; }
        public int VCostaRica { get; private set; }
        public int VEstocolmo { get; private set; }
        public int VFcoVilla { get; private set; }
        public int VLombardia { get; private set; }
        public int VLosReyes { get; private set; }
        public int VMorelos { get; private set; }
        public int VNvaItalia { get; private set; }
        public int VPaseo { get; private set; }
        public int VSarabiaI { get; private set; }
        public int VSarabiaII { get; private set; }
        public decimal mesesT { get; private set; }
        public decimal sugerido { get; private set; }
        public decimal Ideal { get; private set; }
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int PrePedidosId { get; private set; }
        public int xRow { get; private set; }
        public int IdPantallaBotones { get; set; }
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
        public string TVentas { get; private set; }
        public string TExistencia { get; private set; }
        public string PIdeal { get; private set; }
        public string PSugerido { get; private set; }
        public int vTPedido { get; private set; }
        public int VTotal { get; private set; }
        public decimal DAlmacen { get; set; }
        public decimal DCentro { get; private set; }
        public decimal DApatzingan { get; private set; }
        public decimal DCalzada { get; private set; }
        public decimal DCostaRica { get; private set; }
        public decimal DEstocolmo { get; private set; }
        public decimal DFcoVilla { get; private set; }
        public decimal DLombardia { get; private set; }
        public decimal DLosReyes { get; private set; }
        public decimal DMorelos { get; private set; }
        public decimal DNvaItalia { get; private set; }
        public decimal DPaseo { get; private set; }
        public decimal DSarabiaI { get; private set; }
        public decimal DSarabiaII { get; private set; }

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
            column.ColumnName = "Reg";
            column.AutoIncrement = false;
            column.Caption = "#";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

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
            txtFolio.Text = string.Empty;
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
            DesbloquearObjetos(true);
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
            DesbloquearObjetos(true);
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
        private void CreatNewRowArticulo(string Reg,string ArticuloCodigo, string ArticuloDescripcion, string ArticuloCostoReposicion, string FamiliaNombre, string VAlmacen, string EAlmacen,
                                    string VCentro, string ECentro, string VMorelos, string EMorelos, string VFCoVilla, string EFcoVilla, string VSarabiaI, string ESarabiaI,
                                    string VSarabiaII, string ESarabiaII, string VPaseo, string EPaseo, string VEstocolmo, string EEstocolmo, string VCostaRica, string ECostaRica,
                                    string VCalzada, string ECalzada, string VLombardia, string ELombardia, string VNvaItalia, string ENvaItalia, string VApatzingan, string EApatzingan,
                                    string VReyes, string EReyes, string TotalV, string TotalE, string TPedido, string PSugerido, string PIdeal)
        {
            dtgValVentaExistencia.AddNewRow();

            int rowHandle = dtgValVentaExistencia.GetRowHandle(dtgValVentaExistencia.DataRowCount);
            if (dtgValVentaExistencia.IsNewItemRow(rowHandle))
            {
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Reg"], Reg);
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

            if (txtProveedorId.Text != string.Empty)
            {
                if (!ExistenPrePedidos(txtProveedorId.Text))
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
                                            dtgVentaExistencia.DataSource = selped.Datos;
                                            CargandoPedido();
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
                    XtraMessageBox.Show("Existe Pedido pendiente con este proveedor.\nNo se puede generar un nuevo pedido hasta no finalizar o eliminar este pedido");
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un proveedor");
            }
        }
        private bool ExistenPrePedidos(string vProveedorId)
        {
            Boolean Valor = false;
            CLS_Pedidos selexi = new CLS_Pedidos();
            selexi.ProveedorId = Convert.ToInt32(vProveedorId);
            selexi.PrePedidoCerrado = 0;
            selexi.PrePedidosCancelado = 0;
            if (Convert.ToInt32(selexi.MtdExistePedidoProveedor()) > 0)
            {
                Valor = true;
            }
            return Valor;
        }
        private void CargandoPedido()
        {
            int TVentas = 0;
            int TExistencia = 0;
            pbProgreso.Properties.Maximum = dtgValVentaExistencia.RowCount;

            for (int x = 0; x < dtgValVentaExistencia.RowCount; x++)
            {
                int xRow = dtgValVentaExistencia.GetVisibleRowHandle(x);
                pbProgreso.Position = x + 1;
                Application.DoEvents();
                TVentas = 0;
                TExistencia = 0;
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "AlmacenV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "AlmacenE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CentroV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CentroE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ApatzinganV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ApatzinganE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CalzadaV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CalzadaE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CostaRicaV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CostaRicaE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "EstocolmoV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "EstocolmoE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "FcoVillaV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "FcoVillaE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "LombardiaV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "LombardiaE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ReyesV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ReyesE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "MorelosV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "MorelosE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "NvaItaliaV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "NvaItaliaE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PaseoV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PaseoE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIE").ToString());
                TVentas += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIIV").ToString());
                TExistencia += Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIIE").ToString());

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

                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["Reg"], x + 1);
                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["TotalV"], TVentas);
                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["TotalE"], TExistencia);
                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["PIdeal"], Ideal);
                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["PSugerido"], sugerido);
                dtgValVentaExistencia.SetRowCellValue(xRow, dtgValVentaExistencia.Columns["TPedido"], 0);
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
            GuardarPrepedido();
            MensajeCargando(2);
            
        }

        private void DesbloquearObjetos(Boolean Valor)
        {
            txtFolio.Enabled = Valor;
            dtInicio.Enabled = Valor;
            dtFin.Enabled = Valor;
            txtProveedorId.Enabled = Valor;
            txtProveedorNombre.Enabled = Valor;
            txtPeriodo.Enabled = Valor;
        }

        private void GuardarPrepedido()
        {
            if (txtFolio.Text != string.Empty || dtgValVentaExistencia.RowCount > 0)
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
                if (txtFolio.Text == string.Empty)
                {
                    insped.MtdInsertPrePedidoProveedor();
                    if (insped.Exito)
                    {
                        if (insped.Datos.Rows.Count > 0)
                        {
                            txtFolio.Text = insped.Datos.Rows[0][0].ToString();
                            PrePedidosId = Convert.ToInt32(insped.Datos.Rows[0][0].ToString());
                            GuardarDetalles();
                            DesbloquearObjetos(false);
                            XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        }
                    }
                }
                else
                {
                    insped.PrePedidosId = PrePedidosId;
                    insped.MtdUpdatePrePedidoProveedor();
                    if (insped.Exito)
                    {
                        if (insped.Datos.Rows.Count > 0)
                        {
                            PrePedidosId = Convert.ToInt32(txtFolio.Text);
                            UpdateDetalles();
                            DesbloquearObjetos(false);
                            XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha Cargado o Generado Pedido", "Cargar o Generar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                insdetped.Reg= Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "Reg").ToString());
                insdetped.ArticuloCodigo = dtgValVentaExistencia.GetRowCellValue(xRow, "Codigo").ToString();
                insdetped.ArticuloDescripcion = dtgValVentaExistencia.GetRowCellValue(xRow, "Descripcion").ToString();
                insdetped.ArticuloCostoReposicion = Convert.ToDecimal(dtgValVentaExistencia.GetRowCellValue(xRow, "CostoReposicion").ToString());
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
                if (!insdetped.Exito)
                {
                    XtraMessageBox.Show(insdetped.Mensaje, "Error al guardar el Registro");
                }
            }
        }
        private void UpdateDetalles()
        {
            pbProgreso.Properties.Maximum = dtgValVentaExistencia.RowCount;
            for (int i = 0; i < dtgValVentaExistencia.RowCount; i++)
            {
                pbProgreso.Position = i + 1;
                Application.DoEvents();
                CLS_Pedidos insdetped = new CLS_Pedidos();
                xRow = dtgValVentaExistencia.GetVisibleRowHandle(i);
                insdetped.PrePedidosId = PrePedidosId;
                insdetped.Reg =Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "Reg").ToString());
                insdetped.ArticuloCodigo = dtgValVentaExistencia.GetRowCellValue(xRow, "Codigo").ToString();
                insdetped.ArticuloDescripcion = dtgValVentaExistencia.GetRowCellValue(xRow, "Descripcion").ToString();
                insdetped.Pedido = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TPedido").ToString());
                insdetped.MtdUpdatePrePedidoDetalleProveedor();
                if (!insdetped.Exito)
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
            //btnBuscarPedidoCerrado.Links[0].Visible = false;
            btnBuscar.Links[0].Visible = false;
            btnGuardar.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
            btnActualizarPedido.Links[0].Visible = false;
            btnCerrarPedido.Links[0].Visible = false;
            btnImpProveedor.Links[0].Visible = false;
            btnCancelar.Links[0].Visible = false;
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
                            btnCancelar.Links[0].Visible = true;
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
            //btnBuscarPedidoCerrado.Links[0].Visible = true;
            btnBuscar.Links[0].Visible = true;
            btnGuardar.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
            btnActualizarPedido.Links[0].Visible = true;
            btnCerrarPedido.Links[0].Visible = true;
            btnImpProveedor.Links[0].Visible = true;
            btnCancelar.Links[0].Visible = true;
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
            DialogResult = XtraMessageBox.Show("¿Desea cargar un pedido, perdera los datos no guardados?\nLos cambios no se podran revertir", "Igualar sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                btnLimpiar.PerformClick();
                Frm_Pre_Pedidos_Buscar frmpro = new Frm_Pre_Pedidos_Buscar();
                frmpro.FrmReportePedidos = this;
                frmpro.ShowDialog();
                if (txtFolio.Text != string.Empty)
                {
                    CargarPrePedidos(txtFolio.Text);
                    DesbloquearObjetos(false);
                }
                else
                {
                    DesbloquearObjetos(true);
                }
            }
        }

        private void CargarPrePedidos(string vFolio)
        {
            CLS_Pedidos selenc = new CLS_Pedidos();
            selenc.PrePedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSeleccionarPrePedidosId();
            if (selenc.Exito)
            {
                dtInicio.DateTime = Convert.ToDateTime(selenc.Datos.Rows[0]["FechaInicio"]);
                dtFin.DateTime = Convert.ToDateTime(selenc.Datos.Rows[0]["FechaFin"]);
                txtProveedorId.Text = selenc.Datos.Rows[0]["ProveedorId"].ToString();
                txtProveedorNombre.Text = selenc.Datos.Rows[0]["ProveedorNombre"].ToString();
                txtPeriodo.Text = selenc.Datos.Rows[0]["PeriodoPedido"].ToString();
                if (selenc.Datos.Rows[0]["PeriodoTipo"].ToString() == "1")
                {
                    rdbPeriodo.SelectedIndex = 0;
                }
                else if (selenc.Datos.Rows[0]["PeriodoTipo"].ToString() == "2")
                {
                    rdbPeriodo.SelectedIndex = 1;
                }
                else if (selenc.Datos.Rows[0]["PeriodoTipo"].ToString() == "3")
                {
                    rdbPeriodo.SelectedIndex = 2;
                }
                CargarPrePedidosDetalles(vFolio);
            }
        }

        private void CargarPrePedidosDetalles(string vFolio)
        {
            MensajeCargando(1);
            CLS_Pedidos selenc = new CLS_Pedidos();
            selenc.PrePedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSeleccionarPrePedidosDetalles();
            if (selenc.Exito)
            {
                dtgVentaExistencia.DataSource = selenc.Datos;
            }
            MensajeCargando(2);
            XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                DialogResult = XtraMessageBox.Show("¿Desea Cancelar el pedido, perdera todos datos ?\nLos cambios no se podran revertir", "Cancelar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_Pedidos canpre = new CLS_Pedidos();
                    canpre.PrePedidosId = Convert.ToInt32(txtFolio.Text);
                    canpre.MtdUpdatePrePedidoCancelarProveedor();
                    btnLimpiar.PerformClick();
                    XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                XtraMessageBox.Show("Generado un Folio de Pedido", "Generar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnActualizarPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                CargarPrePedidos(txtFolio.Text);
            }
            else
            {
                XtraMessageBox.Show("No se ha Cargado o Generado un Folio de Pedido", "Cargar o Generar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnCerrarPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CerrarEncabezado();
                CalcularDistribucion();
                CerrarPedido();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void CerrarEncabezado()
        {
            CLS_Pedidos insped = new CLS_Pedidos();
            insped.ProveedorId = Convert.ToInt32(txtProveedorId.Text);
            insped.PrePedidosId = Convert.ToInt32(txtFolio.Text);
            insped.MtdInsertPedidoProveedor();
            if (!insped.Exito)
            {
                XtraMessageBox.Show(insped.Mensaje, "Error al guardar el Registro");
            }
        }

        private void CerrarPedido()
        {
            CLS_Pedidos insped = new CLS_Pedidos();
            insped.PrePedidosId = Convert.ToInt32(txtFolio.Text);
            insped.MtdUpdatePedidoCerrarProveedor();
            if (!insped.Exito)
            {
                XtraMessageBox.Show(insped.Mensaje, "Error al guardar el Registro");
            }
        }

        private void CalcularDistribucion()
        {
            pbProgreso.Properties.Maximum = dtgValVentaExistencia.RowCount;
            for (int i = 0; i < dtgValVentaExistencia.RowCount; i++)
            {
                
                pbProgreso.Position = i + 1;
                Application.DoEvents();
                if (Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TPedido").ToString()) > 0)
                {
                    if (Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TotalV").ToString())>0)
                    {
                        int TotalDistribucion = 0;
                        CLS_Pedidos insdetped = new CLS_Pedidos();
                        xRow = dtgValVentaExistencia.GetVisibleRowHandle(i);
                        insdetped.PrePedidosId = PrePedidosId;
                        vArticuloCodigo = dtgValVentaExistencia.GetRowCellValue(xRow, "Codigo").ToString();
                        VTotal = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TotalV").ToString());
                        VAlmacen = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "AlmacenV").ToString());
                        vTPedido = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TPedido").ToString());
                        DAlmacen = Math.Round(((Convert.ToDecimal(VAlmacen) / VTotal) * vTPedido),0);
                        TotalDistribucion += Convert.ToInt32(DAlmacen);
                        VCentro = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CentroV").ToString());
                        DCentro = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DCentro);
                        VApatzingan = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ApatzinganV").ToString());
                        DApatzingan = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VCalzada = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CalzadaV").ToString());
                        DCalzada = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VCostaRica = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "CostaRicaV").ToString());
                        DCostaRica = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VEstocolmo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "EstocolmoV").ToString());
                        DEstocolmo = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VFcoVilla = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "FcoVillaV").ToString());
                        DFcoVilla = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VLombardia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "LombardiaV").ToString());
                        DLombardia = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VLosReyes = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "ReyesV").ToString());
                        DLosReyes = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VMorelos = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "MorelosV").ToString());
                        DMorelos = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VNvaItalia = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "NvaItaliaV").ToString());
                        DNvaItalia = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VPaseo = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "PaseoV").ToString());
                        DPaseo = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VSarabiaI = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIV").ToString());
                        DSarabiaI = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        VSarabiaII = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "SarabiaIIV").ToString());
                        DSarabiaII = Math.Round(((Convert.ToDecimal(VCentro) / VTotal) * vTPedido), 0);
                        TotalDistribucion += Convert.ToInt32(DApatzingan);
                        if(!(TotalDistribucion== vTPedido))
                        {

                        }
                        
                        if (!insdetped.Exito)
                        {
                            XtraMessageBox.Show(insdetped.Mensaje, "Error al guardar el Registro");
                        }
                    }
                    else
                    {
                        Frm_DistribucionManual frmdis = new Frm_DistribucionManual();
                        frmdis.CodigoArticulo= dtgValVentaExistencia.GetRowCellValue(xRow, "Codigo").ToString();
                        frmdis.ArticuloDescripcion = dtgValVentaExistencia.GetRowCellValue(xRow, "Descripcion").ToString();
                        frmdis.Folio =Convert.ToInt32(txtFolio.Text);
                        frmdis.TPedido = Convert.ToInt32(dtgValVentaExistencia.GetRowCellValue(xRow, "TPedido").ToString();
                        frmdis.NombreProveedor = txtProveedorNombre.Text;
                        frmdis.ShowDialog();
                    }
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dtgValVentaExistencia.RowCount > 0)
            {
                Frm_AgregarArticulo frmadd = new Frm_AgregarArticulo();
                frmadd.FrmPrePedidos = this;
                frmadd.ShowDialog();
                if (vArticuloCodigo != string.Empty && vArticuloDescripcion != string.Empty)
                {
                    string Reg = (dtgValVentaExistencia.RowCount + 1).ToString();
                    CreatNewRowArticulo(Reg,vArticuloCodigo, vArticuloDescripcion, "0", "No Definida", "0",
                                            "0", "0", "0", "0", "0", "0", "0", "0",
                                            "0", "0", "0", "0", "0", "0", "0", "0",
                                            "0", "0", "0", "0", "0", "0", "0", "0",
                                            "0", "0", "0", "0", "0", "0", "0", "0");
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha Cargado o Generado Pedido", "Cargar o Generar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
