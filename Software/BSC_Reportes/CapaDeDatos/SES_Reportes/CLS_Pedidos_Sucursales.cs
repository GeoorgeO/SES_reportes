using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Pedidos_Sucursales:ConexionBase
    {
        public string FechaInicio { get;  set; }
        public string FechaFin { get;  set; }
        public int? Sucursal { get;  set; }
        public int? MesesVenta { get;  set; }

        public void MtdGenerarPedidoSucursal()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                switch (Sucursal)
                {
                    case 1:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesCen_Select";
                        break;
                    case 2:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesMor_Select";
                        break;
                    case 3:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesCos_Select";
                        break;
                    case 4:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesEst_Select";
                        break;
                    case 5:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesSarI_Select";
                        break;
                    case 6:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesNva_Select";
                        break;
                    case 7:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesApa_Select";
                        break;
                    case 9:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesPas_Select";
                        break;
                    case 10:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesFco_Select";
                        break;
                    case 11:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesSarII_Select";
                        break;
                    case 12:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesLom_Select";
                        break;
                    case 14:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesRey_Select";
                        break;
                    case 15:
                        _conexionR.NombreProcedimiento = "SP_BSC_Pedidos_SucursalesCal_Select";
                        break;
                    default:
                        break;
                }
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = Sucursal;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Sucursal");
                _dato.Entero = MesesVenta;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "MesesVenta");
                
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
