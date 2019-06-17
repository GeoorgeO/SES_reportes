using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_CheckSincroniza_Sucursales:ConexionBase
    {
        public string FechaInicio { get;  set; }
        public string FechaFin { get;  set; }
        public int SucursalId { get; set; }

        public void MtdSeleccionarDatos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                switch (SucursalId)
                {
                    case 1:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Centro";
                        break;
                    case 2:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Morelos";
                        break;
                    case 3:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_CostaRica";
                        break;
                    case 4:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Estocolmo";
                        break;
                    case 5:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_SarabiaI";
                        break;
                    case 6:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_NvaItalia";
                        break;
                    case 7:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Apatzingan";
                        break;
                    case 9:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Paseo";
                        break;
                    case 10:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_FcoVilla";
                        break;
                    case 11:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_SarabiaII";
                        break;
                    case 12:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Lombardia";
                        break;
                    case 14:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_LosReyes";
                        break;
                    case 15:
                        _conexionR.NombreProcedimiento = "SP_BSC_CheckSincroniza_Calzada";
                        break;
                    default:
                        break;
                }
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                
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
