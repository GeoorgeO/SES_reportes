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

namespace BSC_Reportes
{
    public partial class Frm_Pedidos : DevExpress.XtraEditors.XtraForm
    {
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

        public Frm_Pedidos()
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
            column.ColumnName = "DReyes";
            column.AutoIncrement = false;
            column.Caption = "D";
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
                }
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
                
            }
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
        }
        private void CargarPedidosDetalles(string vFolio)
        {
            MensajeCargando(1);
            CLS_Pedidos selenc = new CLS_Pedidos();
            selenc.PrePedidosId = Convert.ToInt32(vFolio);
            selenc.MtdSeleccionarPedidosDetallesId();
            if (selenc.Exito)
            {
                dtgPedidos.DataSource = selenc.Datos;
            }
            MensajeCargando(2);
            XtraMessageBox.Show("Proceso Completado", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                }
                else
                {
                    XtraMessageBox.Show("Falta ingresar un numero de pedido");
                }
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}