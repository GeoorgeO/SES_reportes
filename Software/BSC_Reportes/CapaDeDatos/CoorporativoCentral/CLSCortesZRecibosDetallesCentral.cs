using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCortesZRecibosDetallesCentral : ConexionBase
    {

        public int CortesZRecibosId { get; set; }
        public int CortesZRecibosInicio { get; set; }
        public int CortesZRecibosFin { get; set; }
        public int CortesZNCreditoInicio { get; set; }
        public int CortesZNCreditoFin { get; set; }



        public void MtdActualizarCortesZRecibosDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CortesZRecibosDetalles_General";
                _dato.Entero = CortesZRecibosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecibosId");
                _dato.Entero = CortesZRecibosInicio;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecibosInicio");
                _dato.Entero = CortesZRecibosFin;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecibosFin");
                _dato.Entero = CortesZNCreditoInicio;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZNCreditoInicio");
                _dato.Entero = CortesZNCreditoFin;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZNCreditoFin");
                
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
