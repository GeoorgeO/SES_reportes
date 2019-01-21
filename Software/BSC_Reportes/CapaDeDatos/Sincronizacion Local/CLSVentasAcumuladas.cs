using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSVentasAcumuladas:ConexionBase
    {
        public string fecha { get; set; }
        public int? IdFolio { get;  set; }
        public int opcion { get; set; }

        public void MtdInsertarVentaAcumulada()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "asp_VentaAcumulada_Insert";
                _dato.CadenaTexto = fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "fecha");
                _dato.Entero = opcion;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "opcion");
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
        public void MtdSeleccionarVentaAcumulada()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "asp_VentaAcumulada_Select";
                _dato.Entero = IdFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdFolio");
               
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
