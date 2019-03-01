using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
   public  class CLS_Pantallas : ConexionBase
    {
        public string UsuariosLogin { get; set; }
        public int pantallasid { get; set; }
        public int botonesId { get; set; }

       
        public void Mtdseleccionarpantallas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pantallas_Select";

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


        public void Mtdseleccionarbotones()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_UsuarioBotones_Select";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = pantallasid;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "pantallasid");
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

        public void Mtdeliminararbotones()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Usuariopantallabotones_delete";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = pantallasid;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "pantallasid");
                
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

        public void Mtdinsertarbotones()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Usuariopantallabotones_insert";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = pantallasid;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "pantallasid");
                _dato.Entero = botonesId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "botonesId");
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

        public void Mtdselecionarbotonespantalla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_UsuarioBotonesPantalla_Select";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = pantallasid;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "pantallasid");
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
