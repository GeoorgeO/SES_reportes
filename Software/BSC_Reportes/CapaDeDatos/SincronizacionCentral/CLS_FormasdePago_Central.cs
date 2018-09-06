using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_FormasdePago_Central: ConexionBase
    {
        public int FormasdePagoId { get; set; }
        public string FormasdePagoDescripcion { get; set; }

        public void MtdActualizarFormasdePagoGeneral()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_FormasdePagoGeneral";
                _dato.Entero = FormasdePagoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "FormasdePagoId");
                _dato.CadenaTexto = FormasdePagoDescripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FormasdePagoDescripcion");

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
