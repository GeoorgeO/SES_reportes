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
    public partial class Frm_AgregarArticulo : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pre_Pedidos FrmPrePedidos;

        public Frm_AgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text!=string.Empty && txtDescripcion.Text!=string.Empty)
            {
                FrmPrePedidos.vArticuloCodigo = txtCodigo.Text;
                FrmPrePedidos.vArticuloDescripcion = txtDescripcion.Text;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha llenado los campos requeridos","Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}