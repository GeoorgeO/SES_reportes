using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.SincronizacionCentral
{
    class CLS_Localidad_Central: ConexionBase
    {
        public int LocalidadId { get; set; }
        public string LocalidadNombre { get; set; }
        public string LocalidadCP { get; set; }
        public int MunicipioId { get; set; }

        public void MtdActualizarLocalidad()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_LocalidadGeneral";
                _dato.Entero = LocalidadId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "LocalidadId");
                _dato.CadenaTexto = LocalidadNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "LocalidadNombre");
                _dato.CadenaTexto = LocalidadCP;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "LocalidadCP");
                _dato.Entero = MunicipioId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "MunicipioId");

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
