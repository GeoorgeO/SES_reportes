using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCorteZCentral:ConexionBase
    {
        public int CortesZId { get; set; }
        public int CajaId { get; set; }
        public string CortesZFecha { get; set; }
        public int UsuariosId { get; set; }
        public Decimal CortesZSub0 { get; set; }
        public Decimal CortesZSub16 { get; set; }
        public Decimal CortesZIva { get; set; }
        public Decimal CortesZTotal { get; set; }
    
        public void MtdActualizarCorteZ()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_Cancelacion_General";
                _dato.Entero = CortesZId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.CadenaTexto = CortesZFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CortesZFecha");
                _dato.DecimalValor = CortesZSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZSub0");
                _dato.DecimalValor = CortesZSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZSub16");
                _dato.DecimalValor = CortesZIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZIva");
                _dato.DecimalValor = CortesZTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZTotal");
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
