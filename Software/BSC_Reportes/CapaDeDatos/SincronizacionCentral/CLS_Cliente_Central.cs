using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Cliente_Central:ConexionBase
    {
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteFecha { get; set; }
        public string ClientePaterno { get; set; }
        public string ClienteMaterno { get; set; }
        public string ClienteRfc { get; set; }
        public string ClienteCalle { get; set; }
        public string ClienteNInterior { get; set; }
        public string ClienteNExterior { get; set; }
        public string ClienteColonia { get; set; }
        public int? LocalidadId { get; set; }
        public string ClienteFechaActualizacion { get; set; }
        public string ClienteTelefono1 { get; set; }
        public string ClienteTelefono2 { get; set; }
        public string ClienteTelefono3 { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteEmailFiscal { get; set; }
        public string ClienteTipoPersona { get; set; }
        public string ClienteActivo { get; set; }
        public int CClienteId { get; set; }
        public int ClienteImpresion { get; set; }
        public Decimal? ClienteLimiteCredito { get; set; }
        public Decimal? ClienteSobregiro { get; set; }
        public int VendedorId { get; set; }
        public int CondicionesPagosId { get; set; }
        public int ClienteTieneCredito { get; set; }
        public Decimal ClienteDescuento { get; set; }
        public string ClienteObservaciones { get; set; }
        public Decimal? ClienteSaldoActual { get; set; }

        public void MtdActualizarCliente()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_ClienteGeneral";
                _dato.Entero = ClienteId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ClienteId");
                _dato.CadenaTexto = ClienteNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteNombre");
                _dato.CadenaTexto = ClienteFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteFecha");
                _dato.CadenaTexto = ClientePaterno;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClientePaterno");
                _dato.CadenaTexto = ClienteMaterno;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteMaterno");
                _dato.CadenaTexto = ClienteRfc;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteRfc");
                _dato.CadenaTexto = ClienteCalle;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteCalle");
                _dato.CadenaTexto = ClienteNInterior;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteNInterior");
                _dato.CadenaTexto = ClienteNExterior;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteNExterior");
                _dato.CadenaTexto = ClienteColonia;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteColonia");
                _dato.Entero = LocalidadId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "LocalidadId");
                _dato.CadenaTexto = ClienteFechaActualizacion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteFechaActualizacion");
                _dato.CadenaTexto = ClienteTelefono1;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteTelefono1");
                _dato.CadenaTexto = ClienteTelefono2;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteTelefono2");
                _dato.CadenaTexto = ClienteTelefono3;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteTelefono3");
                _dato.CadenaTexto = ClienteEmail;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteEmail");
                _dato.CadenaTexto = ClienteEmailFiscal;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteEmailFiscal");
                _dato.CadenaTexto = ClienteTipoPersona;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteTipoPersona");
                _dato.CadenaTexto = ClienteActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteActivo");
                _dato.Entero = CClienteId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CClienteId");
                _dato.Entero = ClienteImpresion;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ClienteImpresion");
                _dato.DecimalValor = ClienteLimiteCredito;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ClienteLimiteCredito");
                _dato.DecimalValor = ClienteSobregiro;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ClienteSobregiro");
                _dato.Entero = VendedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "VendedorId");
                _dato.Entero = CondicionesPagosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CondicionesPagosId");
                _dato.Entero = ClienteTieneCredito;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ClienteTieneCredito");
                _dato.DecimalValor = ClienteDescuento;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ClienteDescuento");
                _dato.CadenaTexto = ClienteObservaciones;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ClienteObservaciones");
                _dato.DecimalValor = ClienteSaldoActual;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ClienteSaldoActual");

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
