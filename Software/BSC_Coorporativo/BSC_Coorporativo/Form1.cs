using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDeDatos;

namespace BSC_Coorporativo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        public int ArticulosActualizados { get; set; }
        public int ArticulosError { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void AplicaCambiosArticulo()
        {
            CLSCancelacionLocal SelArt = new CLSCancelacionLocal();

            //lEstatus.Text = "Recolectando datos";
            Application.DoEvents();

            SelArt.FechaInicio = DateTime.Today.Year.ToString() + DosCero(DateTime.Today.Month.ToString()) + DosCero(DateTime.Today.Day.ToString());
            SelArt.FechaFin = DateTime.Today.Year.ToString() + DosCero(DateTime.Today.Month.ToString()) + DosCero(DateTime.Today.Day.ToString());
            SelArt.MtdSeleccionarCancelacion();
            if (SelArt.Exito == true)
            {
                /*ArticulosActualizados = 0;
                pbProgreso.Properties.Maximum = SelArt.Datos.Rows.Count;
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[2], SelArt.Datos.Rows.Count);
                GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Procesando");*/
                for (int i = 0; i < SelArt.Datos.Rows.Count; i++)
                {
                    Application.DoEvents();
                    //GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[3], ArticulosActualizados);
                    //lEstatus.Text = "Codigo Articulo [" + SelArt.Datos.Rows[i][0].ToString() + "]";
                    SincronizaCancelacion(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString());
                    //pbProgreso.Position = i + 1;
                }
                if (ArticulosError == 0)
                {
                    /*escritura.WriteLine("Finalizo sin errores Articulos.");
                    GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Actualizados");*/

                }
                else
                {
                    //GValCatalogos.SetRowCellValue(Fila, GValCatalogos.Columns[4], "Con Errores");
                }
            }
            else
            {
                //escritura.WriteLine("No se obtubieron datos de la tabla Articulos.");
            }
        }
        private void SincronizaCancelacion(string Codigo, string Descripcion)
        {
            CLS_Cancelacion_Central UdpArt = new CLS_Cancelacion_Central();
            UdpArt.ArticuloCodigo = Codigo;
            UdpArt.ArticuloDescripcion = Descripcion;

            UdpArt.MtdActualizarCancelacion();

            if (UdpArt.Exito.ToString() == "True")
            {
                ArticulosActualizados++;
            }
            else
            {
                ArticulosError++;
                //escritura.WriteLine("No se logro actualizar el articulo [" + Codigo + "] " + Descripcion);
            }
        }

    }
}
