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
            AplicaCambiosCancelacion();
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

        //////////////////////////////////////////////////////////////////Metodo Cancelacion
        private void AplicaCambiosCancelacion()
        {
            CLSCancelacionLocal SelArt = new CLSCancelacionLocal();

            //lEstatus.Text = "Recolectando datos";
            Application.DoEvents();

            SelArt.FechaInicio = "20130726";//DateTime.Today.Year.ToString() + DosCero(DateTime.Today.Month.ToString()) + DosCero(DateTime.Today.Day.ToString());
            SelArt.FechaFin = "20130726";//DateTime.Today.Year.ToString() + DosCero(DateTime.Today.Month.ToString()) + DosCero(DateTime.Today.Day.ToString());
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
                    SincronizaCancelacion(SelArt.Datos.Rows[i][0].ToString(), SelArt.Datos.Rows[i][1].ToString(), SelArt.Datos.Rows[i][2].ToString(),
                        SelArt.Datos.Rows[i][3].ToString(), Convert.ToDateTime(SelArt.Datos.Rows[i][4]), SelArt.Datos.Rows[i][5].ToString()
                        , SelArt.Datos.Rows[i][6].ToString(), SelArt.Datos.Rows[i][7].ToString(), SelArt.Datos.Rows[i][8].ToString()
                        , SelArt.Datos.Rows[i][9].ToString(), SelArt.Datos.Rows[i][10].ToString(), SelArt.Datos.Rows[i][11].ToString(), SelArt.Datos.Rows[i][12].ToString());
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
        private void SincronizaCancelacion(string CancelacionId, string CajaId, string TicketId, string UsuarioId, DateTime CancelacionFecha, string CancelacionSubtotal0, 
            string CancelacionSubtotal16, string CancelacionIva
            , string CancelacionTotal, string CancelacionAsignadoCorte, string CorteZId, string CancelacionesTotal, string TicketMayoreoId)
        {
            CLS_Cancelacion_Central UdpArt = new CLS_Cancelacion_Central();

            UdpArt.CancelacionId = Convert.ToInt32(CancelacionId);
            UdpArt.CajaId = Convert.ToInt32(CajaId);
            UdpArt.TicketId = Convert.ToInt32(TicketId);
            UdpArt.UsuarioId = Convert.ToInt32(UsuarioId);
            UdpArt.CancelacionFecha = CancelacionFecha.Date.Year.ToString() + DosCero(CancelacionFecha.Date.Month.ToString()) + DosCero(CancelacionFecha.Date.Day.ToString()); 
            UdpArt.CancelacionSubtotal0 = Convert.ToDecimal(CancelacionSubtotal0);
            UdpArt.CancelacionSubtotal16 = Convert.ToDecimal(CancelacionSubtotal16);
            UdpArt.CancelacionIva = Convert.ToDecimal(CancelacionIva);
            UdpArt.CancelacionTotal = Convert.ToDecimal(CancelacionTotal);
            if (CancelacionAsignadoCorte=="True")
            {
                UdpArt.CancelacionAsignadoCorte = 1;
            }
            else
            {
                UdpArt.CancelacionAsignadoCorte = 0;
            }
            if (CorteZId == String.Empty)
            {
                UdpArt.CorteZId = 0;
            }
            else
            {
                UdpArt.CorteZId = Convert.ToInt32(CorteZId);
            }
            
            if (CancelacionesTotal == "True")
            {
                UdpArt.CancelacionesTotal = 1;
            }
            else
            {
                UdpArt.CancelacionesTotal = 0;
            }
            
            UdpArt.TicketMayoreoId = Convert.ToInt32(TicketMayoreoId);

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
        //////////////////////////////////////////////////////////////////Metodo CancelacionArticulos




    }
}
