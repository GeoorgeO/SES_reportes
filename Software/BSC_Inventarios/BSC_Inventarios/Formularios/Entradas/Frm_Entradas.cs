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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using System.IO;

namespace BSC_Inventarios
{
    public partial class Frm_Entradas : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public Frm_Entradas()
        {
            InitializeComponent();
        }
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");
        private static Frm_Entradas m_FormDefInstance;
        public static Frm_Entradas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Entradas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public string vCostoUltimo { get;  set; }
        public string vCostoPromedio { get;  set; }
        public string vDetallesPrecioVenta { get;  set; }
        public string vCostoReposicion { get;  set; }
        public string vDetallesPrecioVentaImporte { get;  set; }
        public string vCostoAdquisicion { get;  set; }
        public bool PrimeraEdicion { get; private set; }
        public int v_Sucursalnum { get; private set; }

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
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloCantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloCosto";
            column.AutoIncrement = false;
            column.Caption = "Costo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloSub0";
            column.AutoIncrement = false;
            column.Caption = "Sub0";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloSub16";
            column.AutoIncrement = false;
            column.Caption = "Sub16";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloTotal";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloTotalLinea";
            column.AutoIncrement = false;
            column.Caption = "TotalLinea";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ArticuloCostoAdquisicion";
            column.AutoIncrement = false;
            column.Caption = "CostoAdquisicion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgArticulosEntrada.DataSource = table;
        }
        private void CreatNewRowArticulo(string Numero, string ArticuloCodigo, string ArticuloDescripcion, string ArticuloCosto, string ArticuloCantidad, string ArticuloSub0, string ArticuloSub16,
                                    string ArticuloTotal, string ArticuloTotalLinea,string ArticuloCostoAdquisicion)
        {
            dtgValArticuloEntrada.AddNewRow();
            int rowHandle = dtgValArticuloEntrada.GetRowHandle(dtgValArticuloEntrada.DataRowCount);
            if (dtgValArticuloEntrada.IsNewItemRow(rowHandle))
            {
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["Numero"], Numero);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloCodigo"], ArticuloCodigo);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloDescripcion"], ArticuloDescripcion);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloCosto"], ArticuloCosto);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloCantidad"], ArticuloCantidad);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloSub0"],ArticuloSub0);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloSub16"],ArticuloSub16);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloTotal"],ArticuloTotal);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloTotalLinea"],ArticuloTotalLinea);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloCostoAdquisicion"],ArticuloTotalLinea);
                dtgValArticuloEntrada.SetRowCellValue(rowHandle, dtgValArticuloEntrada.Columns["ArticuloCostoAdquisicion"],ArticuloCostoAdquisicion);
            }
        }
        private void NumerarReg()
        {
            for (int x = 0; x < dtgValArticuloEntrada.RowCount; x++)
            {
                int xRow = dtgValArticuloEntrada.GetVisibleRowHandle(x);
                dtgValArticuloEntrada.SetRowCellValue(xRow, dtgValArticuloEntrada.Columns["Reg"], x + 1);
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
        private void Frm_Entradas_Shown(object sender, EventArgs e)
        {
            MakeTablaPedidos();
            CargarSucursales();
            CargarTipoEntradas(1);
            CargarResponsable(UsuariosLogin);
            LimpiarCampos();
            FormatoDeColumnas();
            FormatoDeCampos();
        }

        private void FormatoDeCampos()
        {
            txtSubtotal0.Properties.Mask.MaskType = MaskType.Custom;
            txtSubtotal0.Properties.Mask.EditMask = "$ ###,###0.0000";
            txtSubtotal0.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtSubTotal16.Properties.Mask.MaskType = MaskType.Custom;
            txtSubTotal16.Properties.Mask.EditMask = "$ ###,###0.0000";
            txtSubTotal16.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTotal.Properties.Mask.MaskType = MaskType.Custom;
            txtTotal.Properties.Mask.EditMask = "$ ###,###0.0000";
            txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void FormatoDeColumnas()
        {
            gCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gCosto.DisplayFormat.FormatString = "$ ###,###0.0000";
            gSub0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gSub0.DisplayFormat.FormatString = "$ ###,###0.0000";
            gSub16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gSub16.DisplayFormat.FormatString = "$ ###,###0.0000";
            gTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gTotal.DisplayFormat.FormatString = "$ ###,###0.0000";
            gTotalLinea.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gTotalLinea.DisplayFormat.FormatString = "$ ###,###0.0000";
        }

        private void CargarTipoEntradas(int? Valor)
        {
            CLS_Entradas conTEntrada = new CLS_Entradas();
            conTEntrada.MtdSeleccionarTipoEntrada();
            if (conTEntrada.Exito)
            {
                cboTipoMovimiento.Properties.DisplayMember = "TipoDescripcion";
                cboTipoMovimiento.Properties.ValueMember = "TipoId";
                cboTipoMovimiento.EditValue = Valor;
                cboTipoMovimiento.Properties.DataSource = conTEntrada.Datos;
            }
        }

        private void CargarResponsable(string vUsuariosLogin)
        {
            CLS_Entradas sel = new CLS_Entradas();
            sel.UsuariosLogin = vUsuariosLogin;
            sel.MtdSeleccionarResponsable();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    txtResponsable.Text = sel.Datos.Rows[0]["UsuariosNombre"].ToString();
                    txtResponsable.Tag = sel.Datos.Rows[0]["UsuariosId"].ToString();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtFolio.Text = string.Empty;
            dtFecha.DateTime = DateTime.Now;
            txtTotalArticulos.Text = "0";
            txtSubtotal0.Text = "0";
            txtSubTotal16.Text = "0";
            txtTotal.Text = "0";
            txtObservaciones.Text = string.Empty;
            txtReferencias.Text = string.Empty;
            txtCantidad.Enabled = false;
            dtgArticulosEntrada.DataSource = null;
            gridColumn4.OptionsColumn.AllowEdit = true;
            MakeTablaPedidos();
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

        private void dtgArticulosEntrada_DoubleClick(object sender, EventArgs e)
        {
            if (dtgValArticuloEntrada.RowCount > 0)
            {
                try
                {
                    DialogResult = XtraMessageBox.Show("¿Desea Eliminar este articulo de la Entrada?", "Elimnar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (DialogResult == DialogResult.Yes)
                    {
                        dtgValArticuloEntrada.DeleteRow(dtgValArticuloEntrada.FocusedRowHandle);
                        CalculaNumRegistros();
                        CalculaTotalesRegistros();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CalculaNumRegistros()
        {
            for (int i = 0; i < dtgValArticuloEntrada.RowCount; i++)
            {
                int xRow = dtgValArticuloEntrada.GetVisibleRowHandle(i);
                dtgValArticuloEntrada.SetRowCellValue(xRow, dtgValArticuloEntrada.Columns["Numero"], i + 1);
            }
        }
        private void CalculaTotalesRegistros()
        {
            decimal vCantidad = 0;
            decimal vSub0 = 0;
            decimal vSub16 = 0;
            decimal vTotal = 0;
            for (int i = 0; i < dtgValArticuloEntrada.RowCount; i++)
            {
                int xRow = dtgValArticuloEntrada.GetVisibleRowHandle(i);
                vCantidad += Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
                vSub0 += Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloSub0"]).ToString())* Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
                vSub16 += Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloSub16"]).ToString())*Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
                vTotal += Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloTotal"]).ToString())* Convert.ToDecimal(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
            }
            txtTotalArticulos.Text = vCantidad.ToString();
            txtSubtotal0.Text = vSub0.ToString();
            txtSubTotal16.Text = vSub16.ToString();
            txtTotal.Text = vTotal.ToString();
        }
        private void chkCaptura_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Enabled = false;
            if (chkCaptura.Checked==true)
            {
                txtCantidad.Text = "1";
                txtCodigo.Focus();
            }
            else
            {
                txtCantidad.Text = "0";
                txtCodigo.Focus();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtCodigo.Text==string.Empty && e.KeyValue==13)
            {
                Frm_Articulos_Buscar sel = new Frm_Articulos_Buscar();
                sel.ShowDialog();
                txtCodigo.Text = sel.vArticuloCodigo;
                txtDescripcion.Text = sel.vArticuloDescripcion;
                BuscarCodigo();
            }
            else if(txtCodigo.Text != string.Empty && e.KeyValue == 13)
            {
                BuscarCodigo();
            }
            if (txtCodigo.Text != string.Empty && txtDescripcion.Text != string.Empty)
            {
                if (chkCaptura.Checked == true)
                {
                    txtCantidad.Enabled = false;
                    txtCantidad.Text = "1";
                    if(!ExisteCodigo())
                    {
                        AgregarArticuloGrid();
                    }
                }
                else
                {
                    txtCantidad.Enabled = true;
                    txtCantidad.Focus();
                }
            }
        }

        private bool ExisteCodigo()
        {
            Boolean Valor = false;
            for (int x = 0; x < dtgValArticuloEntrada.RowCount; x++)
            {
                int xRow = dtgValArticuloEntrada.GetVisibleRowHandle(x);
                string ArticuloCodigo = dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCodigo"]).ToString();
                if(txtCodigo.Text.TrimEnd()==ArticuloCodigo.TrimEnd())
                {
                    string ArticuloCantidad = dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString();
                    int vCantidad = Convert.ToInt32(ArticuloCantidad) + Convert.ToInt32(txtCantidad.Text);
                    dtgValArticuloEntrada.SetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"], vCantidad);
                    Valor = true;
                    txtCodigo.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCantidad.Text = "0";
                    txtCodigo.Focus();
                    CalculaTotalesRegistros();
                }
            }
                return Valor;
        }

        private void AgregarArticuloGrid()
        {
            string vNumero = Convert.ToString(dtgValArticuloEntrada.RowCount + 1);
            string vArticuloCodigo = txtCodigo.Text;
            string vArticuloDescripcion = txtDescripcion.Text;
            string vCantidad = txtCantidad.Text;
            string vSub0 = string.Empty;
            string vSub16 = string.Empty;
            string vArticuloCosto = vCostoReposicion;
            if (vDetallesPrecioVenta == vDetallesPrecioVentaImporte)
            {
                vSub0 = vDetallesPrecioVenta;
                vSub16 = "0";
            }
            else
            {
                vSub0 = "0";
                vSub16 = vDetallesPrecioVenta;
            }
            if(Convert.ToDecimal(vCostoAdquisicion)==0)
            {
                vCostoAdquisicion = vCostoReposicion;
            }
            string vTotal = vDetallesPrecioVenta;
            string vTotalLinea = Convert.ToString(Convert.ToDecimal(vDetallesPrecioVenta) * Convert.ToDecimal(vCantidad));
            CreatNewRowArticulo(vNumero, vArticuloCodigo, vArticuloDescripcion, vArticuloCosto, vCantidad, vSub0, vSub16, vTotal, vTotalLinea, vCostoAdquisicion);
            CalculaNumRegistros();
            CalculaTotalesRegistros();
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = "0";
            txtCodigo.Focus();
        }

        private Boolean BuscarCodigo()
        {
            Boolean Valor = false;
            CLS_Articulos sel = new CLS_Articulos();
            sel.ArticuloCodigo = txtCodigo.Text;
            sel.MtdSeleccionarArticulosCodigo();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    txtCodigo.Text = sel.Datos.Rows[0]["ArticuloCodigo"].ToString().TrimEnd();
                    txtDescripcion.Text = sel.Datos.Rows[0]["ArticuloDescripcion"].ToString().TrimEnd();
                    vCostoUltimo= sel.Datos.Rows[0]["ArticuloUltimoCosto"].ToString();
                    vCostoReposicion= sel.Datos.Rows[0]["ArticuloCostoReposicion"].ToString();
                    vCostoPromedio= sel.Datos.Rows[0]["ArticuloCostoPromedio"].ToString();
                    vDetallesPrecioVenta = sel.Datos.Rows[0]["DetallesPreciosVenta"].ToString();
                    vDetallesPrecioVentaImporte = sel.Datos.Rows[0]["DetallesPreciosVentaImporte"].ToString();
                    vCostoAdquisicion = sel.Datos.Rows[0]["CostoAdquisicion"].ToString();
                    Valor = true;
                }
            }
            return Valor;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0)
                {
                    if (!ExisteCodigo())
                    {
                        AgregarArticuloGrid();
                    }
                }
                else
                {
                    XtraMessageBox.Show("La Cantidad debe ser mayor a 0");
                }
            }
        }

        private void dtgValArticuloEntrada_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            string ArticuloTotal = gv.GetRowCellValue(e.RowHandle, gv.Columns["ArticuloTotal"]).ToString();
            string ArticuloCantidad = gv.GetRowCellValue(e.RowHandle, gv.Columns["ArticuloCantidad"]).ToString();
            if (!PrimeraEdicion)
            {
                if (e.Column.FieldName == "ArticuloCantidad" && ArticuloTotal!=string.Empty)
                {
                    PrimeraEdicion = true;
                    decimal vArticuloTotalLinea = Convert.ToDecimal(ArticuloCantidad) * Convert.ToDecimal(ArticuloTotal);
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["ArticuloTotalLinea"], vArticuloTotalLinea);
                    PrimeraEdicion = false;
                }
            }
        }

        
        private void GuardarEntrada()
        {
            CLS_Entradas ins = new CLS_Entradas();
            ins.SucursalesId =Convert.ToInt32(cboSucursales.EditValue.ToString());
            ins.UsuariosId =Convert.ToInt32(txtResponsable.Tag.ToString());
            ins.EntradaMercanciaTipoId = Convert.ToInt32(cboTipoMovimiento.EditValue.ToString());
            ins.EntradaMercanciaUnidades = Convert.ToInt32(txtCantidad.Text);
            ins.EntradaMercanciaSub0 = Convert.ToDecimal(txtSubtotal0.Text);
            ins.EntradaMercanciaSub16 = Convert.ToDecimal(txtSubTotal16.Text);
            decimal vIva = Convert.ToDecimal(txtTotal.Text) - (Convert.ToDecimal(txtSubtotal0.Text) + Convert.ToDecimal(txtSubTotal16.Text));
            ins.EntradaMercanciaIva = vIva;
            ins.EntradaMercanciaTotal= Convert.ToDecimal(txtTotal.Text);
            ins.Observaciones = txtObservaciones.Text;
            ins.Referencias = txtReferencias.Text;
            ins.MtdInsertarEntrada();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    txtFolio.Text = ins.Datos.Rows[0]["EntradaMercanciaId"].ToString();
                    for (int i = 0; i < dtgValArticuloEntrada.RowCount; i++)
                    {
                        int xRow = dtgValArticuloEntrada.GetVisibleRowHandle(i);
                        //Inserta Detalles
                        CLS_Entradas det = new CLS_Entradas();
                        det.EntradasMercanciaId = Convert.ToInt32(ins.Datos.Rows[0]["EntradaMercanciaId"].ToString());
                        det.SucursalesId = Convert.ToInt32(cboSucursales.EditValue.ToString());
                        det.ArticuloCodigo = dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCodigo"]).ToString();
                        det.EntradasMercanciaArticuloUltimoIde = Convert.ToInt32(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["Numero"]).ToString());
                        det.EntradasMercanciaArticuloCantidad = Convert.ToInt32(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
                        decimal ArticuloSub0 = 0;
                        decimal.TryParse(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloSub0"]).ToString(), style, culture, out ArticuloSub0);
                        det.EntradasMercanciaArticuloSub0 = ArticuloSub0;
                        decimal ArticuloSub16 = 0;
                        decimal.TryParse(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloSub16"]).ToString(), style, culture, out ArticuloSub16);
                        det.EntradasMercanciaArticuloSub16 = ArticuloSub16;
                        decimal ArticuloTotal = 0;
                        decimal.TryParse(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloTotal"]).ToString(), style, culture, out ArticuloTotal);
                        det.EntradasMercanciaArticuloTotal = ArticuloTotal;
                        det.EntradasMercanciaArticuloIva = ArticuloTotal - (ArticuloSub0 + ArticuloSub16);
                        det.MtdInsertarEntradaDetalles();
                        //inserta Costeo
                        CLS_Entradas cos = new CLS_Entradas();
                        cos.EntradasMercanciaId = Convert.ToInt32(ins.Datos.Rows[0]["EntradaMercanciaId"].ToString());
                        cos.ArticuloCodigo = dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCodigo"]).ToString();
                        cos.EntradasMercanciaArticuloUltimoIde = Convert.ToInt32(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["Numero"]).ToString());
                        cos.EntradasMercanciaArticuloCantidad = Convert.ToInt32(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCantidad"]).ToString());
                        decimal ArticuloCosto = 0;
                        decimal.TryParse(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCosto"]).ToString(), style, culture, out ArticuloCosto);
                        cos.ArticuloCostoReposicion = ArticuloCosto;
                        decimal ArticuloCostoAdquisicion = 0;
                        decimal.TryParse(dtgValArticuloEntrada.GetRowCellValue(xRow, dtgValArticuloEntrada.Columns["ArticuloCostoAdquisicion"]).ToString(), style, culture, out ArticuloCostoAdquisicion);
                        cos.ArticuloCostoAdquisicion = ArticuloCostoAdquisicion;
                        cos.MtdInsertarEntradaCosteo();

                    }
                    XtraMessageBox.Show("Se ha guardado la Entrada con Exito");
                }
            }
        }

        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoRegistro();
        }

        private void NuevoRegistro()
        {
            MakeTablaPedidos();
            CargarSucursales();
            CargarTipoEntradas(1);
            CargarResponsable(UsuariosLogin);
            LimpiarCampos();
            FormatoDeColumnas();
            FormatoDeCampos();
            BloquearObjetos(true);
            txtCodigo.Focus();
        }

        private void btnAbrir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Entradas_Buscar fr = new Frm_Entradas_Buscar();
            fr.ShowDialog();
            if (fr.FolioEntrada != string.Empty)
            {
                txtFolio.Text = fr.FolioEntrada;
                CargarEntrada();
            }
        }

        private void CargarEntrada()
        {
            BloquearObjetos(false);
            CLS_Entradas sel = new CLS_Entradas();
            sel.EntradasMercanciaId =Convert.ToInt32(txtFolio.Text);
            sel.SucursalesId = v_Sucursalnum;
            sel.MtdSeleccionarEntradaEncabezado();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    CargarTipoEntradas(Convert.ToInt32(sel.Datos.Rows[0]["EntradaMercanciaTipoId"].ToString()));
                    dtFecha.EditValue = Convert.ToDateTime(sel.Datos.Rows[0]["EntradaMercanciaFecha"].ToString());
                    CargarSucursales(v_Sucursalnum);
                    txtResponsable.Text = sel.Datos.Rows[0]["UsuariosNombre"].ToString();
                    txtTotalArticulos.Text= sel.Datos.Rows[0]["EntradaMercanciaUnidades"].ToString();
                    txtSubtotal0.Text= sel.Datos.Rows[0]["EntradaMercanciaSub0"].ToString();
                    txtSubTotal16.Text= sel.Datos.Rows[0]["EntradaMercanciaSub16"].ToString();
                    txtTotal.Text= sel.Datos.Rows[0]["EntradaMercanciaTotal"].ToString();
                    txtObservaciones.Text= sel.Datos.Rows[0]["Observaciones"].ToString();
                    txtReferencias.Text= sel.Datos.Rows[0]["Referencias"].ToString();
                    CargarEntradaDetalles();
                }
            }

        }

        private void CargarEntradaDetalles()
        {
            CLS_Entradas selart = new CLS_Entradas();
            selart.EntradasMercanciaId = Convert.ToInt32(txtFolio.Text);
            selart.SucursalesId = v_Sucursalnum;
            selart.MtdSeleccionarEntradaDetalles();
            if (selart.Exito)
            {
                if (selart.Datos.Rows.Count > 0)
                {
                    dtgArticulosEntrada.DataSource = selart.Datos;
                }
            }
        }

        private void BloquearObjetos(bool v)
        {
            cboTipoMovimiento.Enabled = v;
            txtObservaciones.Enabled = v;
            txtReferencias.Enabled = v;
            txtCodigo.Enabled = v;
            chkCaptura.Checked = false;
            txtCantidad.Enabled = false;
            gridColumn4.OptionsColumn.AllowEdit = v;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text == string.Empty)
            {
                GuardarEntrada();
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty && cboSucursales.EditValue != null)
            {
                long folio = Convert.ToInt32(txtFolio.Text);
                decimal Sucursal = Convert.ToInt32(cboSucursales.EditValue.ToString());
                rpt_Entradas rpt= new rpt_Entradas(folio, Sucursal);
                ((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
                ReportPrintTool print = new ReportPrintTool(rpt);
                rpt.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Falta seleccionar una Entrada");
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
        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoRegistro();
            XtraOpenFileDialog OpenFileDialog = new XtraOpenFileDialog();
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = OpenFileDialog.FileName;
                FileStream stream = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                stream = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    string Linea = reader.ReadLine();
                    string[] Partes = Linea.Split(',');
                    txtCodigo.Text = Partes[3];
                    if (txtCodigo.Text != string.Empty)
                    {
                        if (!BuscarCodigo())
                        {
                            XtraMessageBox.Show("No se encontro el codigo " + txtCodigo.Text + " , No se importara el archivo haSta tener todos los articulos dados de alta");
                            NuevoRegistro();
                            break;
                        }
                        int Valor = 0;
                        if (int.TryParse(Partes[4], out Valor) && txtDescripcion.Text != string.Empty)
                        {
                            txtCantidad.Text = Valor.ToString();
                            if (!ExisteCodigo())
                            {
                                AgregarArticuloGrid();
                            }
                        }
                    }
                    Application.DoEvents();
                }
                reader.Close();

            }
        }

        private void btnExistencia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Entradas_Existencia frm = new Frm_Entradas_Existencia();
            frm.ShowDialog();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_Entradas_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir del modulo Entradas?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}