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
        public string UsuariosOldPass { get; set; }

        public void MtdSeleccionarUsuariosPantallas()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                Conexion _conexionR = new Conexion(cadenaConexionR);
                _conexionR.NombreProcedimiento = "SP_BSC_UsuarioPantallas_Select";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
               
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
        public void MtdInsertarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Usuarios_Insert";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.CadenaTexto = UsuariosNombre;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosNombre");
                _dato.CadenaTexto = UsuariosPassword;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosPassword");
                _dato.CadenaTexto = UsuariosClase;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosClase");
                _dato.Entero = UsuariosActivo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosActivo");
                _dato.Entero = nuevo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "nuevo");
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
        public void MtdEliminarUsuarios()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                Conexion _conexionR = new Conexion(cadenaConexionR);
                _conexionR.NombreProcedimiento = "SP_BSC_Usuarios_Delete";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
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
        public void MtdSeleccionarUsuarios()
        {
            Exito = true;
            try
            {
                TipoDato _dato = new TipoDato();
                Conexion _conexionR = new Conexion(cadenaConexionR);
                _conexionR.NombreProcedimiento = "SP_BSC_Usuarios_Select";
                _dato.Entero = UsuariosActivo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "activo");
                _dato.CadenaTexto = UsuariosClase;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "clase");
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
        public void MtdUpdatePassUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_UsuariosPass_Update";
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.CadenaTexto = UsuariosOldPass;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosOldPass");
                _dato.CadenaTexto = UsuariosPassword;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosPassword");
                
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
