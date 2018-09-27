using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionMayoreoCentral : ConexionBase
    {

        
        public int DevolucionId { get; set; }
        public int CajaId { get; set; }
        public int TicketId { get; set; }
        public int UsuariosId { get; set; }
        public int Clienteid { get; set; }
        public string DevolucionFecha { get; set; }
        public decimal DevolucionSubtotal0 { get; set; }
        public decimal DevolucionSubtotal16 { get; set; }
        public decimal DevolucionIva { get; set; }
        public decimal DevolucionDescuento { get; set; }
        public decimal DevolucionTotal { get; set; }
        public string TicketTotalLetra { get; set; }
        public string DevolucionConcepto { get; set; }
        public int DevolucionAsignado { get; set; }
        public int CortesZRecibosId { get; set; }
        public string NC_Concepto { get; set; }



        public void MtdActualizarDevolucionMayoreo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_DevolucionArticulo_General";
                _dato.Entero = DevolucionId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.DecimalValor = Clienteid;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Clienteid");
                _dato.CadenaTexto = DevolucionFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DevolucionFecha");
                _dato.DecimalValor = DevolucionSubtotal0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionSubtotal0");
                _dato.DecimalValor = DevolucionSubtotal16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionSubtotal16");
                _dato.DecimalValor = DevolucionIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionIva");
                _dato.DecimalValor = DevolucionDescuento;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionDescuento");
                _dato.DecimalValor = DevolucionTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionTotal");
                _dato.CadenaTexto = TicketTotalLetra;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TicketTotalLetra");
                _dato.CadenaTexto = DevolucionConcepto;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DevolucionConcepto");
                _dato.DecimalValor = DevolucionAsignado;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionAsignado");
                _dato.DecimalValor = CortesZRecibosId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecibosId");
                _dato.CadenaTexto = NC_Concepto;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "NC_Concepto");
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
