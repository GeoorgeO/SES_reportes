using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_CProveedor_Central: ConexionBase
    {
        public int CProveedorId { get; set; }
        public string CProveedorNombre { get; set; }
        public string CProveedorFecha { get; set; }
        public string CProveedorActivo { get; set; }
        public int? CProveedorPadreId { get; set; }
        public int CProveedorTieneElementos { get; set; }

        public void MtdActualizarCProveedor()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CProveedorGeneral";
                _dato.Entero = CProveedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CProveedorId");
                _dato.CadenaTexto = CProveedorNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CProveedorNombre");
                _dato.CadenaTexto = CProveedorFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CProveedorFecha");
                _dato.CadenaTexto = CProveedorActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CProveedorActivo");
                _dato.Entero = CProveedorPadreId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CProveedorPadreId");
                _dato.Entero = CProveedorTieneElementos;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CProveedorTieneElementos");

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
