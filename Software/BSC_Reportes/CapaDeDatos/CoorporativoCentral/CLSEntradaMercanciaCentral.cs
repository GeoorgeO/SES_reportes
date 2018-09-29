using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSEntradaMercanciaCentral : ConexionBase
    {

        public int EntradaMercanciaId { get; set; }
        public int SucursalesId { get; set; }
        public int UsuariosId { get; set; }
        public int EntradaMercanciaTipoId { get; set; }
        public string EntradaMercanciaFecha { get; set; }
        public int EntradaMercanciaUnidades { get; set; }
        public decimal EntradaMercanciaSub0 { get; set; }
        public decimal EntradaMercanciaSub16 { get; set; }
        public decimal EntradaMercanciaIva { get; set; }
        public decimal EntradaMercanciaTotal { get; set; }
        public string Observaciones { get; set; }
        public string Referencias { get; set; }


        public void MtdActualizarEntradaMercancia()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexionC.NombreProcedimiento = "SP_BSC_EntradaMercancia_General";
                _dato.Entero = EntradaMercanciaId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaId");
                _dato.Entero = SucursalesId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "SucursalesId");
                _dato.Entero = UsuariosId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "UsuariosId");
                _dato.Entero = EntradaMercanciaTipoId;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaTipoId");
                _dato.CadenaTexto = EntradaMercanciaFecha;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EntradaMercanciaFecha");
                _dato.Entero = EntradaMercanciaUnidades;
                _conexionC.agregarParametro(EnumTipoDato.Entero, _dato, "EntradaMercanciaUnidades");
                _dato.DecimalValor = EntradaMercanciaSub0;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaSub0");
                _dato.DecimalValor = EntradaMercanciaSub16;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaSub16");
                _dato.DecimalValor = EntradaMercanciaIva;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EntradaMercanciaIva");
                _dato.DecimalValor = EntradaMercanciaTotal;
                _conexionC.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "EntradaMercanciaTotal");
                _dato.CadenaTexto = Observaciones;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Observaciones");
                _dato.CadenaTexto = Referencias;
                _conexionC.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Referencias");
                


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
