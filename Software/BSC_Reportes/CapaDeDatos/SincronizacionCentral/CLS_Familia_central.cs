using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class CLS_Familia_central: ConexionBase
    {
        
        
        public int FamiliaId { get; set; }
        public string FamiliaNombre { get; set; }
        public string FamiliaFecha { get; set; }
        public Char FamiliaTipo { get; set; }
        public char FamiliaActivo { get; set; }
        public int FamiliaPadreId { get; set; }
        public int IvaId { get; set; }
        public int Espadre { get; set; }
        public int TieneArticulos { get; set; }

        public void MtdActualizarFamilia()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_FamiliaGeneral";
                _dato.Entero = FamiliaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "FamiliaId");
                _dato.CadenaTexto = FamiliaNombre;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FamiliaNombre");
                _dato.CadenaTexto = FamiliaFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FamiliaFecha");
                _dato.CaracterValor = FamiliaTipo;
                _conexionC.agregarParametro(EnumTipoDato.Caracter, _dato, "FamiliaTipo");
                _dato.CaracterValor = FamiliaActivo;
                _conexionC.agregarParametro(EnumTipoDato.Caracter, _dato, "FamiliaActivo");
                _dato.Entero = FamiliaPadreId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "FamiliaPadreId");
                _dato.Entero = IvaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "IvaId");
                _dato.Entero = Espadre;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "Espadre");
                _dato.Entero = TieneArticulos;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "TieneArticulos");

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
