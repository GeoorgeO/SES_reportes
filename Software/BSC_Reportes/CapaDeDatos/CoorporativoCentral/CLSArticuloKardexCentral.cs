using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos 
{
    public class CLSArticuloKardexCentral : ConexionBase
    {
        public void MtdActualizarArticuloKardex()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_ArticuloKardex_General";
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = Existencia;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "Existencia");
                _dato.DecimalValor = ArticuloCosto;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCosto");
                _dato.DecimalValor = ArticuloIVA;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloIVA");
                _dato.CadenaTexto = FechaExistencia;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaExistencia");
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
