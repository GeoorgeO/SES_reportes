using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_ConfigInventario:ConexionBase
    {
        public int? InventarioCiegoArticulosDias { get;  set; }
        public int? InventarioCiegoActivos { get;  set; }
        public int? InventarioCiegoRotacion { get;  set; }
        public int? InventarioCiegoFoliosEnviados { get;  set; }
        public int? InventarioCiegoGeneraFolios { get;  set; }
        public string InventarioRutaArchivosPDF { get; set; }
        public int InventarioCiegoCodigosAleatorios { get; set; }
        public int InventarioCiegoPeriodo { get; set; }

        public void MtdSeleccionarArticulosActivos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_ArticulosActivosSelect";
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
        public void MtdSeleccionarConfiguracion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_Parametros_Select";
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
        public void MtdSeleccionarAvance()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_CalculaAvance_Select";
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
        public void MtdActualizaAvance()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_InicializaInventario_Select";
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
        public void MtdActualizaConfig()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_ParametrosUpdate";
                _dato.Entero = this.InventarioCiegoRotacion;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoRotacion");
                _dato.Entero = this.InventarioCiegoPeriodo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoPeriodo");
                _dato.Entero = this.InventarioCiegoActivos;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoActivos");
                _dato.Entero = this.InventarioCiegoArticulosDias;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoArticulosDias");
                _dato.Entero = this.InventarioCiegoFoliosEnviados;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFoliosEnviados");
                _dato.Entero = this.InventarioCiegoGeneraFolios;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoGeneraFolios");
                _dato.Entero = this.InventarioCiegoCodigosAleatorios;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCodigosAleatorios");
                _dato.CadenaTexto = this.InventarioRutaArchivosPDF;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioRutaArchivosPDF");
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
