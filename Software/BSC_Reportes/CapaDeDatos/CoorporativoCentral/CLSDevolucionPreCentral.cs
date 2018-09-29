using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionPreCentral : ConexionBase
    {
        public int DevolucionPreId { get; set; }
        public int TicketId { get; set; }
        public int CajaId { get; set; }
        public string DevolucionPreFecha { get; set; }
        public int DevolucionPreTArticulos { get; set; }
        public int UsuarioId { get; set; }
        public int VendedorId { get; set; }
        public decimal DevolucionPreSub0 { get; set; }
        public decimal DevolucionPreSub16 { get; set; }
        public decimal DevolucionPreIva { get; set; }
        public decimal DevolucionPreTotal { get; set; }
        public decimal DevolucionPreProcesada { get; set; }



        public void MtdActualizarDevolucionPre()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_DevolucionPre_General";
                _dato.Entero = DevolucionPreId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionPreId");
                _dato.Entero = TicketId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TicketId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.CadenaTexto = DevolucionPreFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "DevolucionPreFecha");
                _dato.Entero = DevolucionPreTArticulos;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "DevolucionPreTArticulos");
                _dato.Entero = UsuarioId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuarioId");
                _dato.Entero = VendedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "VendedorId");
                _dato.DecimalValor = DevolucionPreSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreSub0");
                _dato.DecimalValor = DevolucionPreSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreSub16");
                _dato.DecimalValor = DevolucionPreIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreIva");
                _dato.DecimalValor = DevolucionPreTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreTotal");
                _dato.DecimalValor = DevolucionPreProcesada;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "DevolucionPreProcesada");
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
