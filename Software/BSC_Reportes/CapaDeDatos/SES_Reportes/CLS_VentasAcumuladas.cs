using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_VentasAcumuladas:ConexionBase
    {
        public Decimal Tventa_Actual { get; set; }
        public Decimal NTickets_Actual { get; set; }
        public Decimal Pventa_Actual { get; set; }
        public Decimal PArticulosXticket_Actual { get; set; }
        public Decimal Tventa_Anterior { get; set; }
        public Decimal NTickets_Anterior { get; set; }
        public Decimal Pventa_Anterior { get; set; }
        public Decimal PArticulosXticket_Anterior  { get; set; }
        public Decimal Porcentaje { get; set; }
        public string Fecha_Actual { get; set; }
        public string Fecha_Anterior { get; set; }
        public string Sucursal { get; set; }
        public string FechaInsert { get; set; }

        public void MtdInsertVentaAcumulada()
        {
            string Valor = string.Empty;
            TipoDato _dato = new TipoDato();
            Conexion _conexionR = new Conexion(cadenaConexionR);
            Exito = true;
            try
            {
                _conexionR.NombreProcedimiento = "SP_BSC_VentaAcumulada_Insert";
                _dato.DecimalValor = Tventa_Actual;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Tventa_Actual");
                _dato.DecimalValor = NTickets_Actual;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "NTickets_Actual");
                _dato.DecimalValor = Pventa_Actual;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pventa_Actual");
                _dato.DecimalValor = PArticulosXticket_Actual;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "PArticulosXticket_Actual");
                _dato.DecimalValor = Tventa_Anterior;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Tventa_Anterior");
                _dato.DecimalValor = NTickets_Anterior;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "NTickets_Anterior");
                _dato.DecimalValor = Pventa_Anterior;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pventa_Anterior");
                _dato.DecimalValor = PArticulosXticket_Anterior;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "PArticulosXticket_Anterior");
                _dato.DecimalValor = Porcentaje;
                _conexionR.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Porcentaje");
                _dato.CadenaTexto = Fecha_Actual;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Actual");
                _dato.CadenaTexto = Fecha_Anterior;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Anterior");
                _dato.CadenaTexto = Sucursal;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Sucursal");
                _dato.CadenaTexto = FechaInsert;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInsert");

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
