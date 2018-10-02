using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionPreDetallesCentral : ConexionBase
    {

        
        public int DevolucionPreId { get; set; }
        public string ArticuloCodigo { get; set; }
        public int DevolucionPreCantidad { get; set; }
        public decimal DevolucionPrePUnitarioSimp { get; set; }
        public decimal DevolucionPrePUnitarioCImp { get; set; }
        public decimal DevolucionPreTLinea { get; set; }

        public void MtdActualizarDevolucionPreDetalles()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_DevolucionPreDetalles_General";
                _dato.Entero = DevolucionPreId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionPreId");
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = DevolucionPreCantidad;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionPreCantidad");
                _dato.DecimalValor = DevolucionPrePUnitarioSimp;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPrePUnitarioSimp");
                _dato.DecimalValor = DevolucionPrePUnitarioCImp;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPrePUnitarioCImp");
                _dato.DecimalValor = DevolucionPreTLinea;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreTLinea");
               
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
