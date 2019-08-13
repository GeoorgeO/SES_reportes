using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_InventarioCiego:ConexionBase
    {
        public int? InventarioCiegoFolio { get;  set; }
        public string InventarioCiegoCodigo { get;  set; }
        public int? InventarioCiegoCantidad { get;  set; }
        public int? InventarioCiegoCantidadPrimerConteo { get;  set; }
        public int? InventarioCiegoCantidadSegundoConteo { get;  set; }
        public int? InventarioCiegoCantidadSistema { get;  set; }
        public int? InventarioCiegoCantidadContraloria { get;  set; }
        public string EEstatus { get;  set; }
        public string Status { get;  set; }
        public int? InventarioCiegoEntrada { get;  set; }
        public int? InventarioCiegoSalida { get;  set; }
        public int SucursalesId { get; set; }

        //Select
        public void MtdSeleccionarArticulosExistencia()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_ArticulosExitencia_Select";
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
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
        public void MtdSeleccionarArticulosPendientes()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Config_ArticulosPendientes_Select";
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
        public void MtdSeleccionarArticulosAleatorios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_AleatorioFoliosDetalles_Select";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
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
        public void MtdSeleccionarFoliosIniciados()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosIniciados_Select";
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
        public void MtdSeleccionarFolioPendiente()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_Buscar_Folios_Select";
                _dato.CadenaTexto = this.EEstatus;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EEstatus");
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
        public void MtdSeleccionarFolio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_Folios_Select";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
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
        public void MtdSeleccionarFolioDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosDetalles_Select";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
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
        public void MtdSeleccionarFolioDetallesInicio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosDetalles_Inicio_Select";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
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
        //Insert
        public void MtdInsertarFolio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_Folios_Insert";
                _dato.Entero = this.SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
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
        public void MtdInsertarFolioDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosDetalles_Insert";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
                _dato.Entero = this.InventarioCiegoCantidad;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidad");
                _dato.Entero = this.InventarioCiegoCantidadPrimerConteo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadPrimerConteo");
                _dato.Entero = this.InventarioCiegoCantidadSegundoConteo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadSegundoConteo");
                _dato.Entero = this.InventarioCiegoCantidadSistema;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadSistema");
                _dato.Entero = this.InventarioCiegoCantidadContraloria;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadContraloria");
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
        //Update
        public void MtdActualizarFolioDetallesPrimer()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventario_Ciego_FoliosDetalles1_Update";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
                _dato.Entero = this.InventarioCiegoCantidadPrimerConteo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadPrimerConteo");
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
        public void MtdActualizarFolioDetallesSegundo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventario_Ciego_FoliosDetalles2_Update";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
                _dato.Entero = this.InventarioCiegoCantidadSegundoConteo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadSegundoConteo");
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
        public void MtdActualizarFolioDetallesContraloria()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventario_Ciego_FoliosDetalles3_Update";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
                _dato.Entero = this.InventarioCiegoCantidadContraloria;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoCantidadContraloria");
                _dato.Entero = this.InventarioCiegoEntrada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoEntrada");
                _dato.Entero = this.InventarioCiegoSalida;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoSalida");
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
        public void MtdActualizarInventarioCodigo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventario_Ciego_MarcaCodigo_Update";
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
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
        public void MtdActualizarFolioStatus()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosStatus_Update";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.Status;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Status");
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
        public void MtdActualizarDetallesAleatorio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Ciego_FoliosDetalles_Aleatorio_Update";
                _dato.Entero = this.InventarioCiegoFolio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioCiegoFolio");
                _dato.CadenaTexto = this.InventarioCiegoCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "InventarioCiegoCodigo");
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
