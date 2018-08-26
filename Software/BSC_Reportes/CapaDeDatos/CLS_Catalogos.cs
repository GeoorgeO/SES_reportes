using CapadeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Catalogos: ConexionBase
    {
        public String Tabla { get; set; }
        public int Actualiza { get; set; }
        public int Registros { get; set; }
        public int Actualizados { get; set; }
        public String status { get; set; }

        public void MtdSeleccionarCatalogos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Empleados_Select";
                _dato.CadenaTexto = Tabla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tabla");
                _dato.Entero = Actualiza;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Actualiza");
                _dato.Entero = Registros;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Registros");
                _dato.Entero = Actualizados;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Actualizados");
                _dato.CadenaTexto = status;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "status");
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
