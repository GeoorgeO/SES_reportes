using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCortesZRecargasTicketsCentral : ConexionBase
    {

        public int CortesZRecargasId { get; set; }
        public decimal CajaId { get; set; }
        public int CortesZRecargasTicketsInicio { get; set; }
        public int CortesZRecargasTicketsFin { get; set; }


        public void MtdActualizarCortesZRecargasTickets()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CortesZRecargasTickets_General";
                _dato.Entero = CortesZRecargasId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecargasId");
                _dato.DecimalValor = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaId");
                _dato.Entero = CortesZRecargasTicketsInicio;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecargasTicketsInicio");
                _dato.Entero = CortesZRecargasTicketsFin;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecargasTicketsFin");
                
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
