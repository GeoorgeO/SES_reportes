using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class WEB_Pedidos:ConexionBase
    {
        public string ArticuloCodigo { get;  set; }
        public int? PedidosId { get; set; }
        public int? Surtido { get;  set; }
        public string ArticuloDescripcion { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public int? PedidosSurtido { get;  set; }

        public void MtdSelectPedidoDetallesProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoDetalles_Select";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
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
        public void MtdSelectPedidoDetallesInsidenciasProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoDetallesInsidencias_Select";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
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

        public void MtdSelectPedidoNombreProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoNombreProveedor_Select";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
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

        public void MtdSelectPedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_Pedido_Select";
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
        public void MtdUpdatePedidoDetalleSurtido()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoDetallesSurtido_Update";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = Surtido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Surtido");
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

        public void MtdInsertPedidoDetalleInsidencias()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoDetallesInsidencias_Insert";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.CadenaTexto = ArticuloDescripcion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloDescripcion");
                _dato.Entero = Cantidad;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cantidad");
                _dato.CadenaTexto = Tipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo");
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

        public void MtdUpdatePedidoSurtido()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_PedidoSurtido_Update";
                _dato.Entero = PedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.Entero = PedidosSurtido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosSurtido");
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

        public void MtdSelectArticulo()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_WEB_Articulo_Select";
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
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
