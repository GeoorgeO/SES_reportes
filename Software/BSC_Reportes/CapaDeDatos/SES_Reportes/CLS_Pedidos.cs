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
        public int Reg { get; set; }
        public int PrePedidosCancelado { get; set; }
        // Encabezado Pedido

        // Detalles Pedidos
        public int? PedidosId { get;  set; }
        public int? DAlmacen { get;  set; }
        public int? DApatzingan { get;  set; }
        public int? DCalzada { get;  set; }
        public int? DCentro { get;  set; }

        

        public int? DCostaRica { get;  set; }
        public int? DEstocolmo { get;  set; }
        public int? DFcoVilla { get;  set; }
        public int? DLombardia { get;  set; }
        public int? DReyes { get;  set; }
        public int? DMorelos { get;  set; }
        public int? DNvaItalia { get;  set; }
        public int? DPaseo { get;  set; }
        public int? DSarabiaI { get;  set; }
        public int? DSarabiaII { get;  set; }
        public int? TPedido { get;  set; }
        public int? Surtido { get; set; }
        public int Opcion { get; set; }
        public byte[] imageCodigoBarra { get;  set; }
        public int? Status { get;  set; }
        public string PedidosConfigRuta { get;  set; }
        public int VTancitaro { get; set; }
        public int ETancitaro { get; set; }
        public int DTancitaro { get; set; }

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
            string Valor = string.Empty;
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
                    if (Datos.Rows.Count > 0)
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
        public string MtdExistePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Existe_Select";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.Entero = PrePedidoCerrado;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosCerrado");
                _dato.Entero = PrePedidosCancelado;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosCancelado");
                _conexionR.EjecutarDataset();

                if (_conexionR.Exito)
                {
                    Datos = _conexionR.Datos;
                    if (Datos.Rows.Count > 0)
                    {
                        Valor = Datos.Rows[0][0].ToString();
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
        public void MtdGenerarPedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Genera_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
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
        public void MtdEliminarPrePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Delete";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
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
        public void MtdInsertPrePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Insert";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ProveedorNombre;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorNombre");
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = PeriodoPedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoPedido");
                _dato.Entero = PeriodoTipo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoTipo");
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
        public void MtdUpdatePrePedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Update";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ProveedorNombre;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ProveedorNombre");
                _dato.CadenaTexto = UsuariosLogin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "UsuariosLogin");
                _dato.Entero = PeriodoPedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoPedido");
                _dato.Entero = PeriodoTipo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PeriodoTipo");
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
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
        public void MtdUpdatePrePedidoCancelarProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidoCancelar_Update";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
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
        public void MtdInsertPrePedidoDetalleProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidoDetalle_Insert";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
                _dato.Entero = Reg;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Reg");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.CadenaTexto = ArticuloDescripcion;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloDescripcion");
                _dato.DecimalValor = ArticuloCostoReposicion;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCostoReposicion");
                _dato.CadenaTexto = FamiliaNombre;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FamiliaNombre");
                _dato.Entero = VAlmacen;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VAlmacen ");
                _dato.Entero = EAlmacen;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EAlmacen ");
                _dato.Entero = VApatzingan;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VApatzingan ");
                _dato.Entero = EApatzingan;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EApatzingan ");
                _dato.Entero = VCalzada;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VCalzada ");
                _dato.Entero = ECalzada;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ECalzada ");
                _dato.Entero = VCentro;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VCentro ");
                _dato.Entero = ECentro;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ECentro ");
                _dato.Entero = VCostaRica;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VCostaRica ");
                _dato.Entero = ECostaRica;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ECostaRica ");
                _dato.Entero = VEstocolmo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VEstocolmo ");
                _dato.Entero = EEstocolmo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EEstocolmo ");
                _dato.Entero = VFCoVilla;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VFCoVilla ");
                _dato.Entero = EFcoVilla;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EFcoVilla ");
                _dato.Entero = VLombardia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VLombardia ");
                _dato.Entero = ELombardia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ELombardia ");
                _dato.Entero = VReyes;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VReyes ");
                _dato.Entero = EReyes;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EReyes ");
                _dato.Entero = VMorelos;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VMorelos ");
                _dato.Entero = EMorelos;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EMorelos ");
                _dato.Entero = VNvaItalia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VNvaItalia ");
                _dato.Entero = ENvaItalia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ENvaItalia ");
                _dato.Entero = VPaseo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VPaseo ");
                _dato.Entero = EPaseo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "EPaseo ");
                _dato.Entero = VSarabiaI;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VSarabiaI ");
                _dato.Entero = ESarabiaI;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ESarabiaI ");
                _dato.Entero = VSarabiaII;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VSarabiaII ");
                _dato.Entero = ESarabiaII;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ESarabiaII ");
                //_dato.Entero = VTancitaro;
                //_conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "VTancitaro ");
                //_dato.Entero = ETancitaro;
                //_conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ETancitaro ");
                _dato.Entero = TotalV;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "TotalV ");
                _dato.Entero = TotalE;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "TotalE ");
                _dato.Entero = PIdeal;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PIdeal ");
                _dato.Entero = PSugerido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PSugerido ");
                _dato.Entero = Pedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Pedido ");
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
        public void MtdUpdatePrePedidoDetalleProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidoDetalle_Update";
                _dato.Entero = Reg;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Reg ");
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.CadenaTexto = ArticuloDescripcion;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloDescripcion");
                _dato.Entero = Pedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Pedido ");
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
        public void MtdSeleccionarPrePedidos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidos_Select";
                _dato.Entero = PrePedidoCerrado;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosCerrado");
                _dato.Entero = PrePedidosCancelado;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosCancelado");
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
        public void MtdSeleccionarPrePedidosId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidosId_Select";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
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
        public void MtdSeleccionarPrePedidosDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidosDetalles_Select";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId ");
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
        public void MtdActualizarCodigoBarra()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_CodigoBarra_Update";
                _dato.Entero = this.PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.ImagenValor = imageCodigoBarra;
                _conexionR.agregarParametro(EnumTipoDato.imagen, _dato, "imageCodigoBarra");
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
        public void MtdSeleccionarPrePedidosArticulo()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedidosArticulo_Select";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
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

        //Pedidos
        public void MtdSeleccionarPedidosId()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionRR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionRR.NombreProcedimiento = "SP_BSC_Pedido_Id_Select";
                _dato.Entero = PrePedidosId;
                _conexionRR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _conexionRR.EjecutarDataset();

                if (_conexionRR.Exito)
                {
                    Datos = _conexionRR.Datos;
                }
                else
                {
                    Mensaje = _conexionRR.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        public void MtdSeleccionarPedidosDetallesId()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionRR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionRR.NombreProcedimiento = "SP_BSC_PedidoDetalles_Id_Select";
                _dato.Entero = PedidosId;
                _conexionRR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _conexionRR.EjecutarDataset();

                if (_conexionRR.Exito)
                {
                    Datos = _conexionRR.Datos;
                }
                else
                {
                    Mensaje = _conexionRR.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        public void MtdInsertPedidoProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionRR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_Encabezado_Insert";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
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
        public void MtdInsertPedidoDetalleProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_Detalles_Insert";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = DAlmacen;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DAlmacen");
                _dato.Entero = DApatzingan;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DApatzingan");
                _dato.Entero = DCalzada;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCalzada");
                _dato.Entero = DCentro;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCentro");
                _dato.Entero = DCostaRica;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCostaRica");
                _dato.Entero = DEstocolmo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DEstocolmo");
                _dato.Entero = DFcoVilla;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DFcoVilla");
                _dato.Entero = DLombardia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DLombardia");
                _dato.Entero = DReyes;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DReyes");
                _dato.Entero = DMorelos;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DMorelos");
                _dato.Entero = DNvaItalia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DNvaItalia");
                _dato.Entero = DPaseo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DPaseo");
                _dato.Entero = DSarabiaI;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaI");
                _dato.Entero = DSarabiaII;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaII");
                //_dato.Entero = DTancitaro;
                //_conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DTancitaro");
                _dato.Entero = TPedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "TPedido");
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
        public void MtdUpdatePedidoCerrarProveedor()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Cerrar_Update";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
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
        public void MtdSeleccionarParametrosPedidos()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionRR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionRR.NombreProcedimiento = "SP_BSC_Pedido_Parametros_Select";
                
                _conexionRR.EjecutarDataset();

                if (_conexionRR.Exito)
                {
                    Datos = _conexionRR.Datos;
                }
                else
                {
                    Mensaje = _conexionRR.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        public void MtdInsertarParametrosPedidos()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionRR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionRR.NombreProcedimiento = "SP_BSC_Pedido_Parametros_Insert";
                _dato.CadenaTexto = PedidosConfigRuta;
                _conexionRR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PedidosConfigRuta");
                _conexionRR.EjecutarDataset();

                if (_conexionRR.Exito)
                {
                    Datos = _conexionRR.Datos;
                }
                else
                {
                    Mensaje = _conexionRR.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        //Buscar Pedidos
        public void MtdSeleccionarPedidoFechaProveedorLista()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_FechaProveedorLista_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.Entero = Opcion;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Opcion");
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
        public void MtdSeleccionarPedidoFechaLista()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_FechaLista_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.Entero = Opcion;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Opcion");
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
        public void MtdSeleccionarPedidoProveedorLista()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_ProveedorLista_Select";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.Entero = Opcion;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Opcion");
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
        public void MtdSeleccionarPrePedidosProveedores()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_ProvStatus_Select";
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
        public void MtdSeleccionarPrePedidoListaEstatus()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Status_Select";
                _dato.Entero = ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.Entero = Opcion;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Opcion");
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

        //Actualizar Pedidos
        public void MtdUpdatePedidoDetalleSurtido()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_DetallesSurtido_Update";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = DAlmacen;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DAlmacen");
                _dato.Entero = DApatzingan;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DApatzingan");
                _dato.Entero = DCalzada;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCalzada");
                _dato.Entero = DCentro;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCentro");
                _dato.Entero = DCostaRica;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCostaRica");
                _dato.Entero = DEstocolmo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DEstocolmo");
                _dato.Entero = DFcoVilla;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DFcoVilla");
                _dato.Entero = DLombardia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DLombardia");
                _dato.Entero = DReyes;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DReyes");
                _dato.Entero = DMorelos;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DMorelos");
                _dato.Entero = DNvaItalia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DNvaItalia");
                _dato.Entero = DPaseo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DPaseo");
                _dato.Entero = DSarabiaI;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaI");
                _dato.Entero = DSarabiaII;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaII");
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
        public void MtdUpdatePedidoDetallePendiente()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_DetallesPendiente_Update";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = DAlmacen;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DAlmacen");
                _dato.Entero = DApatzingan;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DApatzingan");
                _dato.Entero = DCalzada;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCalzada");
                _dato.Entero = DCentro;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCentro");
                _dato.Entero = DCostaRica;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DCostaRica");
                _dato.Entero = DEstocolmo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DEstocolmo");
                _dato.Entero = DFcoVilla;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DFcoVilla");
                _dato.Entero = DLombardia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DLombardia");
                _dato.Entero = DReyes;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DReyes");
                _dato.Entero = DMorelos;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DMorelos");
                _dato.Entero = DNvaItalia;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DNvaItalia");
                _dato.Entero = DPaseo;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DPaseo");
                _dato.Entero = DSarabiaI;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaI");
                _dato.Entero = DSarabiaII;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "DSarabiaII");
                _dato.Entero = TPedido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "TPedido");
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
        public void MtdActualizarPrePedidoEstatus()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_Status_Update";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
                _dato.Entero = Opcion;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Opcion");
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
        public void MtdActualizarPrePedidoSoloLectura()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_PrePedido_SoloLectura_Update";
                _dato.Entero = PrePedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PrePedidosId");
                _dato.Entero = Status;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Status");
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

        // Insidencias

        public void MtdUpdateInsidencia()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_Insidencia_Update";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = Surtido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Surtido");

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
        public void MtdInsertInsidenciar()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_Insidencia_Insert";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = Surtido;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "Surtido");
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
        public void MtdEliminarInsidencia()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_Pedido_Insidencia_Delete";
                _dato.Entero = PedidosId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "PedidosId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
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
