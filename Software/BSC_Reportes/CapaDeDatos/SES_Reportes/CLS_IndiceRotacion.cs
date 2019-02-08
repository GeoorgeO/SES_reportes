using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.SES_Reportes
{
    class CLS_IndiceRotacion
    {
        public void MtdSeleccionarBVentaExistencia()
        {
            ServerR = vServerR;
            DBaseR = vDBaseR;
            UserR = vUserR;
            PasswordR = vPasswordR;

            TipoDato _dato = new TipoDato();
            string CadenaConexionRemota = ConexionSQL.LeerConexionR(ServerR, DBaseR, UserR, PasswordR);
            Conexion _conexionR = new Conexion(CadenaConexionRemota);

            Exito = true;
            try
            {

                _conexionR.NombreProcedimiento = "SP_BSC_IndiceRotacion_Select";
                _dato.Entero = this.ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = this.FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = this.FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.CadenaTexto = this.EFamilia;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EFamilia");
                
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
