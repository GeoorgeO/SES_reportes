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

namespace BSC_Inventarios
{
    public partial class Frm_Config_Inventario : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Config_Inventario()
        {
            InitializeComponent();
        }

        private void Frm_Config_Inventario_Shown(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarParametros();
            CalculaAvance();
        }

        private void CalculaAvance()
        {
            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarAvance();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    pBar.Properties.Maximum=Convert.ToInt32(sel.Datos.Rows[0]["TotalArticulos"].ToString());
                    txtArticulosActivos.Text= sel.Datos.Rows[0]["TotalArticulos"].ToString();
                    pBar.Position = Convert.ToInt32(sel.Datos.Rows[0]["TotalArticulosInventario"].ToString());
                    lblAvance.Text = "Proceso de Revision " + sel.Datos.Rows[0]["TotalArticulosInventario"].ToString() + " de " + sel.Datos.Rows[0]["TotalArticulos"].ToString();
                }
            }
        }

        private void CargarParametros()
        {
            CLS_ConfigInventario sel = new CLS_ConfigInventario();
            sel.MtdSeleccionarConfiguracion();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    txtRotacion.Text = sel.Datos.Rows[0]["InventarioCiegoRotacion"].ToString();
                    txtArticulosActivos.Text= sel.Datos.Rows[0]["InventarioCiegoActivos"].ToString();
                    txtArticuloDiarios.Text = sel.Datos.Rows[0]["InventarioCiegoArticulosDias"].ToString();
                    txtFoliosEnviados.Text = sel.Datos.Rows[0]["InventarioCiegoFoliosEnviados"].ToString();
                    txtCodigosAleatorios.Text = sel.Datos.Rows[0]["InventarioCiegoCodigosAleatorios"].ToString();
                    txtRutaArchivos.Text= sel.Datos.Rows[0]["InventarioRutaArchivosPDF"].ToString();
                    if (sel.Datos.Rows[0]["InventarioCiegoGeneraFolios"].ToString()=="True")
                    {
                        chkGeneraFolios.Checked = true;
                    }
                    else
                    {
                        chkGeneraFolios.Checked = false;
                    }
                    if (Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoPeriodo"].ToString()) == 1)
                    {
                        rgbPeriodo.SelectedIndex = 0;
                    }
                    else if (Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoPeriodo"].ToString()) == 2)
                    {
                        rgbPeriodo.SelectedIndex = 1;
                    }
                    else if (Convert.ToInt32(sel.Datos.Rows[0]["InventarioCiegoPeriodo"].ToString()) == 3)
                    {
                        rgbPeriodo.SelectedIndex = 2;
                    }

                }
            }
        }

        private void LimpiarCampos()
        {
            txtRotacion.Text = "0";
            txtArticulosActivos.Text = "0";
            txtArticuloDiarios.Text = "0";
            txtFoliosEnviados.Text = "0";
            chkGeneraFolios.Checked = false;
        }

        private void btnIniciaInventario_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Deseas Inicializar el avance de inventario?", "Inicializa Avance Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                DialogResult = XtraMessageBox.Show("¿Realmente Deseas Inicializar el avance de inventario?", "Inicializa Avance Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_ConfigInventario sel = new CLS_ConfigInventario();
                    sel.MtdActualizaAvance();
                    if (sel.Exito)
                    {
                        CalculaAvance();
                    }
                }
            }
        }
        private void btnCalculaArticulos_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtRotacion.Text) > 0)
            {
                if (Convert.ToInt32(txtArticulosActivos.Text) > 0)
                {
                    if(rgbPeriodo.SelectedIndex == 0)
                    {
                        txtArticuloDiarios.Text = Convert.ToString(Convert.ToInt32(txtArticulosActivos.Text) / ((365 * (Convert.ToInt32(txtRotacion.Text)*12)) / 12));
                    }
                    else if (rgbPeriodo.SelectedIndex == 1)
                    {
                        txtArticuloDiarios.Text = Convert.ToString(Convert.ToInt32(txtArticulosActivos.Text) / ((365 * Convert.ToInt32(txtRotacion.Text)) / 12));
                    }
                    if (rgbPeriodo.SelectedIndex == 2)
                    {
                        txtArticuloDiarios.Text = Convert.ToString(Convert.ToInt32(txtArticulosActivos.Text) / Convert.ToInt32(txtRotacion.Text));
                    }
                }
                else
                {
                    XtraMessageBox.Show("La articulos activos deben ser mayor a 0");
                }
            }
            else
            {
                XtraMessageBox.Show("La rotacion debe ser mayor a 0");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnCalculaArticulos.PerformClick();
            if(Convert.ToInt32(txtRotacion.Text)>0 && Convert.ToInt32(txtArticulosActivos.Text) > 0 && Convert.ToInt32(txtArticuloDiarios.Text) > 0 && txtRutaArchivos.Text!=string.Empty)
            {
                CLS_ConfigInventario sel = new CLS_ConfigInventario();
                sel.InventarioCiegoRotacion = Convert.ToInt32(txtRotacion.Text);
                sel.InventarioCiegoActivos = Convert.ToInt32(txtArticulosActivos.Text);
                sel.InventarioCiegoArticulosDias = Convert.ToInt32(txtArticuloDiarios.Text);
                sel.InventarioCiegoFoliosEnviados = Convert.ToInt32(txtFoliosEnviados.Text);
                sel.InventarioCiegoCodigosAleatorios = Convert.ToInt32(txtCodigosAleatorios.Text);
                sel.InventarioRutaArchivosPDF = txtRutaArchivos.Text;
                if (chkGeneraFolios.Checked==true)
                {
                    sel.InventarioCiegoGeneraFolios = 1;
                }
                else
                {
                    sel.InventarioCiegoGeneraFolios = 0;
                }
                if(rgbPeriodo.SelectedIndex==0)
                {
                    sel.InventarioCiegoPeriodo = 1;
                }
                else if(rgbPeriodo.SelectedIndex==1)
                {
                    sel.InventarioCiegoPeriodo = 2;
                }
                else if (rgbPeriodo.SelectedIndex == 2)
                {
                    sel.InventarioCiegoPeriodo = 3;
                }
                sel.MtdActualizaConfig();
                if (sel.Exito)
                {
                    XtraMessageBox.Show("Se han actualizado los datos con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por llenar");
            }
        }
        private void btnRuta_Click(object sender, EventArgs e)
        {
            XtraFolderBrowserDialog saveFileDialog = new XtraFolderBrowserDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivos.Text = saveFileDialog.SelectedPath;
            }
        }
    }
}