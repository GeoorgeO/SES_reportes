using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_SalidaMercanciaTipo_Central: ConexionBase
    {
        public int SalidaMercanciaTipoId { get; set; }
        public string SalidaMercanciaTipoDescripcion { get; set; }

        public void MtdActualizarSalidaMercanciaTipo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_SalidaMercanciaTipoGeneral";
                _dato.Entero = SalidaMercanciaTipoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaTipoId");
                _dato.CadenaTexto = SalidaMercanciaTipoDescripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SalidaMercanciaTipoDescripcion");

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
