using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Entradas:ConexionBase
    {
        public string UsuariosLogin { get;  set; }
        public int? SucursalesId { get;  set; }
        public int? UsuariosId { get;  set; }
        public int? EntradaMercanciaTipoId { get;  set; }
        public int? EntradaMercanciaUnidades { get;  set; }
        public decimal? EntradaMercanciaSub0 { get;  set; }
        public decimal? EntradaMercanciaSub16 { get;  set; }
        public decimal? EntradaMercanciaIva { get;  set; }
        public decimal? EntradaMercanciaTotal { get;  set; }
        public string Observaciones { get;  set; }
        public string Referencias { get;  set; }
        public int? EntradasMercanciaId { get;  set; }
        public int? EntradasMercanciaArticuloUltimoIde { get;  set; }
        public string ArticuloCodigo { get;  set; }
        public int? EntradasMercanciaArticuloCantidad { get;  set; }
        public decimal? EntradasMercanciaArticuloSub0 { get;  set; }
        public decimal? EntradasMercanciaArticuloSub16 { get;  set; }
        public decimal? EntradasMercanciaArticuloIva { get;  set; }
        public decimal? EntradasMercanciaArticuloTotal { get;  set; }
        public decimal? ArticuloCostoReposicion { get;  set; }
        public decimal? ArticuloCostoAdquisicion { get;  set; }
        public int? Registros { get;  set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        // Select
        public void MtdSeleccionarResponsable()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_UsuarioResponsableSelect";
                _dato.CadenaTexto = this.UsuariosLogin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
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
        public void MtdSeleccionarTipoEntrada()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_TipoEntradaSelect";
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
        public void MtdSeleccionarEntradaEncabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_Select";
                _dato.Entero = this.EntradasMercanciaId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaId");
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
        public void MtdSeleccionarEntradaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_Articulos_Select";
                _dato.Entero = this.EntradasMercanciaId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaId");
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
        public void MtdSeleccionarEntradaExistencia()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_ExistenciaSelect";
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
        public void MtdSeleccionarEntradaBuscar()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                string Valor = string.Empty;
                if(EntradasMercanciaId!=null)
                {
                    Valor = EntradasMercanciaId.ToString();
                }
                _conexion.NombreProcedimiento = "Inventarios_Entradas_Buscar_Select";
                _dato.CadenaTexto = Valor;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EntradaMercanciaId");
                _dato.Entero = this.Registros;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Registros");
                _dato.CadenaTexto = this.FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = this.FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
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
        public void MtdInsertarEntrada()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_Insert";
                _dato.Entero = SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = UsuariosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.Entero = EntradaMercanciaTipoId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaTipoId");
                _dato.Entero = EntradaMercanciaUnidades;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaUnidades");
                _dato.DecimalValor = EntradaMercanciaSub0;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaSub0");
                _dato.DecimalValor = EntradaMercanciaSub16;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaSub16");
                _dato.DecimalValor = EntradaMercanciaIva;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaIva");
                _dato.DecimalValor = EntradaMercanciaTotal;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaTotal");
                _dato.CadenaTexto = Observaciones;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Observaciones");
                _dato.CadenaTexto = Referencias;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Referencias");
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
        public void MtdInsertarEntradaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_Articulos_Insert";
                _dato.Entero = EntradasMercanciaId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaId");
                _dato.Entero = SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = EntradasMercanciaArticuloUltimoIde;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = EntradasMercanciaArticuloCantidad;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloCantidad");
                _dato.DecimalValor = EntradasMercanciaArticuloSub0;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloSub0");
                _dato.DecimalValor = EntradasMercanciaArticuloSub16;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloSub16");
                _dato.DecimalValor = EntradasMercanciaArticuloIva;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloIva");
                _dato.DecimalValor = EntradasMercanciaArticuloTotal;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloTotal");
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
        public void MtdInsertarEntradaCosteo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Entradas_ArticulosCosto_Insert";
                _dato.Entero = EntradasMercanciaId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = EntradasMercanciaArticuloUltimoIde;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloUltimoIde");
                _dato.Entero = EntradasMercanciaArticuloCantidad;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloCantidad");
                _dato.DecimalValor = ArticuloCostoReposicion;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCostoReposicion");
                _dato.DecimalValor = ArticuloCostoAdquisicion;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCostoAdquisicion");
                
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
