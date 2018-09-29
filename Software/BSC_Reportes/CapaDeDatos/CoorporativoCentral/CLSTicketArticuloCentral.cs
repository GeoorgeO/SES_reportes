using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSTicketArticuloCentral : ConexionBase
    {

        public int TicketId { get; set; }
        public int CajaId { get; set; }
        public int TicketArticuloUltimoIde { get; set; }
        public string ArticuloCodigo { get; set; }
        public int TarifaId { get; set; }
        public int MedidasId { get; set; }
        public decimal TicketArticuloCosto { get; set; }
        public decimal TicketArticuloPrecio { get; set; }
        public int TicketArticuloCantidad { get; set; }
        public int TicketArticuloCantidadDevolucion { get; set; }
        public int TicketArticuloCantidadCancelada { get; set; }
        public decimal TicketArticuloSubtotal { get; set; }
        public decimal TicketArticuloIva { get; set; }
        public decimal TicketArticuloTotalLinea { get; set; }
        public decimal TicketArticuloDescuento { get; set; }
        public decimal TicketArticuloPrecioDescuento { get; set; }
        public decimal TicketArticuloIvaDescuento { get; set; }
        public decimal TicketArticuloTotal { get; set; }

        public void MtdActualizarTicketArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_TicketArticulo_General";
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = TicketArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = TarifaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TarifaId");
                _dato.Entero = MedidasId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "MedidasId");
                _dato.DecimalValor = TicketArticuloCosto;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloCosto");
                _dato.DecimalValor = TicketArticuloPrecio;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloPrecio");
                _dato.Entero = TicketArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketArticuloCantidad");
                _dato.Entero = TicketArticuloCantidadDevolucion;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketArticuloCantidadDevolucion");
                _dato.Entero = TicketArticuloCantidadCancelada;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketArticuloCantidadCancelada");
                _dato.DecimalValor = TicketArticuloSubtotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloSubtotal");
                _dato.DecimalValor = TicketArticuloIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloIva");
                _dato.DecimalValor = TicketArticuloTotalLinea;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloTotalLinea");
                _dato.DecimalValor = TicketArticuloDescuento;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloDescuento");
                _dato.DecimalValor = TicketArticuloPrecioDescuento;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloPrecioDescuento");
                _dato.DecimalValor = TicketArticuloIvaDescuento;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloIvaDescuento");
                _dato.DecimalValor = TicketArticuloTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "TicketArticuloTotal");

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
