using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cancelacion_Central: ConexionBase
    {
       
        public int CancelacionId { get; set; }
        public int CajaId { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
        public string CancelacionFecha { get; set; }
        public Decimal CancelacionSubtotal0 { get; set; }
        public Decimal CancelacionSubtotal16 { get; set; }
        public Decimal CancelacionIva { get; set; }
        public Decimal CancelacionTotal { get; set; }
        public int CancelacionAsignadoCorte { get; set; }
        public int? CorteZId { get; set; }
        public int CancelacionesTotal { get; set; }
        public int TicketMayoreoId { get; set; }
       

        public void MtdActualizarCancelacion()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_Cancelacion_General";
                _dato.Entero = CancelacionId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CancelacionId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.Entero = UsuarioId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuarioId");
                _dato.CadenaTexto = CancelacionFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CancelacionFecha");
                _dato.DecimalValor = CancelacionSubtotal0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionSubtotal0");
                _dato.DecimalValor = CancelacionSubtotal16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionSubtotal16");
                _dato.DecimalValor = CancelacionIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionIva");
                _dato.DecimalValor = CancelacionTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CancelacionTotal");
                _dato.Entero = CancelacionAsignadoCorte;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CancelacionAsignadoCorte");
                _dato.Entero = CorteZId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CorteZId");
                _dato.Entero = CancelacionesTotal;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CancelacionesTotal");
                _dato.Entero = TicketMayoreoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketMayoreoId");
                

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
