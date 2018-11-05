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
        /* public string UsuariosLogin { get; set; }
         public string UsuariosNombre { get; set; }
         public string UsuariosPassword { get; set; }
         public char UsuariosClase { get; set; }*/
        TipoDato _dato = new TipoDato();

        public void MtdSeleccionarUsuarios()
        {
            
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_Usuarios_Select";
                _dato.Entero = UsuariosActivo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "activo");
                /*_dato.CadenaTexto = UsuariosLogin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.CadenaTexto = UsuariosNombre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosNombre");
                _dato.CadenaTexto = UsuariosPassword;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosPassword");
                _dato.CaracterValor = UsuariosClase;
                _conexion.agregarParametro(EnumTipoDato.Caracter, _dato, "UsuariosClase"); */
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
