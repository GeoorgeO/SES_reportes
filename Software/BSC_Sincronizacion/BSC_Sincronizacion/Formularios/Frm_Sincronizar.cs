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

namespace BSC_Sincronizacion
{
    public partial class Frm_Sincronizar : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Sincronizar()
        {
            InitializeComponent();
        }

        private void Frm_Sincronizar_Shown(object sender, EventArgs e)
        {
            dtFechaInicio.EditValue = DateTime.Now;
            dtFechaFin.EditValue = DateTime.Now;



        }
        public void asignartablaagrid()
        {
            
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            
                ModificaActualizaCentral();
            
        }

        private void btnDataBase_Click(object sender, EventArgs e)
        {
            Frm_Conexiones frm = new Frm_Conexiones();
            frm.ShowDialog();
        }

        private void ModificaActualizaCentral()
        {
            for (int i = 0; i < length; i++)
            {
                switch (switch_on)
                {
                    case "Articulo":
                        MtdArticulo();
                        break;
                    default:
                }
            } 
            

            
            //MtdArticuloMedidas();
            //MtdCaja();
            //MtdCCliente();
            //MtdCliente();
            //MtdCondicionesPagos();
            //MtdCProveedor();
            //MtdEntradaMercanciaTipo();
            //MtdFamilia();
            //MtdFormasdePago();
            //MtdIva();
            //MtdLocalidad();
            //MtdMedidas();
            //MtdMetodoPagos();
            //MtdMoneda();
            //MtdProveedor();
            //MtdRoles();
            //MtdSalidaMercanciaTipo();
            //MtdSucursales();
            //MtdTarifa();
            //MtdUsuarios();
            //MtdVendedor();

        }
    }
}