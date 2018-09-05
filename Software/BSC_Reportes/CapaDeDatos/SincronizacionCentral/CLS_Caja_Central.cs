using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Caja_Central : ConexionBase
    {
        public int CajaId { get; set; }
	    public int SucursalesId { get; set; }
	    public int CajaNumero { get; set; }
	    public String CajaDescripcion { get; set; }
	    public int CajaReciboInicial { get; set; }
	    public Decimal CajaFondo { get; set; }
        public Decimal CajaMontoEfectivo { get; set; }
	    public Decimal CajaMontoTarjeta { get; set; }
        public Decimal CajaMontoVale { get; set; }
	    public String CajaFecha { get; set; }
        public int CajaUltimoTicket { get; set; }
	    public int CajaUltimaDevolucion { get; set; }
	    public int CajaUltimaCancelacion { get; set; }
	    public int CajaUltimoCorte { get; set; }
	    public int CajaUltimoRetiro { get; set; }
	    public int CajaUltimoTicketMayoreo { get; set; }
	    public int CajaUltimoDevolucionMayoreo { get; set; }
	   

        public void MtdActualizarCaja()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CajaGeneral";
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = CajaNumero;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaNumero");
                _dato.CadenaTexto = CajaDescripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CajaDescripcion");
                _dato.Entero = CajaReciboInicial;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaReciboInicial");
                _dato.DecimalValor = CajaFondo;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaFondo");
                _dato.DecimalValor = CajaMontoEfectivo;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaMontoEfectivo");
                _dato.DecimalValor = CajaMontoTarjeta;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaMontoTarjeta");
                _dato.DecimalValor = CajaMontoVale;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaMontoVale");
                _dato.CadenaTexto = CajaFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CajaFecha");
                _dato.Entero = CajaUltimoTicket;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimoTicket");
                _dato.Entero = CajaUltimaDevolucion;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimaDevolucion");
                _dato.Entero = CajaUltimaCancelacion;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimaCancelacion");
                _dato.Entero = CajaUltimoCorte;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimoCorte");
                _dato.Entero = CajaUltimoRetiro;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimoRetiro");
                _dato.Entero = CajaUltimoTicketMayoreo;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimoTicketMayoreo");
                _dato.Entero = CajaUltimoDevolucionMayoreo;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaUltimoDevolucionMayoreo");

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
