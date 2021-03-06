﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLSDevolucionMayoreoLocal : ConexionBase
    {

        public string FechaFin { get; set; }
        public string FechaInicio { get; set; }

        public void MtdSeleccionarDevolucionMayoreo()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "asp_DevolucionMayoreo_Select";
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
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
