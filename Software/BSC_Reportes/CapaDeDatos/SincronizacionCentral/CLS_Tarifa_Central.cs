using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_Tarifa_Central: ConexionBase
    {
        public int TarifaId { get; set; }
        public string TarifaNombre { get; set; }
        public string TarifaFecha { get; set; }
        public Char TarifaActivo { get; set; }

        public void MtdActualizarTarifa()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_TarifaGeneral";
                _dato.Entero = TarifaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TarifaId");
                _dato.CadenaTexto = TarifaNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TarifaNombre");
                _dato.CadenaTexto = TarifaFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TarifaFecha");
                _dato.CaracterValor = TarifaActivo;
                _conexionC.agregarParametro(EnumTipoDato.Caracter, _dato, "TarifaActivo");

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
