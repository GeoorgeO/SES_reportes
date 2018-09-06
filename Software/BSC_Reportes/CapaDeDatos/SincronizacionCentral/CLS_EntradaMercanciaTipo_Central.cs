using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_EntradaMercanciaTipo_Central: ConexionBase
    {
        public int EntradaMercanciaTipoId { get; set; }
        public string EntradaMercanciaTipoDescripcion { get; set; }

        public void MtdActualizarEntradaMercanciaTipo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_EntradaMercanciaTipoGeneral";
                _dato.Entero = EntradaMercanciaTipoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaTipoId");
                _dato.CadenaTexto = EntradaMercanciaTipoDescripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EntradaMercanciaTipoDescripcion");
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
