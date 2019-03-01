using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos
{
    public class CLS_Proveedores:ConexionBase
    {
        public int? ProveedorId { get; set; }

        public void MtdSeleccionarProveedores()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Proveedores_Select";
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

        public string MtdSeleccionarProveedorId()
        {
            string Valor=string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_ProveedorId_Select";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _conexionR.EjecutarDataset();

                if (_conexionR.Exito)
                {
                    Datos = _conexionR.Datos;
                    if (Datos.Rows.Count>0)
                    {
                        Valor = Datos.Rows[0][1].ToString();
                    }
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
            return Valor;
        }
        
    }
}
