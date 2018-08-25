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
    }
}