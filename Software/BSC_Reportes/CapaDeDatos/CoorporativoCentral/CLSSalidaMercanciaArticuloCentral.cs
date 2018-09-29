using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSSalidaMercanciaArticuloCentral : ConexionBase
    {

       
        public int SalidaMercanciaId { get; set; }
        public int SucursalesId { get; set; }
        public int SalidaMercanciaArticuloUltimoIde { get; set; }
        public string ArticuloCodigo { get; set; }
        public int SalidaMercanciaArticuloCantidad { get; set; }
        public decimal SalidaMercanciaArticuloSub0 { get; set; }
        public decimal SalidaMercanciaArticuloSub16 { get; set; }
        public decimal SalidaMercanciaArticuloIva { get; set; }
        public decimal SalidaMercanciaArticuloTotal { get; set; }


        public void MtdActualizarSalidaMercanciaArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_SalidaMercanciaArticulo_General";
                _dato.Entero = SalidaMercanciaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaId");
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = SalidaMercanciaArticuloUltimoIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaArticuloUltimoIde");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                
                _dato.Entero = SalidaMercanciaArticuloCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaArticuloCantidad");
                _dato.DecimalValor = SalidaMercanciaArticuloSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaArticuloSub0");
                _dato.DecimalValor = SalidaMercanciaArticuloSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaArticuloSub16");
                _dato.DecimalValor = SalidaMercanciaArticuloIva;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SalidaMercanciaArticuloIva");
                _dato.DecimalValor = SalidaMercanciaArticuloTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaArticuloTotal");
               

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
