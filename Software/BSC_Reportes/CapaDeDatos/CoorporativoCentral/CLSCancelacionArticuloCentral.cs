using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCancelacionArticuloCentral: ConexionBase
    {
        public int CancelacionId { get; set; } 
        public int CajaId { get; set; }
        public int CancelacionArticuloUltimoIde { get; set; }
        public int TicketId { get; set; }
        public String ArticuloCodigo { get; set; }
        public Decimal CancelacionArticuloPrecio { get; set; }
        public  int CancelacionArticuloCantidad { get; set; }
        public Decimal CancelacionArticuloSubtotal { get; set; }
        public Decimal CancelacionArticuloIva { get; set; }
        public Decimal CancelacionArticuloTotalLinea { get; set; }

        public void MtdActualizarCancelacionArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CancelacionArticulo_General";
                _dato.Entero = CancelacionId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CancelacionId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = CancelacionArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CancelacionArticuloUltimoIde");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.DecimalValor = CancelacionArticuloPrecio;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionArticuloPrecio");
                _dato.DecimalValor = CancelacionArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionArticuloCantidad");
                _dato.DecimalValor = CancelacionArticuloSubtotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionArticuloSubtotal");
                _dato.DecimalValor = CancelacionArticuloIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionArticuloIva");
                _dato.DecimalValor = CancelacionArticuloTotalLinea;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionArticuloTotalLinea");
                

                _conexionC.EjecutarDataset();

                if (_conexionC.Exito)
                {
                    Datos = _conexionC.Datos;
                }
                else
                {
                    Mensaje = _conexionC.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

    }
}
