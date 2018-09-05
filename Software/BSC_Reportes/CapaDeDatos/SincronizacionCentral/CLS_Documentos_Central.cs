using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_Documentos_Central: ConexionBase
    {
        public int DocumentosId { get; set; }
        public string DocumentosNombre { get; set; }

        public void MtdActualizarDocumentos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_DocumentosGeneral";
                _dato.Entero = DocumentosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DocumentosId");
                _dato.CadenaTexto = DocumentosNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DocumentosNombre");
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
