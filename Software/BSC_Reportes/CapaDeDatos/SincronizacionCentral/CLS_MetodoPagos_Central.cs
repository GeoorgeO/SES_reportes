using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_MetodoPagos_Central: ConexionBase
    {
        public int MetodoPagosId { get; set; }
        public string MetodoPagosNombre { get; set; }
        public string MetodoPagosFecha { get; set; }
        public String MetodoPagosActivo { get; set; }

        public void MtdActualizarMetodoPagos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_MetodoPagosGeneral";
                _dato.Entero = MetodoPagosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "MetodoPagosId");
                _dato.CadenaTexto = MetodoPagosNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MetodoPagosNombre");
                _dato.CadenaTexto = MetodoPagosFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MetodoPagosFecha");
                _dato.CadenaTexto = MetodoPagosActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MetodoPagosActivo");

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
