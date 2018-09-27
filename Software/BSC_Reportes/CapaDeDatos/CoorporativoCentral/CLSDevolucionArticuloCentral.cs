using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionArticuloCentral : ConexionBase
    {
        public Decimal DevolucionId { get; set; }
        public Decimal CajaId { get; set; }
        public Decimal DevolucionArticuloUltimoIde { get; set; }
        public String ArticuloCodigo { get; set; }
        public Decimal DevolucionArticuloPrecio { get; set; }
        public int DevolucionArticuloCantidad { get; set; }
        public Decimal DevolucionArticuloSubtotal { get; set; }
        public Decimal DevolucionArticuloIva { get; set; }
        public Decimal DevolucionArticuloTotalLinea { get; set; }

        public void MtdActualizarDevolucionArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_DevolucionArticulo_General";
                _dato.DecimalValor = DevolucionId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionId");
                _dato.DecimalValor = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CajaId");
                _dato.DecimalValor = DevolucionArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.DecimalValor = DevolucionArticuloPrecio;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloPrecio");
                _dato.DecimalValor = DevolucionArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloCantidad");
                _dato.DecimalValor = DevolucionArticuloSubtotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloSubtotal");
                _dato.DecimalValor = DevolucionArticuloIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloIva");
                _dato.DecimalValor = DevolucionArticuloTotalLinea;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloTotalLinea");
                

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
