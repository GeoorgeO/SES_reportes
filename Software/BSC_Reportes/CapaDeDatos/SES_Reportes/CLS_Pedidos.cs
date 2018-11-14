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
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string ProveedorNombre { get; set; }
        public string UsuariosLogin { get; set; }

        //Detalles PrePedido
        public int PrePedidosId { get; set; }
        public string ArticuloCodigo { get; set; }
        public string ArticuloDescripcion { get; set; }
        public decimal ArticuloCostoReposicion { get; set; }
        public string FamiliaNombre { get; set; }
        public int VAlmacen { get; set; }
        public int EAlmacen { get; set; }
        public int VApatzingan { get; set; }
        public int EApatzingan { get; set; }
        public int VCalzada { get; set; }
        public int ECalzada { get; set; }
        public int VCentro { get; set; }
        public int ECentro { get; set; }
        public int VCostaRica { get; set; }
        public int ECostaRica { get; set; }
        public int VEstocolmo { get; set; }
        public int EEstocolmo { get; set; }
        public int VFCoVilla { get; set; }
        public int EFcoVilla { get; set; }
        public int VLombardia { get; set; }
        public int ELombardia { get; set; }
        public int VReyes { get; set; }
        public int EReyes { get; set; }
        public int VMorelos { get; set; }
        public int EMorelos { get; set; }
        public int VNvaItalia { get; set; }
        public int ENvaItalia { get; set; }
        public int VPaseo { get; set; }
        public int EPaseo { get; set; }
        public int VSarabiaI { get; set; }
        public int ESarabiaI { get; set; }
        public int VSarabiaII { get; set; }
        public int ESarabiaII { get; set; }
        public int TotalV { get; set; }
        public int TotalE { get; set; }
        public int PIdeal { get; set; }
        public int PSugerido { get; set; }
        public int Pedido { get; set; }
        public int PeriodoPedido { get; set; }
        public int PeriodoTipo { get; set; }
        public int PrePedidoCerrado { get; set; }

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
            string Valor = string.Empty;
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
        public string MtdExistePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedido_Existe_Select";
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                    if (Datos.Rows.Count > 0)
                    {
                        Valor = Datos.Rows[0][0].ToString();
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
        public void MtdGenerarPedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedido_Genera_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
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
        public void MtdEliminarPrePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedido_Delete";
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
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
        public void MtdInsertPrePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedido_Insert";
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ProveedorNombre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorNombre");
                _dato.CadenaTexto = UsuariosLogin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = PeriodoPedido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoPedido");
                _dato.Entero = PeriodoTipo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoTipo");
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
        public void MtdInsertPrePedidoDetalleProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedidoDetalle_Insert";
                _dato.Entero = PrePedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.CadenaTexto = ArticuloDescripcion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloDescripcion");
                _dato.DecimalValor = ArticuloCostoReposicion;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCostoReposicion");
                _dato.CadenaTexto = FamiliaNombre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FamiliaNombre");
                _dato.Entero = VAlmacen;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VAlmacen ");
                _dato.Entero = EAlmacen;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EAlmacen ");
                _dato.Entero = VApatzingan;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VApatzingan ");
                _dato.Entero = EApatzingan;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EApatzingan ");
                _dato.Entero = VCalzada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VCalzada ");
                _dato.Entero = ECalzada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ECalzada ");
                _dato.Entero = VCentro;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VCentro ");
                _dato.Entero = ECentro;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ECentro ");
                _dato.Entero = VCostaRica;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VCostaRica ");
                _dato.Entero = ECostaRica;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ECostaRica ");
                _dato.Entero = VEstocolmo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VEstocolmo ");
                _dato.Entero = EEstocolmo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EEstocolmo ");
                _dato.Entero = VFCoVilla;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VFCoVilla ");
                _dato.Entero = EFcoVilla;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EFcoVilla ");
                _dato.Entero = VLombardia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VLombardia ");
                _dato.Entero = ELombardia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ELombardia ");
                _dato.Entero = VReyes;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VReyes ");
                _dato.Entero = EReyes;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EReyes ");
                _dato.Entero = VMorelos;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VMorelos ");
                _dato.Entero = EMorelos;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EMorelos ");
                _dato.Entero = VNvaItalia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VNvaItalia ");
                _dato.Entero = ENvaItalia;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ENvaItalia ");
                _dato.Entero = VPaseo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VPaseo ");
                _dato.Entero = EPaseo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EPaseo ");
                _dato.Entero = VSarabiaI;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VSarabiaI ");
                _dato.Entero = ESarabiaI;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ESarabiaI ");
                _dato.Entero = VSarabiaII;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "VSarabiaII ");
                _dato.Entero = ESarabiaII;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "ESarabiaII ");
                _dato.Entero = TotalV;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "TotalV ");
                _dato.Entero = TotalE;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "TotalE ");
                _dato.Entero = PIdeal;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PIdeal ");
                _dato.Entero = PSugerido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PSugerido ");
                _dato.Entero = Pedido;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Pedido ");
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
        public void MtdSeleccionarPrePedidos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedidos_Select";
                _dato.Entero = PrePedidoCerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosCerrado");
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
        public void MtdSeleccionarPrePedidosId()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedidosId_Select";
                _dato.Entero = PrePedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
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
        public void MtdSeleccionarPrePedidosDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_BSC_PrePedidosDetalles_Select";
                _dato.Entero = PrePedidosId;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
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
