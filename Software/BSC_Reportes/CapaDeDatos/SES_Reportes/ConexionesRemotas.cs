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
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "CentroCostos_ListaSucursales";
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
                _conexion.NombreProcedimiento = "CentroCostos_ListaSucursalesId";
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
        public void MtdSeleccionarConexionesRemotas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "CentroCostos_ConexionesRemotasSelect";
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
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "CentroCostos_ListaSucursalesIdUpdate";


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
        
    }
}
