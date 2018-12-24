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
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System.IO;
using GridControlEditCBMultipleSelection;
using DevExpress.XtraGrid;

namespace BSC_Reportes
{
    public partial class Frm_Pedidos : DevExpress.XtraEditors.XtraForm
    {
        GridControlCheckMarksSelection gridCheckMarksInsidencias;
        string CadenaCodigos = "0";
        StringBuilder sb = new StringBuilder();
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        private static Frm_Pedidos m_FormDefInstance;
        public static Frm_Pedidos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pedidos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Boolean PedidoSurtido { get;  set; }
        public Boolean _valida { get;  set; }
        public bool PrimeraEdicion { get; private set; }
        public int xRow { get; private set; }
        public int? PedidosId { get; private set; }

        public Frm_Pedidos()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Reg";
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
            column.ColumnName = "DAlmacen";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DCentro";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DMorelos";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DFcoVilla";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DSarabiaI";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DSarabiaII";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DPaseo";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DEstocolmo";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DCostaRica";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DCalzada";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DLombardia";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DNvaItalia";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DApatzingan";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "DLosReyes";
            column.AutoIncrement = false;
            column.Caption = "D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "SumaD";
            column.AutoIncrement = false;
            column.Caption = "Suma D";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Surtido";
            column.AutoIncrement = false;
            column.Caption = "Entrada";
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

            dtgPedidos.DataSource = table;
        }
        private void MakeTablaPedidosInsidencias()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Reg";
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
            column.ColumnName = "Descripcion";
            column.AutoIncrement = false;
            column.Caption = "Descripcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Surtido";
            column.AutoIncrement = false;
            column.Caption = "Entrada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Tipo";
            column.AutoIncrement = false;
            column.Caption = "Tipo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "Recibir";
            column.AutoIncrement = false;
            column.Caption = "Recibir";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgPedidosInsidencias.DataSource = table;
        }
        public void OcultarBotones()
        {
            btnFolios.Links[0].Visible = false;
            btnGuardar.Links[0].Visible = false;
            btnLimpiar.Links[0].Visible = false;
            btnActualizarPedido.Links[0].Visible = false;
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
                        case "19":
                            btnFolios.Links[0].Visible = true;
                            break;
                        case "22":
                            btnCancelar.Links[0].Visible = true;
                            break;
                        case "20":
                            btnGuardar.Links[0].Visible = true;
                            break;
                        case "21":
                            btnLimpiar.Links[0].Visible = true;
                            break;
                        case "23":
                            btnActualizarPedido.Links[0].Visible = true;
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
            btnGuardar.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
            btnActualizarPedido.Links[0].Visible = true;
            btnCancelar.Links[0].Visible = true;
        }
        private void Frm_Pedidos_Load(object sender, EventArgs e)
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
        private void ColumnsCosto(Boolean Mostrar)
        {
            CostoReposicion.Visible = Mostrar;
        }
        private void ColumnsFamilia(Boolean Mostrar)
        {
            Familia.Visible = Mostrar;
        }

        private void Frm_Pedidos_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkCosto.Checked = true;
            chkFamilia.Checked = true;
            dtgPedidos.DataSource = null;
            MakeTablaPedidos();
            MakeTablaPedidosInsidencias();
            dtgValPedidos.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValPedidos.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValPedidos.OptionsSelection.MultiSelect = true;
            dtgValPedidos.OptionsView.ShowGroupPanel = false;
            CostoReposicion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            CostoReposicion.DisplayFormat.FormatString = "$ ###,###0.00";
            pbProgreso.Position = 0;
            DesbloquearObjetos(true);
            dtgValPedidos.CustomDrawCell += dtgValPedidos_CustomDrawCell;
            txtFolio.Focus();
            PrimeraEdicion = false;
            GridMultipleInsidencias();
            btnRecibirInsidencia.Enabled = false;
        }
        private void DesbloquearObjetos(Boolean Valor)
        {
            txtFolio.Enabled = Valor;
        }

        private void dtgValVentaExistencia_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == TPedido && e.IsGetData)
            {
                decimal vEntrada = (decimal)dtgValPedidos.GetListSourceRowCellValue(e.ListSourceRowIndex, Entrada);
                decimal vTPedido = (decimal)dtgValPedidos.GetListSourceRowCellValue(e.ListSourceRowIndex, TPedido);

                if (Convert.ToInt32(vEntrada.ToString()) > Convert.ToDouble(vTPedido.ToString()))
                {
                    //Set an icon with index 0
                    e.Value = imageCollection1.Images[0];
                }
                else if (Convert.ToDouble(vEntrada.ToString()) < Convert.ToDouble(vTPedido.ToString()))
                {
                    //Set an icon with index 1
                    e.Value = imageCollection1.Images[1];
                }
                else
                {
                    //Set an icon with index 2
                    e.Value = imageCollection1.Images[2];
                }
            }
        }

        private void btnFolios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea cargar un pedido, perdera los datos no guardados?\nLos cambios no se podran revertir", "Igualar sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                Frm_Pedidos_Buscar frmpro = new Frm_Pedidos_Buscar();
                frmpro.FrmPedidos = this;
                frmpro.ShowDialog();
                if (txtFolio.Text != string.Empty)
                {
                    btnLimpiar.PerformClick();
                    CargarPedidos(txtFolio.Text);
                    DesbloquearObjetos(true);
                    NumerarReg();
                    XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void NumerarReg()
        {
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["Reg"], x+1);
            }
            for (int x = 0; x < dtgValPedidosInsidencias.RowCount; x++)
            {
                int xRow = dtgValPedidosInsidencias.GetVisibleRowHandle(x);
                dtgValPedidosInsidencias.SetRowCellValue(xRow, dtgValPedidosInsidencias.Columns["Reg"], x + 1);
            }
        }

        public void BuscarPrePedido(string vPrePedidoId)
        {
            txtFolio.Text = vPrePedidoId;
        }
        private void CargarPedidos(string vFolio)
        {
            CLS_Pedidos selenc = new CLS_Pedidos();
            selenc.PrePedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSeleccionarPedidosId();
            if (selenc.Exito)
            {
                dtInicio.DateTime = Convert.ToDateTime(selenc.Datos.Rows[0]["FechaInsert"]);
                txtProveedorId.Text = selenc.Datos.Rows[0]["ProveedorId"].ToString();
                txtProveedorNombre.Text = selenc.Datos.Rows[0]["Proveedor"].ToString();
                PedidoSurtido= Convert.ToBoolean(selenc.Datos.Rows[0]["PedidosSurtido"].ToString());
                if(PedidoSurtido)
                {
                    lblStatus.Text = "Surtido";
                    this.TPedido.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    lblStatus.Text = "Pendiente";
                    this.TPedido.OptionsColumn.AllowEdit = true;
                }
                CargarPedidosDetalles(vFolio);
                CargarPedidosDetallesInsidencias(vFolio);
                SumaDistribucion();
            }
        }

        private void CargarPedidosDetallesInsidencias(string vFolio)
        {
            MensajeCargando(1);
            WEB_Pedidos selenc = new WEB_Pedidos();
            selenc.PedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSelectPedidoDetallesInsidenciasProveedor();
            if (selenc.Exito)
            {
                dtgPedidosInsidencias.DataSource = selenc.Datos;
            }
            MensajeCargando(2);
        }

        void dtgValPedidos_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == TPedido)
            {
                var row = dtgValPedidos.GetRow(e.RowHandle) as DataRowView;
                if ((int)row.Row["Surtido"] == (int)e.CellValue)
                {
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cell = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
                    if (cell != null)
                    {
                        TextEditViewInfo viewInfo = cell.ViewInfo as TextEditViewInfo;
                        viewInfo.ContextImage = imageCollection1.Images[2];
                        viewInfo.CalcViewInfo(e.Graphics);
                    }
                }
                else if ((int)row.Row["Surtido"] > (int)e.CellValue)
                {
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cell = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
                    if (cell != null)
                    {
                        TextEditViewInfo viewInfo = cell.ViewInfo as TextEditViewInfo;
                        viewInfo.ContextImage = DevExpress.XtraEditors.Helpers.IconSetImageLoader.GetDefault(dtgPedidos.LookAndFeel).GetImage("Arrows3_1.png");
                        viewInfo.CalcViewInfo(e.Graphics);
                    }
                }
                else if ((int)row.Row["Surtido"] < (int)e.CellValue)
                {
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cell = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
                    if (cell != null)
                    {
                        TextEditViewInfo viewInfo = cell.ViewInfo as TextEditViewInfo;
                        viewInfo.ContextImage = DevExpress.XtraEditors.Helpers.IconSetImageLoader.GetDefault(dtgPedidos.LookAndFeel).GetImage("Arrows3_3.png");
                        viewInfo.CalcViewInfo(e.Graphics);
                    }
                }
                
            }
            if (e.Column == TPedido && PedidoSurtido == false)
            {
                var row = dtgValPedidos.GetRow(e.RowHandle) as DataRowView;
                if ((int)row.Row["SumaD"] == (int)e.CellValue)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            else if (e.Column == Entrada && PedidoSurtido == true)
            {
                var row = dtgValPedidos.GetRow(e.RowHandle) as DataRowView;
                if ((int)row.Row["SumaD"] == (int)e.CellValue)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
        }
        private void CargarPedidosDetalles(string vFolio)
        {
            MensajeCargando(1);
            CLS_Pedidos selenc = new CLS_Pedidos();
            selenc.PedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSeleccionarPedidosDetallesId();
            if (selenc.Exito)
            {
                dtgPedidos.DataSource = selenc.Datos;
            }
            MensajeCargando(2);
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
        public void BuscarPedido(string vPrePedidoId)
        {
            txtFolio.Text = vPrePedidoId;
        }

        private void txtFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                if(txtFolio.Text!=string.Empty)
                {
                    btnLimpiar.PerformClick();
                    CargarPedidos(txtFolio.Text);
                    DesbloquearObjetos(true);
                    NumerarReg();
                    XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    XtraMessageBox.Show("Falta ingresar un numero de pedido");
                }
            }
        }
        private void SumaDistribucion()
        {
            int TDistribucion = 0;
            pbProgreso.Properties.Maximum = dtgValPedidos.RowCount;

            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                pbProgreso.Position = x + 1;
                Application.DoEvents();
                TDistribucion = 0;
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DAlmacen").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCentro").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DApatzingan").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCalzada").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCostaRica").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DEstocolmo").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DFcoVilla").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DLombardia").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DLosReyes").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DMorelos").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DNvaItalia").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DPaseo").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DSarabiaI").ToString());
                TDistribucion += Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DSarabiaII").ToString());
                dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["SumaD"], TDistribucion);
                
            }
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            dtInicio.EditValue = DateTime.Now;
            txtProveedorId.Text = string.Empty;
            txtProveedorNombre.Text = string.Empty;
            chkCosto.Checked = true;
            chkFamilia.Checked = true;
            dtgPedidos.DataSource = null;
            dtgPedidosInsidencias.DataSource = null;
            MakeTablaPedidos();
            MakeTablaPedidosInsidencias();
            DesbloquearObjetos(true);
        }

        private void dtgValPedidos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicion)
            {
                PrimeraEdicion = true;
                GridView gv = sender as GridView;
                int TDistribucion = 0;
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DAlmacen"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DCentro"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DApatzingan"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DCalzada"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DCostaRica"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DEstocolmo"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DFcoVilla"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DLombardia"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DLosReyes"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DMorelos"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DNvaItalia"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DPaseo"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DSarabiaI"]).ToString());
                TDistribucion += Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["DSarabiaII"]).ToString());
                gv.SetRowCellValue(e.RowHandle, gv.Columns["SumaD"], TDistribucion);
                PrimeraEdicion = false;
            }
        }

        private void btnVistaPreviaPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                int folio = Convert.ToInt32(txtFolio.Text);
                rpt_Pedidos rpt = new rpt_Pedidos(folio);
                ReportPrintTool print = new ReportPrintTool(rpt);
                rpt.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Falta seleccionar un Pedido");
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text != string.Empty && dtgValPedidos.RowCount>0)
            {
                XtraMessageBox.Show("¡Solo se guardaran los Articulos con la distribucion Correcta!", "Valida Distribucion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                GuardarDetalles();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado un pedido", "Pedidos");
            }
        }
        private void GuardarDetalles()
        {
            pbProgreso.Properties.Maximum = dtgValPedidos.RowCount;
            for (int i = 0; i < dtgValPedidos.RowCount; i++)
            {
                pbProgreso.Position = i + 1;
                Application.DoEvents();
                CLS_Pedidos insdetped = new CLS_Pedidos();
                int xRow = dtgValPedidos.GetVisibleRowHandle(i);
                insdetped.PedidosId = Convert.ToInt32(txtFolio.Text);
                insdetped.ArticuloCodigo = dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString();
                insdetped.DAlmacen = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DAlmacen").ToString());
                insdetped.DCentro = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCentro").ToString());
                insdetped.DApatzingan = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DApatzingan").ToString());
                insdetped.DCalzada = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCalzada").ToString());
                insdetped.DCostaRica = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DCostaRica").ToString());
                insdetped.DEstocolmo = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DEstocolmo").ToString());
                insdetped.DFcoVilla = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DFcoVilla").ToString());
                insdetped.DLombardia = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DLombardia").ToString());
                insdetped.DReyes = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DLosReyes").ToString());
                insdetped.DMorelos = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DMorelos").ToString());
                insdetped.DNvaItalia = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DNvaItalia").ToString());
                insdetped.DPaseo = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DPaseo").ToString());
                insdetped.DSarabiaI = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DSarabiaI").ToString());
                insdetped.DSarabiaII = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "DSarabiaII").ToString());
                int SumaD = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "SumaD").ToString());
                insdetped.Surtido = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString());
                insdetped.TPedido = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "TPedido").ToString());
                insdetped.Exito = true;
                if (PedidoSurtido)
                {
                    if (SumaD == insdetped.Surtido)
                    {
                        insdetped.MtdUpdatePedidoDetalleSurtido();
                    }
                }
                else
                {
                    if (SumaD == insdetped.TPedido)
                    {
                        insdetped.MtdUpdatePedidoDetallePendiente();
                    }
                }
                if (!insdetped.Exito)
                {
                    XtraMessageBox.Show(insdetped.Mensaje, "Error al guardar el Registro");
                }
            }
        }

        private void btnLiberaPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea liberar el pedido, solo almacen podra cerrar el pedido?", "Liberar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                WEB_Pedidos q = new WEB_Pedidos();
                q.PedidosId = Convert.ToInt32(txtFolio.Text);
                q.PedidosSurtido = 0;
                q.MtdUpdatePedidoSurtido();
                if (!q.Exito)
                {
                    XtraMessageBox.Show(q.Mensaje);
                }
                else
                {
                    XtraMessageBox.Show("¡Pedido Liberado!", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnGeneraArchivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportaDatos(Convert.ToInt32(txtFolio.Text));
        }
        private static string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void ExportaDatos(int folio)
        {
            if (PedidoSurtido)
            {
                try
                {
                    if (DistribucionCorrecta())
                    {
                        DirectorySucursales();
                        EntradaAlmacen();
                        //SalidaAlmacenTiendas();
                        EntradaTiendas();
                        XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Existen articulos del pedido con una mala distribucion");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Generar el Archivo" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("No se ha surtido el Pedido");
            }
        }

        private void EntradaTiendas()
        {
            EntradaSucursalCentro();
            EntradaSucursalApatzingan();
            EntradaSucursalCalzada();
            EntradaSucursalCostaRica();
            EntradaSucursalEstocolmo();
            EntradaSucursalFcoVilla();
            EntradaSucursalLombardia();
            EntradaSucursalLosReyes();
            EntradaSucursalMorelos();
            EntradaSucursalNvaItalia();
            EntradaSucursalPaseo();
            EntradaSucursalSarabiaI();
            EntradaSucursalSarabiaII();
        }

        private void EntradaAlmacen()
        {
            try
            {
                string Ruta = string.Empty;
                Ruta = String.Format("C:\\FileExport\\Almacen\\");
                string fileName = string.Empty;
                string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
                string TipoArch = "Entrada";
                fileName = String.Format("{0}_{1}_{2}_{3}.txt", TipoArch, "Almacen", "Pedido[" + txtFolio.Text + "]", VFecha);
                Ruta += fileName;
                FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                for (int x = 0; x < dtgValPedidos.RowCount; x++)
                {
                    int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                    if (dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString() != "0")
                    {
                        string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString());
                        writer.WriteLine(Linea);
                    }
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void EntradaSucursalCentro()
        {
            string Sucursal = "CENTRO";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal,  txtFolio.Text , VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DCentro").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DCentro").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalApatzingan()
        {
            string Sucursal = "APATZINGAN";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DApatzingan").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DApatzingan").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalCalzada()
        {
            string Sucursal = "CALZADA B";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DCalzada").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DCalzada").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalCostaRica()
        {
            string Sucursal = "COSTA RICA";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DCostaRica").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DCostaRica").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalEstocolmo()
        {
            string Sucursal = "ESTOCOLMO";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DEstocolmo").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DEstocolmo").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalFcoVilla()
        {
            string Sucursal = "FCO. VILLA";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DFcoVilla").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DFcoVilla").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalLombardia()
        {
            string Sucursal = "LOMBARDIA";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DLombardia").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DLombardia").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalLosReyes()
        {
            string Sucursal = "LOS REYES";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DLosReyes").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DLosReyes").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalMorelos()
        {
            string Sucursal = "MORELOS";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DMorelos").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DMorelos").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalNvaItalia()
        {
            string Sucursal = "NUEVA ITALIA";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DNvaItalia").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DNvaItalia").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalPaseo()
        {
            string Sucursal = "PASEO";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DPaseo").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DPaseo").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalSarabiaI()
        {
            string Sucursal = "SARABIA";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DSarabiaI").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DSarabiaI").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private void EntradaSucursalSarabiaII()
        {
            string Sucursal = "SARABIA II";
            string Ruta = string.Empty;
            Ruta = String.Format("C:\\FileExport\\{0}\\", Sucursal);
            string fileName = string.Empty;
            string VFecha = DateTime.Now.Year.ToString() + DosCero(DateTime.Now.Month.ToString()) + DosCero(DateTime.Now.Day.ToString());
            string TipoArch = "Entrada";
            fileName = String.Format("{0}_{1}_Pedido[{2}]_{3}.txt", TipoArch, Sucursal, txtFolio.Text, VFecha);
            Ruta += fileName;
            FileStream stream = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                if (dtgValPedidos.GetRowCellValue(xRow, "DSarabiaII").ToString() != "0")
                {
                    string Linea = String.Format(",,,{0},{1}", dtgValPedidos.GetRowCellValue(xRow, "ArticuloCodigo").ToString(), dtgValPedidos.GetRowCellValue(xRow, "DSarabiaII").ToString());
                    writer.WriteLine(Linea);
                }
            }
            writer.Close();
        }
        private Boolean DistribucionCorrecta()
        {
            Boolean Valor = true;
            for (int x = 0; x < dtgValPedidos.RowCount; x++)
            {
                int xRow = dtgValPedidos.GetVisibleRowHandle(x);
                int SumaD = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "SumaD").ToString());
                int Surtido = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString());
                if(SumaD!= Surtido)
                {
                    Valor = false;
                    break;
                }
            }
            return Valor;
        }
        private static void DirectorySucursales()
        {
            System.IO.Directory.CreateDirectory(@"C:\FileExport");
            CLS_Sucursales suc = new CLS_Sucursales();
            suc.ListarSucursales();
            for (int x = 0; x < suc.Datos.Rows.Count; x++)
            {
                System.IO.Directory.CreateDirectory(@"C:\FileExport\" + suc.Datos.Rows[x][1].ToString().Trim());
            }
        }
        private void btnIgualarACero_Click(object sender, EventArgs e)
        {
            if (PedidoSurtido)
            {
                DialogResult = XtraMessageBox.Show("¿Desea igualar a 0 todo los articulos que no fueron surtidos?", "Igualar 0 en Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < dtgValPedidos.RowCount; i++)
                    {
                        pbProgreso.Position = i + 1;
                        Application.DoEvents();
                        CLS_Pedidos insdetped = new CLS_Pedidos();
                        int xRow = dtgValPedidos.GetVisibleRowHandle(i);
                        int Surtido = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString());
                        if (Surtido == 0)
                        {
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DAlmacen"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DCentro"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DApatzingan"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DCalzada"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DCostaRica"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DEstocolmo"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DFcoVilla"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DLombardia"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DReyes"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DMorelos"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DNvaItalia"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DPaseo"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DSarabiaI"], 0);
                            dtgValPedidos.SetRowCellValue(xRow, dtgValPedidos.Columns["DSarabiaII"], 0);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha surtido el Pedido");
            }
        }

        private void btnRedistribuir_Click(object sender, EventArgs e)
        {
            if (PedidoSurtido)
            {
                DialogResult = XtraMessageBox.Show("¿Desea Redistribuir todo los articulos que tengan diferencia?", "Redistribuir Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {

                }
            }
            else
            {
                MessageBox.Show("No se ha surtido el Pedido");
            }
        }
        private void GridMultipleInsidencias()
        {
            gridCheckMarksInsidencias = new GridControlCheckMarksSelection(dtgValPedidosInsidencias);
            gridCheckMarksInsidencias.SelectionChanged += gridCheckMarksAcuerdos_SelectionChanged;
        }
        void gridCheckMarksAcuerdos_SelectionChanged(object sender, EventArgs e)
        {
            CadenaCodigos = string.Empty;
            if (ActiveControl is GridControl)
            {

                foreach (DataRowView rv in (sender as GridControlCheckMarksSelection).selection)
                {
                    if (sb.ToString().Length > 0) { sb.Append(", "); }
                    sb.AppendFormat("{0}", rv["ArticuloCodigo"]);

                    if (CadenaCodigos != string.Empty)
                    {
                        CadenaCodigos = string.Format("{0},{1}", CadenaCodigos, rv["ArticuloCodigo"]);
                    }
                    else
                    {
                        CadenaCodigos = rv["ArticuloCodigo"].ToString();
                    }
                }
            }
            if(CadenaCodigos==string.Empty)
            {
                btnRecibirInsidencia.Enabled = false;
            }
            else
            {
                btnRecibirInsidencia.Enabled = true;
            }
        }

        private void btnRecibirInsidencia_Click(object sender, EventArgs e)
        {
            string[] result = CadenaCodigos.Split(',');
            foreach (string Codigo in result)
            {
                RecibirInsidencia(Codigo);
            }
        }

        private void RecibirInsidencia(string codigo)
        {
            string ArticuloCodigo = string.Empty;
            int Cantidad = 0;
            Boolean ExisteenPedido = false;
            WEB_Pedidos sel = new WEB_Pedidos();
            sel.ArticuloCodigo = codigo;
            sel.MtdSelectArticulo();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    for (int i = 0; i < dtgValPedidos.RowCount; i++)
                    {
                        int xRow = dtgValPedidos.GetVisibleRowHandle(i);
                        if (dtgValPedidos.GetRowCellValue(xRow, "Articulocodigo").ToString() == codigo)
                        {
                            ArticuloCodigo = dtgValPedidos.GetRowCellValue(xRow, "Articulocodigo").ToString();
                            Cantidad = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Surtido").ToString());
                            ExisteenPedido = true;
                            break;
                        }
                    }
                    if (ExisteenPedido)
                    {
                        int CantidadRecibir = BuscaCantidadInsidencia(codigo);
                        int CantEntrada = Cantidad + CantidadRecibir;
                        CLS_Pedidos udp = new CLS_Pedidos();
                        udp.PedidosId = Convert.ToInt32(txtFolio.Text);
                        udp.ArticuloCodigo = ArticuloCodigo;
                        udp.Surtido = CantEntrada;
                        udp.MtdUpdateInsidencia();
                        if (udp.Exito)
                        {
                            CLS_Pedidos del = new CLS_Pedidos();
                            del.PedidosId = Convert.ToInt32(txtFolio.Text);
                            del.ArticuloCodigo = ArticuloCodigo;
                            del.MtdEliminarInsidencia();
                        }
                    }
                    else
                    {
                        CLS_Pedidos ins = new CLS_Pedidos();
                        ins.PedidosId = Convert.ToInt32(txtFolio.Text);
                        ins.ArticuloCodigo = sel.Datos.Rows[0][0].ToString();
                        ins.ArticuloDescripcion = sel.Datos.Rows[0][1].ToString();
                        ins.Surtido = BuscaCantidadInsidencia(codigo);
                        ins.MtdInsertInsidenciar();
                        if (ins.Exito)
                        {
                            CLS_Pedidos del = new CLS_Pedidos();
                            del.PedidosId = Convert.ToInt32(txtFolio.Text);
                            del.ArticuloCodigo = ArticuloCodigo;
                            del.MtdEliminarInsidencia();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dtgValPedidos.RowCount; i++)
                    {
                        int xRow = dtgValPedidos.GetVisibleRowHandle(i);
                        if (dtgValPedidos.GetRowCellValue(xRow, "Articulocodigo").ToString() == codigo)
                        {
                            ArticuloCodigo = dtgValPedidos.GetRowCellValue(xRow, "Articulocodigo").ToString();
                            Cantidad = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Entrada").ToString());
                            ExisteenPedido = true;
                            break;
                        }
                    }
                    if(ExisteenPedido)
                    {
                        int CantidadRecibir = BuscaCantidadInsidencia(codigo);
                        int CantEntrada = Cantidad + CantidadRecibir;
                        CLS_Pedidos udp = new CLS_Pedidos();
                        udp.PedidosId =Convert.ToInt32(txtFolio.Text);
                        udp.ArticuloCodigo = ArticuloCodigo;
                        udp.Surtido = CantEntrada;
                        udp.MtdUpdateInsidencia();
                        if(udp.Exito)
                        {
                            CLS_Pedidos del = new CLS_Pedidos();
                            del.PedidosId = Convert.ToInt32(txtFolio.Text);
                            del.ArticuloCodigo = ArticuloCodigo;
                            del.MtdEliminarInsidencia();

                        }
                    }
                    else
                    {
                        CLS_Pedidos ins = new CLS_Pedidos();
                        ins.PedidosId = Convert.ToInt32(txtFolio.Text);
                        ins.ArticuloCodigo = ArticuloCodigo;
                        ins.ArticuloDescripcion = "Articulo Nuevo Sin Definir";
                        ins.Surtido = BuscaCantidadInsidencia(codigo);
                        ins.MtdInsertInsidenciar();
                        if (ins.Exito)
                        {
                            CLS_Pedidos del = new CLS_Pedidos();
                            del.PedidosId = Convert.ToInt32(txtFolio.Text);
                            del.ArticuloCodigo = ArticuloCodigo;
                            del.MtdEliminarInsidencia();
                        }
                    }
                }
            }
        }

        private int BuscaCantidadInsidencia(string codigo)
        {
            int Valor = 0;
            for (int i = 0; i < dtgValPedidosInsidencias.RowCount; i++)
            {
                int xRow = dtgValPedidosInsidencias.GetVisibleRowHandle(i);
                if (dtgValPedidosInsidencias.GetRowCellValue(xRow, "Articulocodigo").ToString() == codigo)
                {
                    Valor = Convert.ToInt32(dtgValPedidos.GetRowCellValue(xRow, "Cantidad").ToString());
                    break;
                }
            }
            return Valor;
        }
    }
}