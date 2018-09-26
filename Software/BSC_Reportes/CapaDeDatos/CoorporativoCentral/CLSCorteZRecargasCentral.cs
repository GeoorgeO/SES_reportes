using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSCorteZRecargasCentral : ConexionBase
    {
        public int CortesZRecargasId { get; set; }
        public int CajaId { get; set; }
        public string CortesZRecargasFecha { get; set; }
        public int UsuariosId { get; set; }
        public Decimal CortesZRecargasSub0 { get; set; }
        public Decimal CortesZRecargasSub16 { get; set; }
        public Decimal CortesZRecargasIva { get; set; }
        public Decimal CortesZRecargasTotal { get; set; }
        public int FacturaGlobalFolio { get; set; }
        public int CortesZRecargasFacturado { get; set; }
        public Decimal CortesZRecargasTotalCosto { get; set; }

        public void MtdActualizarCorteZRecargas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CortesZRecargas_General";
                _dato.Entero = CortesZRecargasId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecargasId");
                _dato.Entero = CajaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CajaId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.CadenaTexto = CortesZRecargasFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CortesZRecargasFecha");
                _dato.DecimalValor = CortesZRecargasSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecargasSub0");
                _dato.DecimalValor = CortesZRecargasSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecargasSub16");
                _dato.DecimalValor = CortesZRecargasIva;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecargasIva");
                _dato.DecimalValor = CortesZRecargasTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecargasTotal");
                _dato.Entero = FacturaGlobalFolio;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "FacturaGlobalFolio");
                _dato.Entero = CortesZRecargasFacturado;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CortesZRecargasFacturado");
                _dato.DecimalValor = CortesZRecargasTotalCosto;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "CortesZRecargasTotalCosto");
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
