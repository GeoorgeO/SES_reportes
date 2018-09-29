using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSSalidaMercanciaCentral : ConexionBase
    {

        
        public int SalidaMercanciaId { get; set; }
        public int SucursalesId { get; set; }
        public int UsuariosId { get; set; }
        public int SalidaMercanciaTipoId { get; set; }
        public string SalidaMercanciaFecha { get; set; }
        public int SalidaMercanciaUnidades { get; set; }
        public decimal SalidaMercanciaSub0 { get; set; }
        public decimal SalidaMercanciaSub16 { get; set; }
        public decimal SalidaMercanciaIva { get; set; }
        public decimal SalidaMercanciaTotal { get; set; }
        public string Observaciones { get; set; }
        public string Referencias { get; set; }
        public string ParaSucursal { get; set; }





        public void MtdActualizarSalidaMercancia()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_SalidaMercancia_General";
                _dato.Entero = SalidaMercanciaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaId");
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.Entero = SalidaMercanciaTipoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaTipoId");
                _dato.CadenaTexto = SalidaMercanciaFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SalidaMercanciaFecha");
                _dato.Entero = SalidaMercanciaUnidades;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SalidaMercanciaUnidades");
                _dato.DecimalValor = SalidaMercanciaSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaSub0");
                _dato.DecimalValor = SalidaMercanciaSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaSub16");
                _dato.DecimalValor = SalidaMercanciaIva;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "SalidaMercanciaIva");
                _dato.DecimalValor = SalidaMercanciaTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "SalidaMercanciaTotal");
                _dato.CadenaTexto = Observaciones;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Observaciones");
                _dato.CadenaTexto = Referencias;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Referencias");
                _dato.CadenaTexto = ParaSucursal;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ParaSucursal");


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
