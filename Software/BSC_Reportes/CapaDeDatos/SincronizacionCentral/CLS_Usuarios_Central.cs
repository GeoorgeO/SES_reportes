using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Usuarios_Central: ConexionBase
    {
        public int UsuariosId { get; set; }
        public string UsuariosNombre { get; set; }
        public string UsuariosRegistroFecha { get; set; }
        public string UsuariosLogin { get; set; }
        public string UsuariosPassword { get; set; }
        public string UsuariosActivo { get; set; }
        public int? RolesId { get; set; }

        public void MtdActualizarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_UsuariosGeneral";
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.CadenaTexto = UsuariosNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosNombre");
                _dato.CadenaTexto = UsuariosRegistroFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosRegistroFecha");
                _dato.CadenaTexto = UsuariosLogin;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.CadenaTexto = UsuariosPassword;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosPassword");
                _dato.CadenaTexto = UsuariosActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosActivo");
                _dato.Entero = RolesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "RolesId");

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

    }
}
