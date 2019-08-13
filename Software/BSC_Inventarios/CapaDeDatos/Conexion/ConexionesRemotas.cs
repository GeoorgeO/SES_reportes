using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ConexionesRemotas:ConexionBase
    {
        public int SucursalesId { get; set; }
        public string ServerID { get; set; }
        public string DataBaseID { get; set; }
        public string UserID { get; set; }
        public string PassID { get; set; }

        public void MtdSeleccionarSucursales()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_CR_ListaSucursales";
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
        public void MtdSeleccionarSucursalesId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_CR_ListaSucursalesId";
                _dato.Entero = this.SucursalesId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
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
        public void MtdSeleccionarConexionesRemotas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);

            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_CR_ConexionesRemotasSelect";
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
        public void MtdModificarConexion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_CR_ListaSucursalesIdUpdate";


                _dato.Entero = this.SucursalesId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.CadenaTexto = this.ServerID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ServerID");
                _dato.CadenaTexto = this.DataBaseID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DataBaseID");
                _dato.CadenaTexto = this.UserID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UserID");
                _dato.CadenaTexto = this.PassID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PassID");

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
        public void MtdInsertarConexion()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_CR_ListaSucursalesIdInsert";
                _dato.Entero = this.SucursalesId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.CadenaTexto = this.ServerID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ServerID");
                _dato.CadenaTexto = this.DataBaseID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DataBaseID");
                _dato.CadenaTexto = this.UserID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UserID");
                _dato.CadenaTexto = this.PassID;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PassID");

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
