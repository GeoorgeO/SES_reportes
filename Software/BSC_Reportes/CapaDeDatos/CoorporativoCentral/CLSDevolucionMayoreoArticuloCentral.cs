using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionMayoreoArticuloCentral : ConexionBase
    {

        
        public int DevolucionId { get; set; }
        public int CajaId { get; set; }
        public int DevolucionArticuloUltimoIde { get; set; }
        public string ArticuloCodigo { get; set; }
        public decimal DevolucionArticuloPrecio { get; set; }
        public int DevolucionArticuloCantidad { get; set; }
        public decimal DevolucionArticuloSubtotal { get; set; }
        public decimal DevolucionArticuloIva { get; set; }
        public decimal DevolucionArticuloTotalLinea { get; set; }




        public void MtdActualizarDevolucionMayoreoArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "DevolucionMayoreoArticulo";
                _dato.Entero = DevolucionId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = DevolucionArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.DecimalValor = DevolucionArticuloPrecio;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionArticuloPrecio");
                _dato.Entero = DevolucionArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionArticuloCantidad");
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
