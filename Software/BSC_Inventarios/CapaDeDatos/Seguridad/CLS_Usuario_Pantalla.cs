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
        public string UsuariosLogin { get;  set; }

        public void MtdSeleccionarUsuarioPantalla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Accesos_Select";
                _dato.CadenaTexto = this.UsuariosLogin;
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
        public void MtdSeleccionarUsuario()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Select";
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
        public void MtdSeleccionarPantallasDisponibles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Pantallas_Disponibles_Select";
                _dato.Entero = this.UsuariosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
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
        public void MtdSeleccionarPantallasAsignadas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Pantallas_Asignadas_Select";
                _dato.Entero = this.UsuariosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
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

        public void MtdEliminarPantallasAsignadas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Pantallas_Asignadas_Delete";
                _dato.Entero = this.UsuariosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
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
        public void MtdInsertarPantallasDisponibles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "Inventarios_Usuarios_Pantallas_Disponibles_Insert";
                _dato.Entero = this.UsuariosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
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
    }
}
