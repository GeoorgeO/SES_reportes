using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.SES_Reportes
{
    class CLS_IndiceRotacion:ConexionBase
    {
        public object DBaseR { get;  set; }
        public string EFamilia { get;  set; }
        public string FechaFin { get;  set; }
        public string FechaInicio { get;  set; }

        public object PasswordR { get;  set; }
        public int? ProveedorId { get;  set; }
        public object ServerR { get;  set; }
        public object UserR { get;  set; }

        public void MtdSeleccionarIndiceRotacion()
        {
            TipoDato _dato = new TipoDato();
            string CadenaConexionRemota = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ServerR, DBaseR, UserR, PasswordR);
            Conexion _conexionR = new Conexion(CadenaConexionRemota);

            Exito = true;
            try
            {

                _conexionR.NombreProcedimiento = "SP_BSC_IndiceRotacion_Select";
                _dato.Entero = this.ProveedorId;
                _conexionR.agregarParametro(EnumTipoDato.Entero, _dato, "ProveedorId");
                _dato.CadenaTexto = this.FechaInicio;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = this.FechaFin;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _dato.CadenaTexto = this.EFamilia;
                _conexionR.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EFamilia");
                
                _conexionR.EjecutarDataset();

                if (_conexionR.Exito)
                {
                    Datos = _conexionR.Datos;
                }
                else
                {
                    Mensaje = _conexionR.Mensaje;
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
