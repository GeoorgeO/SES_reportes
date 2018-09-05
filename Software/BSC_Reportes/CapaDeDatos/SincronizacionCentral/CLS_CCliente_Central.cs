using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_CCliente_Central : ConexionBase
    {
        public int CClienteId { get; set; }
        public string CClienteNombre { get; set; }
        public string CClienteFecha { get; set; }
        public String CClienteActivo { get; set; }
        public int? CClientePadreId { get; set; }
        public int CClienteTieneElementos { get; set; }

        public void MtdActualizarCCliente()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_CClienteGeneral";
                _dato.Entero = CClienteId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CClienteId");
                _dato.CadenaTexto = CClienteNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CClienteNombre");
                _dato.CadenaTexto = CClienteFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CClienteFecha");
                _dato.CadenaTexto = CClienteActivo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "CClienteActivo");
                _dato.Entero = CClientePadreId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CClientePadreId");
                _dato.Entero = CClienteTieneElementos;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "CClienteTieneElementos");

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
