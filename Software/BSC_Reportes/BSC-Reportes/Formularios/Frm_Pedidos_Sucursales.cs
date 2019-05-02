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
    public partial class Frm_Pedidos_Sucursales : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pedidos_Sucursales()
        {
            InitializeComponent();
        }

        private void Frm_Pedidos_Sucursales_Load(object sender, EventArgs e)
        {
            CargarSucursales(1);
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
    }
}