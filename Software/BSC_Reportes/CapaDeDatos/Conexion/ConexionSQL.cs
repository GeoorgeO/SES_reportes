﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace CapaDeDatos
{
    
    public class ConexionSQL
    {
        

        const string NombreProyecto = "BSC-Reportes";
        static public string LeerConexion()
        {
            string StrConexion;
            string valServer;
            string valDB;
            string valLogin;
            string valPass;
            try
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "ServerL");
                valDB = RegOut.GetSetting("ConexionSQL", "DBaseL");
                valLogin = RegOut.GetSetting("ConexionSQL", "UserL");
                valPass = RegOut.GetSetting("ConexionSQL", "PasswordL");
                if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerL"));
                    valDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseL"));
                    valLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserL"));
                    valPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordL"));
                }
                else
                {
                    throw new Exception("Faltan datos para la Conexión");
                }
            }

            catch
            {
                valServer = string.Empty;
                valDB = string.Empty;
                valLogin = string.Empty;
                valPass = string.Empty;
            }

            if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
            {
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }
            else
            {


                throw new Exception("Faltan datos para la Conexión");

            }
        }
        static public string LeerConexionR(string ServerR, string DBaseR, string UserR, string PasswordR)
        {
            try
            {
                string StrConexion;
                string ValServerR=string.Empty;
                string ValDBaseR = string.Empty;
                string ValUserR = string.Empty;
                string ValPassR = string.Empty;

                if (ServerR != null && DBaseR != null && UserR != null && PasswordR != null)
                {
                    MSRegistro RegOut = new MSRegistro();
                    Crypto DesencriptarTexto = new Crypto();
                    ValServerR = DesencriptarTexto.Desencriptar(ServerR);
                    ValDBaseR = DesencriptarTexto.Desencriptar(DBaseR);
                    ValUserR = DesencriptarTexto.Desencriptar(UserR);
                    ValPassR = DesencriptarTexto.Desencriptar(PasswordR);

                }
                StrConexion = "Data Source=" + ValServerR + ";Initial Catalog=" + ValDBaseR + ";Persist Security Info=True;User ID=" + ValUserR + ";Password=" + ValPassR;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public string LeerConexionC()
        {
            string StrConexion;
            string valServer;
            string valDB;
            string valLogin;
            string valPass;
            try
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "ServerC");
                valDB = RegOut.GetSetting("ConexionSQL", "DBaseC");
                valLogin = RegOut.GetSetting("ConexionSQL", "UserC");
                valPass = RegOut.GetSetting("ConexionSQL", "PasswordC");
                if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerC"));
                    valDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseC"));
                    valLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserC"));
                    valPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordC"));
                }
                else
                {
                    throw new Exception("Faltan datos para la Conexión");
                }
            }

            catch
            {
                valServer = string.Empty;
                valDB = string.Empty;
                valLogin = string.Empty;
                valPass = string.Empty;
            }

            if (valServer != string.Empty && valLogin != string.Empty && valLogin != string.Empty && valPass != string.Empty)
            {
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }
            else
            {
                

                throw new Exception("Faltan datos para la Conexión");


            }
        }
        static public string LeerConexionRC(string ServerC, string DBaseC, string UserC, string PasswordC)
        {
            try
            {
                string StrConexion;
                string ValServerC = string.Empty;
                string ValDBaseC = string.Empty;
                string ValUserC = string.Empty;
                string ValPassC = string.Empty;

                if (ServerC != null && DBaseC != null && UserC != null && PasswordC != null)
                {
                    MSRegistro RegOut = new MSRegistro();
                    Crypto DesencriptarTexto = new Crypto();
                    ValServerC = DesencriptarTexto.Desencriptar(ServerC);
                    ValDBaseC = DesencriptarTexto.Desencriptar(DBaseC);
                    ValUserC = DesencriptarTexto.Desencriptar(UserC);
                    ValPassC = DesencriptarTexto.Desencriptar(PasswordC);

                }
                StrConexion = "Data Source=" + ValServerC + ";Initial Catalog=" + ValDBaseC + ";Persist Security Info=True;User ID=" + ValUserC + ";Password=" + ValPassC;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string LeerConexionL()
        {
            try
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "ServerL"));
                ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBaseL"));
                ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "UserL"));
                ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "PasswordL"));


                StrConexion = "Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean ValidaConexion()
        {
            try
            {
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                try
                {
                    ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                    ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                    ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                    ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));
                }
                catch
                {
                    ValServer = string.Empty;
                    ValDBase = string.Empty;
                    ValUser = string.Empty;
                    ValPass = string.Empty;
                }

                if (ValServer != string.Empty && ValDBase != string.Empty && ValUser != string.Empty && ValPass != string.Empty)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass);
                        conn.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                { 
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }
}
