using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSEntradaMercanciaArticuloCentral : ConexionBase
    {

        
        public int EntradasMercanciaId { get; set; }
        public int SucursalesId { get; set; }
        public int EntradasMercanciaArticuloUltimoIde { get; set; }
        public string ArticuloCodigo { get; set; }
        public int EntradasMercanciaArticuloCantidad { get; set; }
        public decimal EntradasMercanciaArticuloSub0 { get; set; }
        public decimal EntradasMercanciaArticuloSub16 { get; set; }
        public decimal EntradasMercanciaArticuloIva { get; set; }
        public decimal EntradasMercanciaArticuloTotal { get; set; }


        public void MtdActualizarEntradaMercanciaArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_EntradaMercanciaArticulo_General";
                _dato.Entero = EntradasMercanciaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaId");
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = EntradasMercanciaArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = EntradasMercanciaArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradasMercanciaArticuloCantidad");
                _dato.DecimalValor = EntradasMercanciaArticuloSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloSub0");
                _dato.DecimalValor = EntradasMercanciaArticuloSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloSub16");
                _dato.DecimalValor = EntradasMercanciaArticuloIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloIva");
                _dato.DecimalValor = EntradasMercanciaArticuloTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradasMercanciaArticuloTotal");


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
