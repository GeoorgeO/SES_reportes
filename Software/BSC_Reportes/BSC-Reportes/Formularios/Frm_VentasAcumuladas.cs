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
using GridLookUpEditCBMultipleSelection;
using GridControlEditCBMultipleSelection;
using DevExpress.XtraEditors.Repository;
using DevExpress.Xpf.Dialogs;

namespace BSC_Reportes
{
    public partial class Frm_VentasAcumuladas : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }

        List<int> FamiliaId = new List<int>();
        List<String> FamiliaNombre = new List<String>();
        List<int> FamiliaPadreId = new List<int>();

        public string CadenaNodos { get; set; }

        GridCheckMarksSelection gridCheckMarkSucursales;
        StringBuilder sb = new StringBuilder();
        string CadenaSucursales = string.Empty;
        string CadenaEspSucursales = string.Empty;
        int TotalRegSucursales = 0;

        public Frm_VentasAcumuladas()
        {
            InitializeComponent();
        }
        private static Frm_VentasAcumuladas m_FormDefInstance;
        public static Frm_VentasAcumuladas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_VentasAcumuladas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "SucursalesNombre";
            column.AutoIncrement = false;
            column.Caption = "Sucursal";
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
            column.DataType = typeof(string);
            column.ColumnName = "Familia";
            column.AutoIncrement = false;
            column.Caption = "Familia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TicketArticuloPrecio";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "TicketArticuloCantidad";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgVentaExistencia.DataSource = table;
        }
        private void btnImpProveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmVentasAcumuladas = this;
            frmpro.ShowDialog();
        }
        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
        }

        private void Frm_VentasAcumuladas_Load(object sender, EventArgs e)
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
        public void OcultarBotones()
        {
            btnImpProveedor.Links[0].Visible = false;
            btnBuscarFamilia.Links[0].Visible = false;
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
                        case "33":
                            btnImpProveedor.Links[0].Visible = true;
                            break;
                        case "34":
                            btnBuscarFamilia.Links[0].Visible = true;
                            break;
                        case "35":
                            btnGenerarReporte.Links[0].Visible = true;
                            break;
                        case "36":
                            btnExportarExcel.Links[0].Visible = true;
                            break;
                        case "37":
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
            btnImpProveedor.Links[0].Visible = true;
            btnBuscarFamilia.Links[0].Visible = true;
            btnGenerarReporte.Links[0].Visible = true;
            btnExportarExcel.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
        }

        private void btnBuscarFamilia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_BFamilias frmFam = new Frm_BFamilias();
            frmFam.ShowDialog();
            if (frmFam.IdFamilia != 0)
            {
                txtIdFamilia.Text = frmFam.IdFamilia.ToString();
                BuscarFamilia(Convert.ToInt32(txtIdFamilia.Text));

                FamiliaId = frmFam.FamiliaId;
                FamiliaNombre = frmFam.FamiliaNombre;
                FamiliaPadreId = frmFam.FamiliaPadreId;

                CadenaNodos = frmFam.IdFamilia.ToString();
                AgregarHijos(frmFam.IdFamilia);

                string temporal = CadenaNodos;

            }
        }
        private void BuscarFamilia(int IdFamilia)
        {
            CLS_Familias bArt = new CLS_Familias();
            bArt.FamiliaId = Convert.ToInt32(IdFamilia.ToString());
            bArt.MtdSeleccionarFamilia();
            if (bArt.Exito)
            {
                if (bArt.Datos.Rows.Count > 0)
                {
                    txtNombreFamilia.Text = bArt.Datos.Rows[0][1].ToString();
                }
            }
        }


        private void AgregarHijos(int ID)
        {

            for (int x = 0; x < FamiliaId.Count; x++)
            {
                if (FamiliaPadreId[x] == ID)
                {
                    CadenaNodos = CadenaNodos + "," + FamiliaId[x].ToString();
                    AgregarHijos(Convert.ToInt32(FamiliaId[x].ToString()));
                }
            }
        }
        private void CargarSucursales()
        {
            CLS_Sucursales bsel = new CLS_Sucursales();
            bsel.ListarSucursales();
            if (bsel.Exito)
            {
                gridCheckMarkSucursales.ClearSelection(cboGridFloracionView);
                TotalRegSucursales = bsel.Datos.Rows.Count;
                cboGridSucursales.Properties.DataSource = bsel.Datos;
            }
        }
        private void Frm_VentasAcumuladas_Shown(object sender, EventArgs e)
        {
            LlenarComboSucursales();
            CargarSucursales();
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
        }

        private void LlenarComboSucursales()
        {
            cboGridSucursales.CustomDisplayText += cboGridSucursales_CustomDisplayText;
            cboGridSucursales.Properties.PopulateViewColumns();
            gridCheckMarkSucursales = new GridCheckMarksSelection(cboGridSucursales.Properties);
            gridCheckMarkSucursales.SelectionChanged += cboGridSucursales_SelectionChanged;
            cboGridSucursales.Properties.Tag = gridCheckMarkSucursales;
        }
        void cboGridSucursales_SelectionChanged(object sender, EventArgs e)
        {
            CadenaSucursales = string.Empty;
            if (ActiveControl is GridLookUpEdit)
            {
                CadenaEspSucursales = string.Empty;
                foreach (DataRowView rv in (sender as GridCheckMarksSelection).Selection)
                {
                    if (sb.ToString().Length > 0) { sb.Append(", "); }
                    sb.AppendFormat("{0}; {1}", rv["SucursalesId"], rv["SucursalesNombre"]);

                    if (CadenaSucursales != string.Empty)
                    {
                        CadenaSucursales = string.Format("{0},{1}", CadenaSucursales, rv["SucursalesId"]);
                    }
                    else
                    {
                        CadenaSucursales = rv["SucursalesId"].ToString();
                    }
                    //Parametros especiales para Reporte Catalogo de Precios
                    if (CadenaEspSucursales != string.Empty)
                    {
                        CadenaEspSucursales = string.Format("{0},{1}", CadenaEspSucursales, rv["SucursalesNombre"]);
                    }
                    else
                    {
                        CadenaEspSucursales = rv["SucursalesNombre"].ToString();
                    }
                }
                int TotalSelect = gridCheckMarkSucursales.SelectedCount;
                if (TotalSelect == TotalRegSucursales)
                {
                    CadenaEspSucursales = "Todas";
                }
                (ActiveControl as GridLookUpEdit).Text = sb.ToString();
            }
        }
        void cboGridSucursales_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            GridCheckMarksSelection gridCheckMark = sender is GridLookUpEdit ? (sender as GridLookUpEdit).Properties.Tag as GridCheckMarksSelection : (sender as RepositoryItemGridLookUpEdit).Tag as GridCheckMarksSelection;
            if (gridCheckMark == null) return;
            foreach (DataRowView rv in gridCheckMark.Selection)
            {
                if (sb.ToString().Length > 0) { sb.Append(", "); }
                sb.AppendFormat("{0}; {1}", rv["SucursalesId"], rv["SucursalesNombre"]);
            }
            e.DisplayText = sb.ToString();
            if (sb.ToString() == string.Empty)
            {
                e.DisplayText = "-Seleccione-";
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlenarComboSucursales();
            CargarSucursales();
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            CadenaNodos = string.Empty;
            txtIdFamilia.Text = string.Empty;
            txtNombreFamilia.Text = string.Empty;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
        }

        private void btnExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFolderBrowserDialog saveFileDialog = new XtraFolderBrowserDialog();
            //openFileDialog.Filter = "Image Files(*.PNG; *.BMP; *.JPG; *.GIF)| *.PNG; *.BMP; *.JPG; *.GIF";
            //saveFileDialog.Filter = "Excel Files(*.xls)| *.xls";
            //saveFileDialog.CheckFileExists = true;
            //saveFileDialog.FilterIndex = 1;
            //saveFileDialog.RestoreDirectory = true;
            
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
                var result = XtraInputBox.Show(args).ToString();

            }
        }
    }
}