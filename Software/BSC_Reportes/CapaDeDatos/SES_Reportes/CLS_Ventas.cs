using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Ventas : ConexionBase
    {
        public string EFamilia { get; set; }
        public string ESucursal { get; set; }
        public string FechaFin { get; set; }
        public string FechaInicio { get; set; }
        public int? ProveedorId { get; set; }

        public void MtdSeleccionarVentasProveedores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_VentasFamiliaProveedor_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ESucursal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ESucursal ");
                _dato.CadenaTexto = EFamilia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EFamilia");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
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
