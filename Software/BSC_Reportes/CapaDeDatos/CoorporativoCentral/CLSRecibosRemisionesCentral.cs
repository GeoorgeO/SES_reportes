using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSRecibosRemisionesCentral : ConexionBase
    {

       
        public int RecibosId { get; set; }
        public int TicketId { get; set; }
        public int CajaId { get; set; }
        public decimal RecibosTotal { get; set; }
        public string ReciboTotalLetra { get; set; }
        public string ReciboFecha { get; set; }
        public int ClienteId { get; set; }
        public int UsuariosId { get; set; }
        public int DocumentosId { get; set; }
        public string ReciboConcepto { get; set; }
        public int CortesZRecibosId { get; set; }
        public int FormasdePagoCobranzaId { get; set; }
        public int RecibosAsignado { get; set; }


        public void MtdActualizarRecibosRemisiones()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_RecibosRemisiones_General";
                _dato.Entero = RecibosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "RecibosId");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.DecimalValor = RecibosTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "RecibosTotal");
                _dato.CadenaTexto = ReciboTotalLetra;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ReciboTotalLetra");
                _dato.CadenaTexto = ReciboFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ReciboFecha");
                _dato.Entero = ClienteId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ClienteId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.Entero = DocumentosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DocumentosId");
                _dato.CadenaTexto = ReciboConcepto;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ReciboConcepto");
                _dato.Entero = CortesZRecibosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecibosId");
                _dato.DecimalValor = FormasdePagoCobranzaId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "FormasdePagoCobranzaId");
                _dato.DecimalValor = RecibosAsignado;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "RecibosAsignado");
                

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
