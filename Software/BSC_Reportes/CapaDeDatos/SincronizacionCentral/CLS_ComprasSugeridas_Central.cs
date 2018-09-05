using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_ComprasSugeridas_Central: ConexionBase
    {
        
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Centro { get; set; }
        public int Morelos { get; set; }

        public void MtdActualizarComprasSugeridas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_ComprasSugeridasGeneral";
                _dato.CadenaTexto = Codigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo");
                _dato.CadenaTexto = Descripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Descripcion");
                _dato.Entero = Centro;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "Centro");
                _dato.Entero = Morelos;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "Morelos");

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
