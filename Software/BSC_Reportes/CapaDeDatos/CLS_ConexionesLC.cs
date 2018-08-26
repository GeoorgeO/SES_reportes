using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapadeDatos
{
    public class CLS_ConexionesLC : ConexionBase
    {
        /******** Empleados *********/
        public int USERID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string lastname { get; set; }
        public string TITLE { get; set; }

        /********** Calibres *********/
        public int IdCalibre { get; set; }
        public string Calibre { get; set; }
        public string Codigo { get; set; }
        public int opcion { get; set; }
        public int IdUsuario { get; set; }

        /********** Catalogos *********/
        public String Tabla { get; set; }
        public int Actualiza { get; set; }
        public int Registros { get; set; }
        public int Actualizados { get; set; }
        public String status { get; set; }


        public void MtdSeleccionarCatalogosL()
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


        public void MtdSeleccionarEmpleadosL()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Empleados_Select";
                _dato.CadenaTexto = SSN;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SSN");
                _dato.CadenaTexto = Name;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Name");
                _dato.CadenaTexto = lastname;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "lastname");
                _dato.CadenaTexto = TITLE;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TITLE");
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
        public void MtdSeleccionarEmpleadosC()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "usp_Empleados_Select";
                _dato.CadenaTexto = SSN;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SSN");
                _dato.CadenaTexto = Name;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Name");
                _dato.CadenaTexto = lastname;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "lastname");
                _dato.CadenaTexto = TITLE;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TITLE");
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

        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SPR_CatCalibreSeleccionar";

                _dato.Entero = IdCalibre;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdCalibre");
                _dato.CadenaTexto = Calibre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Calibre");
                _dato.CadenaTexto = Codigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo");
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
        public void MtdEliminar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SPR_CatCalibreEliminar";

                _dato.Entero = IdCalibre;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdCalibre");
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
        public void MtdInsertar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SPR_CatCalibreInsertar";

                _dato.CadenaTexto = Calibre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Calibre");
                _dato.CadenaTexto = Codigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo");
                _dato.Entero = IdUsuario;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdUsuario");
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
        public void MtdActualizar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SPR_CatCalibreActualizar";

                _dato.Entero = IdCalibre;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdCalibre");
                _dato.CadenaTexto = Calibre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Calibre");
                _dato.CadenaTexto = Codigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo");
                _dato.Entero = IdUsuario;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdUsuario");

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
