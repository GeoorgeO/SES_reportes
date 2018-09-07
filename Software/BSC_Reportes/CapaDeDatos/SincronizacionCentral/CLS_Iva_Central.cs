using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Iva_Central: ConexionBase
    {
        
        public int IvaId { get; set; }
        public string IvaNombre { get; set; }
        public Decimal IvaFactor { get; set; }
        public int IvaPorcentaje { get; set; }

        public void MtdActualizarIva()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_IvaGeneral";
                _dato.Entero = IvaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "IvaId");
                _dato.CadenaTexto = IvaNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "IvaNombre");
                _dato.DecimalValor = IvaFactor;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "IvaFactor");
                _dato.Entero = IvaPorcentaje;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "IvaPorcentaje");

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
