using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCortesZRecibosCentral : ConexionBase
    {

        public int CortesZRecibosId  { get; set; }
        public string CortesZRecibosFecha  { get; set; }
        public int UsuariosId  { get; set; }
	    public decimal CortesZRecibosTotal  { get; set; }

        public void MtdActualizarCortesZRecibos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CortesZRecibos_General";
                _dato.Entero = CortesZRecibosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecibosId");
                _dato.CadenaTexto = CortesZRecibosFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CortesZRecibosFecha");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.DecimalValor = CortesZRecibosTotal;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CortesZRecibosTotal");
                
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
