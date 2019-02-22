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
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid;

namespace BSC_Reportes
{
    public partial class Frm_RotacionMercancia : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        List<int> FamiliaId = new List<int>();
        List<String> FamiliaNombre = new List<String>();
        List<int> FamiliaPadreId = new List<int>();
        public string CadenaNodos { get; set; }
        public string ElementoFamilia { get; private set; }
        private static Frm_RotacionMercancia m_FormDefInstance;
        public static Frm_RotacionMercancia DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_RotacionMercancia();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
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
        public Frm_RotacionMercancia()
        {
            InitializeComponent();
        }
        private void btnImpProveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores_Buscar frmpro = new Frm_Proveedores_Buscar();
            frmpro.FrmRotacionMercancia = this;
            frmpro.ShowDialog();
        }
        public void BuscarProveedor(string vProveedorId)
        {
            txtProveedorId.Text = vProveedorId;
            CLS_Proveedores selpro = new CLS_Proveedores() { ProveedorId = Convert.ToInt32(vProveedorId) };
            txtProveedorNombre.Text = selpro.MtdSeleccionarProveedorId();
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

                ElementoFamilia = CadenaNodos;

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
        private void Frm_RotacionMercancia_Load(object sender, EventArgs e)
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
            ElementoFamilia = string.Empty;
        }
        public void OcultarBotones()
        {
            btnImpProveedor.Links[0].Visible = false;
            btnBuscarFamilia.Links[0].Visible = false;
            btnImportarArticulos.Links[0].Visible = false;
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
                        case "38":
                            btnImpProveedor.Links[0].Visible = true;
                            break;
                        case "39":
                            btnBuscarFamilia.Links[0].Visible = true;
                            break;
                        case "40":
                            btnImportarArticulos.Links[0].Visible = true;
                            break;
                        case "41":
                            btnGenerarReporte.Links[0].Visible = true;
                            break;
                        case "42":
                            btnExportarExcel.Links[0].Visible = true;
                            break;
                        case "43":
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

        private void btnExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    string path = string.Format("{0}\\{1}.xls", Cadena, result);

                    dtgValCentro.ExportToXlsx(path, new DevExpress.XtraPrinting.XlsxExportOptionsEx
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

        private void btnImportarArticulos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtArticuloCodigo.Text = string.Empty;
            txtArticuloDescripcion.Text = string.Empty;
            Frm_Articulos_Buscar selart = new Frm_Articulos_Buscar();
            selart.ShowDialog();

            if(selart.vArticuloCodigo!=string.Empty && selart.vArticuloDescripcion!=string.Empty)
            {
                txtArticuloCodigo.Text = selart.vArticuloCodigo;
                txtArticuloDescripcion.Text = selart.vArticuloDescripcion;
            }
        }

        private void chkFamilia_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFamilia.Checked==true)
            {
                txtIdFamilia.Text = string.Empty;
                txtNombreFamilia.Text = string.Empty;
            }
        }

        private void chkProveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProveedores.Checked == true)
            {
                txtProveedorId.Text = string.Empty;
                txtProveedorNombre.Text = string.Empty;
            }
        }

        private void btnGenerarReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}