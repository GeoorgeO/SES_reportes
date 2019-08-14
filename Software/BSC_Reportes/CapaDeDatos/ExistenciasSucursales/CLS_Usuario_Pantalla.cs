using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Usuario_Pantalla : ConexionBase
    {
        public int? UsuariosId { get; set; }
        public int? InventarioPantallaId { get; set; }
     
        public string v_passwo_usu { get; set; }
        public string c_codigo_usu { get; set; }

        public void MtdSeleccionarUsuarioPantalla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Accesos_Select";
                _dato.CadenaTexto = this.c_codigo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = this.InventarioPantallaId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "InventarioPantallaId");
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

        public void MtdSeleccionarUsuarioLogin()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_UsuarioAccesosSelect";
                _dato.CadenaTexto = c_codigo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_usu");
                _dato.CadenaTexto = v_passwo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_passwo_usu");
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
