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
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_VentasFamiliaProveedor_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ESucursal;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ESucursal ");
                _dato.CadenaTexto = EFamilia;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EFamilia");
                _conexionR.EjecutarDataset();

                if (_conexionR.Exito)
                {
                    Datos = _conexionR.Datos;
                }
                else
                {
                    Mensaje = _conexionR.Mensaje;
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
