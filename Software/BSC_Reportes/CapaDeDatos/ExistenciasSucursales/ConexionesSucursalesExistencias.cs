using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ConexionesSucursalesExistencias : ConexionBase
    {
        public int SucursalesId { get; set; }
        public string ServerID { get; set; }
        public string DataBaseID { get; set; }
        public string UserID { get; set; }
        public string PassID { get; set; }
        public string Codigo { get; set; }

        public void MtdSeleccionarSucursales()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_ListaSucursales";
                
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
        public void MtdSeleccionarSucursalesId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_ListaSucursalesId";
                
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
        public void MtdSeleccionarConexionesSucursales()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_ConexionesSucursalesSelect";
                _dato.Entero = this.SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "exepcion");
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
        public void MtdModificarConexion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_ListaSucursalesIdUpdate";


                _dato.Entero = this.SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.CadenaTexto = this.ServerID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ServerID");
                _dato.CadenaTexto = this.DataBaseID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DataBaseID");
                _dato.CadenaTexto = this.UserID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UserID");
                _dato.CadenaTexto = this.PassID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PassID");

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
        public void MtdInsertarConexion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_ListaSucursalesIdInsert";
                _dato.Entero = this.SucursalesId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.CadenaTexto = this.ServerID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ServerID");
                _dato.CadenaTexto = this.DataBaseID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DataBaseID");
                _dato.CadenaTexto = this.UserID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UserID");
                _dato.CadenaTexto = this.PassID;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PassID");

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
        public void MtdSeleccionarArticulo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_selectBusqArticulo";
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
        public void MtdSeleccionarArticuloId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_CS_selectBusqArticuloId";
                _dato.CadenaTexto = this.Codigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo");
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
