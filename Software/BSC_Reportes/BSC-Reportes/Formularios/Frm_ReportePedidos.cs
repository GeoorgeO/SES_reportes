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
            column.Caption = "TSugerido";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Column36";
            column.AutoIncrement = false;
            column.Caption = "TPedido";
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
        private void btnImportar_Click(object sender, EventArgs e)
        {
           
        }
        private void txtProveedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
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
            rdbTipo.SelectedIndex = 0;
            dtgVentaExistencia.DataSource = null;
            MakeTablaPedidos();
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValVentaExistencia.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValVentaExistencia.OptionsSelection.MultiSelect = true;
            dtgValVentaExistencia.OptionsView.ShowGroupPanel = false;
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn3.DisplayFormat.FormatString = "$ ###,###0.00";
        }
        private void rdbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdbTipo.SelectedIndex==0)
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
            gridColumn5.Visible = Mostrar;
            gridColumn7.Visible = Mostrar;
            gridColumn9.Visible = Mostrar;
            gridColumn11.Visible = Mostrar;
            gridColumn13.Visible = Mostrar;
            gridColumn15.Visible = Mostrar;
            gridColumn17.Visible = Mostrar;
            gridColumn19.Visible = Mostrar;
            gridColumn21.Visible = Mostrar;
            gridColumn23.Visible = Mostrar;
            gridColumn25.Visible = Mostrar;
            gridColumn27.Visible = Mostrar;
            gridColumn29.Visible = Mostrar;
            gridColumn31.Visible = Mostrar;
        }
        private void ColumnsVentas(Boolean Mostrar)
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
        }
        private void chkVentas_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVentas.Checked==true)
            {
                ColumnsBands(true);
                ColumnsVentas(true);
            }
            else if(chkVentas.Checked == false)
            {
                ColumnsVentas(false);
            }
            if(chkVentas.Checked == false && chkExistencia.Checked == false)
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
                }
            }
        }
        private void CreatNewRowCalibres(string ArticuloCodigo,string ArticuloDescripcion,string ArticuloCostoReposicion,string FamiliaNombre,string VAlmacen, string EAlmacen,
                                    string VCentro, string ECentro, string VMorelos, string EMorelos, string VFCoVilla, string EFcoVilla, string VSarabiaI,string ESarabiaI,
                                    string VSarabiaII, string ESarabiaII, string VPaseo, string EPaseo, string VEstocolmo, string EEstocolmo, string VCostaRica, string ECostaRica,
                                    string VCalzada, string ECalzada, string VLombardia, string ELombardia, string VNvaItalia, string ENvaItalia, string VApatzingan, string EApatzingan,
                                    string VReyes, string EReyes,string TotalV,string TotalE, string TPedido,string PSugerido)
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
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column35"], PSugerido);
                dtgValVentaExistencia.SetRowCellValue(rowHandle, dtgValVentaExistencia.Columns["Column36"], TPedido);
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtProveedorId.Text!=string.Empty)
            {
                if (Convert.ToInt32(txtProveedorId.Text) > 0)
                {
                    DateTime dInicio = Convert.ToDateTime(dtInicio.EditValue);
                    DateTime dFin = Convert.ToDateTime(dtFin.EditValue);
                    int result = DateTime.Compare(dInicio, dFin);
                    if(result<1)
                    {
                        //if()
                        MensajeCargando(1);
                        CLS_Pedidos selped = new CLS_Pedidos();
                        DateTime FInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
                        DateTime FFin = Convert.ToDateTime(dtFin.EditValue.ToString());

                        selped.FechaInicio = string.Format("{0}{1}{2} 00:00:00", FInicio.Year, DosCeros(FInicio.Month.ToString()), DosCeros(FInicio.Day.ToString()));
                        selped.FechaFin = string.Format("{0}{1}{2} 23:59:59", FFin.Year, DosCeros(FFin.Month.ToString()), DosCeros(FFin.Day.ToString()));
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
                        XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un proveedor");
            }
        }

        private void CargandoPedido(DataTable datos)
        {
            for (int x = 0; x < datos.Rows.Count; x++)
            {

            }
        }
    }
}