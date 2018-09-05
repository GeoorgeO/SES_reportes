using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_Vendedor_Central: ConexionBase
    {
        public int VendedorId { get; set; }
        public string VendedorNombre { get; set; }
        public string VendedorApellidos { get; set; }
        public Char VendedorActivo { get; set; }
        public string VendedorNombreCompleto { get; set; }

        public void MtdActualizarVendedor()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_VendedorGeneral";
                _dato.Entero = VendedorId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "VendedorId");
                _dato.CadenaTexto = VendedorNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "VendedorNombre");
                _dato.CadenaTexto = VendedorApellidos;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "VendedorApellidos");
                _dato.CaracterValor = VendedorActivo;
                _conexionC.agregarParametro(EnumTipoDato.Caracter, _dato, "VendedorActivo");
                _dato.CadenaTexto = VendedorNombreCompleto;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "VendedorNombreCompleto");

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
