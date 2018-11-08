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


        public void Mtdseleccionarpantallas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_Pantallas_Select";

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


        public void Mtdseleccionarbotones()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_UsuarioBotones_Select";
                _dato.CadenaTexto = UsuariosLogin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = pantallasid;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "pantallasid");
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
