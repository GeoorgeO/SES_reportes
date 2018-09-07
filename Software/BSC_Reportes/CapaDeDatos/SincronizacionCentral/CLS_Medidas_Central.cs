using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Medidas_Central: ConexionBase
    {
        public int MedidasId { get; set; }
        public string MedidasNombre { get; set; }
        public string MedidasAlias { get; set; }

        public void MtdActualizarMedidas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_MedidasGeneral";
                _dato.Entero = MedidasId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "MedidasId");
                _dato.CadenaTexto = MedidasNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MedidasNombre");
                _dato.CadenaTexto = MedidasAlias;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MedidasAlias");

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
