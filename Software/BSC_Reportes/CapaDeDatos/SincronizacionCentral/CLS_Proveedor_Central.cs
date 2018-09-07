using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Proveedor_Central: ConexionBase
    {
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public string ProveedorPaterno { get; set; }
        public string ProveedorMaterno { get; set; }

        public void MtdActualizarProveedor()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_ProveedorGeneral";
                _dato.Entero = ProveedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ProveedorNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorNombre");
                _dato.CadenaTexto = ProveedorPaterno;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorPaterno");
                _dato.CadenaTexto = ProveedorMaterno;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorMaterno");

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
