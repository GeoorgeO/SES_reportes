using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Articulo_Central:ConexionBase
    {
        public string ArticuloCodigo { get; set; }
        public string ArticuloDescripcion { get; set; }
        public decimal ArticuloCostoReposicion { get; set; }
        public int FamiliaId { get; set; }

        public void MtdActualizarArticulo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_Articulo_General";
                _dato.CadenaTexto = ArticuloCodigo;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloCodigo");
                _dato.CadenaTexto = ArticuloDescripcion;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ArticuloDescripcion");
                _dato.DecimalValor = ArticuloCostoReposicion;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ArticuloCostoReposicion");
                _dato.Entero = FamiliaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "FamiliaId");
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
