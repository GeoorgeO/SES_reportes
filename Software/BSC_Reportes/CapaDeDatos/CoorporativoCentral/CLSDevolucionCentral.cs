using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionCentral: ConexionBase
    {
        public Decimal DevolucionId { get; set; }
        public Decimal CajaId { get; set; }
        public int TicketId { get; set; }
        public Decimal UsuariosId { get; set; }
        public String DevolucionFecha { get; set; }
        public Decimal DevolucionSubtotal0 { get; set; }
        public Decimal DevolucionSubtotal16 { get; set; }
        public Decimal DevolucionIva { get; set; }
        public Decimal DevolucionTotal { get; set; }
        public int DevolucionAsignadoCorte { get; set; }
        public Decimal CorteZId { get; set; }

        public void MtdActualizarDevolucion()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_Devolucion_General";
                _dato.DecimalValor = DevolucionId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionId");
                _dato.DecimalValor = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaId");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.DecimalValor = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "UsuariosId");
                _dato.CadenaTexto = DevolucionFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DevolucionFecha");
                _dato.DecimalValor = DevolucionSubtotal0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionSubtotal0");
                _dato.DecimalValor = DevolucionSubtotal16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionSubtotal16");
                _dato.DecimalValor = DevolucionIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionIva");
                _dato.DecimalValor = DevolucionTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionTotal");
                _dato.Entero = DevolucionAsignadoCorte;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionAsignadoCorte");
                _dato.DecimalValor = CorteZId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CorteZId");

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
