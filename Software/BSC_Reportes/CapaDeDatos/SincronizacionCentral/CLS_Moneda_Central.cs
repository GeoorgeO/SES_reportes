using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.SincronizacionCentral
{
    class CLS_Moneda_Central: ConexionBase
    {
        public int MonedaId { get; set; }
        public string MonedaNombre { get; set; }
        public string MonedaSimbolo { get; set; }
        public Char MonedaActivo { get; set; }
        public Decimal MonedaTipoCambio { get; set; }

        public void MtdActualizarMoneda()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_MonedaGeneral";
                _dato.Entero = MonedaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "MonedaId");
                _dato.CadenaTexto = MonedaNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MonedaNombre");
                _dato.CadenaTexto = MonedaSimbolo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "MonedaSimbolo");
                _dato.CaracterValor = MonedaActivo;
                _conexionC.agregarParametro(EnumTipoDato.Caracter, _dato, "MonedaActivo");
                _dato.DecimalValor = MonedaTipoCambio;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "MonedaTipoCambio");

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
