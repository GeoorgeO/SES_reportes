using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos
{
    public class CLS_Pedidos : ConexionBase
    {
        public int? ProveedorId { get; set; }
        public string FechaInicio { get;  set; }
        public string FechaFin { get;  set; }

        public void MtdSeleccionarProveedores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_Proveedores_Select";
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

        public string MtdSeleccionarProveedorId()
        {
            string Valor=string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_ProveedorId_Select";
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                    if (Datos.Rows.Count>0)
                    {
                        Valor = Datos.Rows[0][1].ToString();
                    }
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
            return Valor;
        }

        public string MtdGenerarPedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedido_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                    if (Datos.Rows.Count > 0)
                    {
                        Valor = Datos.Rows[0][1].ToString();
                    }
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
            return Valor;
        }

    }
}
