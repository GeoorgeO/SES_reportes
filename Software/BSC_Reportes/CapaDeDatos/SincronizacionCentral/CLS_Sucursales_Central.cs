using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Sucursales_Central: ConexionBase
    {
        public int SucursalesId { get; set; }
        public string SucursalesNombre { get; set; }
        public string SucursalesFecha { get; set; }
        public string SucursalesActivo { get; set; }
        public string SucursalesCalle { get; set; }
        public string SucursalesNInterior { get; set; }
        public string SucursalesnNExterior { get; set; }
        public string SucursalesColonia { get; set; }
        public int? LocalidadId { get; set; }
        

        public void MtdActualizarSucursales()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_SucursalesGeneral";
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.CadenaTexto = SucursalesNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesNombre");
                _dato.CadenaTexto = SucursalesFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesFecha");
                _dato.CadenaTexto = SucursalesActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesActivo");
                _dato.CadenaTexto = SucursalesCalle;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesCalle");
                _dato.CadenaTexto = SucursalesNInterior;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesNInterior");
                _dato.CadenaTexto = SucursalesnNExterior;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesnNExterior");
                _dato.CadenaTexto = SucursalesColonia;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SucursalesColonia");
                _dato.Entero = LocalidadId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "LocalidadId");

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
