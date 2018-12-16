using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Configuration;


namespace CapaDeDatos
{
    public class CLS_AppConfig
    {
        public void ConnectionStrings(string csName)
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();
            string valServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "ServerL"));
            string valDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBaseL"));
            string valLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "UserL"));
            string valPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "PasswordL"));
            String cadenaNueva = string.Format(@"XpoProvider=MSSqlServer;data source={0};user id={1}; password={2};initial catalog={3};Persist Security Info=true", valServer, valLogin, valPass, valDB);

            // Get the application configuration file.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int connStrCnt = ConfigurationManager.ConnectionStrings.Count;
            ConnectionStringSettings csSettings = new ConnectionStringSettings(csName, cadenaNueva);
            ConnectionStringsSection csSection = config.ConnectionStrings;
            config.ConnectionStrings.ConnectionStrings.Remove(csName);
            config.Save(ConfigurationSaveMode.Modified);
            csSection.ConnectionStrings.Add(csSettings);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}
