using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSArticuloProveedoresCentral : ConexionBase
    {

        public string ArticuloCodigo { get; set; }
        public int ArticuloProveedoresIde { get; set; }
        public int ProveedorId { get; set; }
        public string ArticuloProveedoresFechaUdp { get; set; }
        




        public void MtdActualizarArticuloProveedores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_ArticuloProveedores_General";
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.Entero = ArticuloProveedoresIde;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ArticuloProveedoresIde");
                _dato.Entero = ProveedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = ArticuloProveedoresFechaUdp;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloProveedoresFechaUdp");
               
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
