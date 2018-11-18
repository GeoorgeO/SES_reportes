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

namespace BSC_Reportes
{
    public partial class Frm_DistribucionManual : DevExpress.XtraEditors.XtraForm
    {
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}