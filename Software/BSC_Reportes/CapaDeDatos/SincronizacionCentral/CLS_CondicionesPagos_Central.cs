using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_CondicionesPagos_Central: ConexionBase
    {
        public int CondicionesPagosId { get; set; }
        public string CondicionesPagosNombre { get; set; }
        public string CondicionesPagosCantidad { get; set; }
        public int CondicionesPagosAfectacion { get; set; }
        public int CondicionesPagosFecha { get; set; }
        public string CondicionesPagosActivo { get; set; }

        public void MtdActualizarCondicionesPagos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CondicionesPagosGeneral";
                _dato.Entero = CondicionesPagosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CondicionesPagosId");
                _dato.CadenaTexto = CondicionesPagosNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CondicionesPagosNombre");
                _dato.CadenaTexto = CondicionesPagosCantidad;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CondicionesPagosCantidad");
                _dato.Entero = CondicionesPagosAfectacion;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CondicionesPagosAfectacion");
                _dato.Entero = CondicionesPagosFecha;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CondicionesPagosFecha");
                _dato.CadenaTexto = CondicionesPagosActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CondicionesPagosActivo");

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
