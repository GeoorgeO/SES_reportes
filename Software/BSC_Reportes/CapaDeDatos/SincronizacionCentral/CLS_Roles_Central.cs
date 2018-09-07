using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Roles_Central: ConexionBase
    {
        public int RolesId { get; set; }
        public string RolesNombre { get; set; }
        public string RolesActivo { get; set; }
        public string RolesFecha { get; set; }

        public void MtdActualizarRoles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_RolesGeneral";
                _dato.Entero = RolesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "RolesId");
                _dato.CadenaTexto = RolesNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RolesNombre");
                _dato.CadenaTexto = RolesActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RolesActivo");
                _dato.CadenaTexto = RolesFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RolesFecha");
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
