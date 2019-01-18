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

namespace BSC_Reportes
{
    public partial class Frm_DistribucionManual : DevExpress.XtraEditors.XtraForm
    {
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
        public int PedidosId { get; set; }


        public int Folio { get; set; }
        public int TPedido { get; set; }
        public string CodigoArticulo { get; set; }
        public string ArticuloDescripcion { get; set; }
        public string NombreProveedor { get; set; }
        public Frm_DistribucionManual()
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
            column.DataType = typeof(string);
            column.ColumnName = "Sucursales";
            column.AutoIncrement = false;
            column.Caption = "Sucursales";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Cantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            DataRow row = table.NewRow();
            row["Sucursales"] = "Almacen";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Centro";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Morelos";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Fco Villa";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Sarabia I";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Sarabia II";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Paseo";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Estocolmo";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Costa Rica";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Calzada";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Lombardia";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Nva Italia";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Apatzingan";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Sucursales"] = "Los Reyes";
            row["Cantidad"] = "0";
            table.Rows.Add(row);

            dtgSucursales.DataSource = table;
        }

        private void Frm_DistribucionManual_Shown(object sender, EventArgs e)
        {
            txtFolioPedido.Text = Folio.ToString();
            txtNombreProveedor.Text=NombreProveedor;
            txtTPedido.Text = TPedido.ToString();
            txtCodigoArticulo.Text = CodigoArticulo;
            txtArticuloNombre.Text = ArticuloDescripcion;
            MakeTablaPedidos();
            dtgValSucursales.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValSucursales.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValSucursales.OptionsSelection.MultiSelect = true;
            dtgValSucursales.OptionsView.ShowGroupPanel = false;
            txtFolioPedido.Enabled = false;
            txtNombreProveedor.Enabled = false;
            txtTPedido.Enabled = false;
            txtCodigoArticulo.Enabled = false;
            txtArticuloNombre.Enabled = false;
        }

        private void btnAgregarDistribucion_Click(object sender, EventArgs e)
        {
            if (TPedido == SumaDistribucion())
            {
                GuardarDistribucion();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("La suma de la distribucion debe ser igual al Total de Pedido", "Error de distribucion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private int SumaDistribucion()
        {
            int Valor = 0;
            for (int i = 0; i < dtgValSucursales.RowCount; i++)
            {
               int xRow = dtgValSucursales.GetVisibleRowHandle(i);
                Valor += Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                switch (dtgValSucursales.GetRowCellValue(xRow, "Sucursales").ToString())
                {
                    case "Almacen":
                        DAlmacen = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Centro":
                        DCentro = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Morelos":
                        DMorelos = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Fco Villa":
                        DFcoVilla = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Sarabia I":
                        DSarabiaI = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Sarabia II":
                        DSarabiaII = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Paseo":
                        DPaseo = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Estocolmo":
                        DEstocolmo = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Costa Rica":
                        DCostaRica = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Calzada":
                        DCalzada = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Lombardia":
                        DLombardia = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Nva Italia":
                        DNvaItalia = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Apatzingan":
                        DApatzingan = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                    case "Los Reyes":
                        DLosReyes = Convert.ToInt32(dtgValSucursales.GetRowCellValue(xRow, "Cantidad").ToString());
                        break;
                }
            }
            return Valor;
        }
        private void GuardarDistribucion()
        {
            CLS_Pedidos insdet = new CLS_Pedidos();
            insdet.PedidosId = PedidosId;
            insdet.ArticuloCodigo = CodigoArticulo;
            insdet.DAlmacen = Convert.ToInt32(DAlmacen);
            insdet.DApatzingan = Convert.ToInt32(DApatzingan);
            insdet.DCalzada = Convert.ToInt32(DCalzada);
            insdet.DCentro = Convert.ToInt32(DCentro);
            insdet.DCostaRica = Convert.ToInt32(DCostaRica);
            insdet.DEstocolmo = Convert.ToInt32(DEstocolmo);
            insdet.DFcoVilla = Convert.ToInt32(DFcoVilla);
            insdet.DLombardia = Convert.ToInt32(DLombardia);
            insdet.DReyes = Convert.ToInt32(DLosReyes);
            insdet.DMorelos = Convert.ToInt32(DMorelos);
            insdet.DNvaItalia = Convert.ToInt32(DNvaItalia);
            insdet.DPaseo = Convert.ToInt32(DPaseo);
            insdet.DSarabiaI = Convert.ToInt32(DSarabiaI);
            insdet.DSarabiaII = Convert.ToInt32(DSarabiaII);
            insdet.TPedido = Convert.ToInt32(TPedido);
            insdet.MtdInsertPedidoDetalleProveedor();
            if (!insdet.Exito)
            {
                XtraMessageBox.Show(insdet.Mensaje, "Error al guardar el Registro");
            }
        }
    }
}