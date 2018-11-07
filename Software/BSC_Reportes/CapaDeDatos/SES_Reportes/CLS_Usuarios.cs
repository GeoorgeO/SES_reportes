using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Usuarios:ConexionBase
    {
        public int UsuariosActivo { get; set; }
        public string UsuariosLogin { get; set; }
        public string UsuariosNombre { get; set; }
        public string UsuariosPassword { get; set; }
        public string UsuariosClase { get; set; }
        public int nuevo { get; set; }

        public void MtdSeleccionarUsuariosPantallas()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                _conexion.NombreProcedimiento = "SP_BSC_UsuarioPantallas_Select";
                _dato.CadenaTexto = UsuariosLogin;
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
        public void MtdInsertarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_Usuarios_Insert";
                _dato.CadenaTexto = UsuariosLogin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.CadenaTexto = UsuariosNombre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosNombre");
                _dato.CadenaTexto = UsuariosPassword;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosPassword");
                _dato.CadenaTexto = UsuariosClase;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosClase");
                _dato.Entero = UsuariosActivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosActivo");
                _dato.Entero = nuevo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "nuevo");
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
        public void MtdEliminarUsuarios()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                _conexion.NombreProcedimiento = "SP_BSC_Usuarios_Delete";
                _dato.CadenaTexto = UsuariosLogin;
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
        public void MtdSeleccionarUsuarios()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                _conexion.NombreProcedimiento = "SP_BSC_Usuarios_Select";
                _dato.Entero = UsuariosActivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "activo");
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
