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
    public partial class Frm_CheckSincroniza_Sucursales : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        private static Frm_CheckSincroniza_Sucursales m_FormDefInstance;
        public static Frm_CheckSincroniza_Sucursales DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_CheckSincroniza_Sucursales();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_CheckSincroniza_Sucursales()
        {
            InitializeComponent();
        }

        private void Frm_CheckSincroniza_Sucursales_Shown(object sender, EventArgs e)
        {
            CargarSucursales(1);
            LimpiarObjetos();
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
            btnBuscar.Links[0].Visible = false;
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
                        case "47":
                            btnBuscar.Links[0].Visible = true;
                            break;
                        case "48":
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
            btnBuscar.Links[0].Visible = true;
            btnLimpiar.Links[0].Visible = true;
        }
        private void LimpiarObjetos()
        {
            txtAñoDesde.Text = DateTime.Now.Year.ToString();
            txtHastaAño.Text = DateTime.Now.Year.ToString();
            cmbDesdeMes.SelectedIndex = 0;
            cmbHastaMes.SelectedIndex = 0;
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            txtHastaAño.Enabled = true;
            txtAñoDesde.Enabled = true;
            cmbDesdeMes.Enabled = false;
            cmbHastaMes.Enabled = false;
            dtInicio.Enabled = false;
            dtFin.Enabled = false;
            opPeriodo.SelectedIndex = 0;
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
        private void CargarSucursales(int? Valor)
        {
            ConexionesSucursales conSucursales = new ConexionesSucursales();
            conSucursales.MtdSeleccionarSucursales();
            if (conSucursales.Exito)
            {
                cboSucursales.Properties.DisplayMember = "SucursalesNombre";
                cboSucursales.Properties.ValueMember = "SucursalesId";
                cboSucursales.EditValue = Valor;
                cboSucursales.Properties.DataSource = conSucursales.Datos;
            }
        }

        private void opPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(opPeriodo.SelectedIndex==0)
            {
                txtHastaAño.Enabled = true;
                txtAñoDesde.Enabled = true;
                cmbDesdeMes.Enabled = false;
                cmbHastaMes.Enabled = false;
                dtInicio.Enabled = false;
                dtFin.Enabled = false;
            }
            else if (opPeriodo.SelectedIndex == 1)
            {
                txtHastaAño.Enabled = true;
                txtAñoDesde.Enabled = true;
                cmbDesdeMes.Enabled = true;
                cmbHastaMes.Enabled = true;
                dtInicio.Enabled = false;
                dtFin.Enabled = false;
            }
            else if (opPeriodo.SelectedIndex == 2)
            {
                txtHastaAño.Enabled = false;
                txtAñoDesde.Enabled = false;
                cmbDesdeMes.Enabled = false;
                cmbHastaMes.Enabled = false;
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MensajeCargando(1);
            if (cboSucursales.EditValue != null)
            {
                int AñoDesde, AñoHasta, MesDesde, MesHasta, DiaDesde, DiaHasta;
                string FechaInicio = string.Empty, FechaFin = string.Empty;
                DateTime dInicio = DateTime.Now, dFin = DateTime.Now;
                if (opPeriodo.SelectedIndex == 0)
                {
                    MesDesde = 1;
                    MesHasta = 12;
                    DiaDesde = 1;
                    DiaHasta = 31;
                    FechaInicio = string.Format("{0}{1}{2} 00:00:00", txtAñoDesde.Text, DosCeros(MesDesde.ToString()), DosCeros(DiaDesde.ToString()));
                    FechaFin = string.Format("{0}{1}{2} 23:59:59", txtHastaAño.Text, DosCeros(MesHasta.ToString()), DosCeros(DiaHasta.ToString()));
                }
                else if (opPeriodo.SelectedIndex == 1)
                {
                    AñoDesde = Convert.ToInt32(txtAñoDesde.Text);
                    AñoHasta = Convert.ToInt32(txtHastaAño.Text);
                    MesDesde = Convert.ToInt32(cmbDesdeMes.SelectedIndex) + 1;
                    MesHasta = Convert.ToInt32(cmbHastaMes.SelectedIndex) + 1;
                    DiaDesde = 1;
                    DiaHasta = DiasMes(AñoHasta, MesHasta);
                    FechaInicio = string.Format("{0}{1}{2} 00:00:00", AñoDesde.ToString(), DosCeros(MesDesde.ToString()), DosCeros(DiaDesde.ToString()));
                    FechaFin = string.Format("{0}{1}{2} 23:59:59", AñoHasta.ToString(), DosCeros(MesHasta.ToString()), DosCeros(DiaHasta.ToString()));
                }
                else if (opPeriodo.SelectedIndex == 2)
                {
                    dInicio = Convert.ToDateTime(dtInicio.EditValue);
                    dFin = Convert.ToDateTime(dtFin.EditValue);
                    FechaInicio = string.Format("{0}{1}{2} 00:00:00", dInicio.Year, DosCeros(dInicio.Month.ToString()), DosCeros(dInicio.Day.ToString()));
                    FechaFin = string.Format("{0}{1}{2} 23:59:59", dFin.Year, DosCeros(dFin.Month.ToString()), DosCeros(dFin.Day.ToString()));
                }

                int result = DateTime.Compare(dInicio, dFin);
                if (result < 1)
                {
                    CLS_CheckSincroniza_Sucursales sel = new CLS_CheckSincroniza_Sucursales();
                    sel.FechaInicio = FechaInicio;
                    sel.FechaFin = FechaFin;
                    sel.SucursalId = Convert.ToInt32(cboSucursales.EditValue);
                    sel.MtdSeleccionarDatos();
                    if (sel.Exito)
                    {
                        dtgCheckSincroniza.DataSource = sel.Datos;
                        if (sel.Datos.Rows.Count == 0)
                        {
                            XtraMessageBox.Show("No existen diferencia en sincronizacion");
                        }
                        MensajeCargando(2);
                    }
                    else
                    {
                        MensajeCargando(2);
                        XtraMessageBox.Show(sel.Mensaje);
                    }
                }
                else
                {
                    MensajeCargando(2);
                    XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
                }
            }
            else
            {
                MensajeCargando(2);
                XtraMessageBox.Show("No se ha seleccionado Sucursal");
            }
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
        private int DiasMes(int vAño,int vMes)
        {
            int diasMes = System.DateTime.DaysInMonth(vAño, vMes);
            return diasMes;
        }
    }
}