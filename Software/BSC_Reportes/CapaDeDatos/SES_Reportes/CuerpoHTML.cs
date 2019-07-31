using System;
using System.IO;
using System.Globalization;

namespace CapaDeDatos
{
    public class CuerpoHTML
    {
        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        
        public string vFolio { get;  set; }
        public string vProveedorId { get;  set; }
        public string vNombreProveedor { get;  set; }
        public string vRutaArchivos { get;  set; }

        public void CreaHTMLLiberaPedidos(string fileName)
        {
            string Fecha = string.Format("{0}-{1}-{2}", DateTime.Now.Year, DosCero(DateTime.Now.Month.ToString()), DosCero(DateTime.Now.Day.ToString()));
            DateTime date1 = DateTime.Now;
            string FechaLarga = date1.ToString("F", CultureInfo.CreateSpecificCulture("es-MX"));
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            StreamWriter writer = File.CreateText(fileName);
            writer.WriteLine("<html xmlns:v=\"urn:schemas-microsoft-com:vml\"");
            writer.WriteLine("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            writer.WriteLine("xmlns:w=\"urn:schemas-microsoft-com:office:word\"");
            writer.WriteLine("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            writer.WriteLine("xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml\"");
            writer.WriteLine("xmlns=\"http://www.w3.org/TR/REC-html40\">");
            writer.WriteLine("");
            writer.WriteLine("<body lang=ES-MX style='tab-interval:35.4pt'>");

            writer.WriteLine("<div class=WordSection1>");

            writer.WriteLine("<div class=MsoNormal><img id=\"_x0000_i1025\"");
            writer.WriteLine("src=\"cid:Soneli\"></div>");
            writer.WriteLine("");

            writer.WriteLine("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

            writer.WriteLine("<p class=MsoNormal style='mso-bidi-font-weight:normal'><b>");
            writer.WriteLine("<span style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine("color:black'>De:<span style='mso-tab-count:1'></span></span></b><span");
            writer.WriteLine("style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine("color:black'>Liberacion de Pedidos<o:p></o:p></span></p>");
            writer.WriteLine("");

            writer.WriteLine("<p class=MsoNormal style='mso-bidi-font-weight:normal'><b>");
            writer.WriteLine("<span style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine("color:black'>Enviado el: <span style='mso-tab-count:1'></span></span></b><span");
            writer.WriteLine("style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine(string.Format("color:black'>{0}<o:p></o:p></span></p>", FechaLarga));
            writer.WriteLine("");

            writer.WriteLine("<p class=MsoNormal style='mso-bidi-font-weight:normal'><b>");
            writer.WriteLine("<span style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine("color:black'>Para:<span style='mso-tab-count:1'></span></span></b><span");
            writer.WriteLine("style='font-family:\"Calibri\",sans-serif;mso-bidi-font-family:Calibri;");
            writer.WriteLine("color:black'>Usuarios de Entradas y Salidas<o:p></o:p></span></p>");
            writer.WriteLine("");
            writer.WriteLine("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

            writer.WriteLine("<p class=MsoNormal><b style = 'mso-bidi-font-weight:normal'>");
            writer.WriteLine("<span style='color:#00a3e8'>Detalles del Pedido: </span><o:p></o:p></span></b></p>");

            writer.WriteLine("<p class=MsoNormal><b style = 'mso-bidi-font-weight:normal'>");
            writer.WriteLine("<span style='color:#00a3e8'>Folio Pedido: </span>");
            writer.WriteLine("<span style = 'color:black;mso-themecolor:text1'>" + vFolio + "</span><o:p></o:p></b></p>");

            writer.WriteLine("<p class=MsoNormal><b style = 'mso-bidi-font-weight:normal'>");
            writer.WriteLine("<span style='color:#00a3e8'>Proveedor: </span>");
            writer.WriteLine("<span style = 'color:black;mso-themecolor:text1'>" + vProveedorId + "</span> - <span style = 'color:black;mso-themecolor:text1'>" + vNombreProveedor + "</span><o:p></o:p></span></b></p>");

            writer.WriteLine("<p class=MsoNormal><b style = 'mso-bidi-font-weight:normal' >");
            writer.WriteLine("<span style='color:#00a3e8'>Ruta Archivos: </span>");
            writer.WriteLine("<span style = 'color:black;mso-themecolor:text1'>" + vRutaArchivos + "</span><o:p></o:p></span></b></p>");

            writer.WriteLine("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

            writer.WriteLine("<p class=MsoNormal><span style='font-size:10.0pt;font-family:\"Calibri\",sans-serif;");
            writer.WriteLine("mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:");
            writer.WriteLine("\"Times New Roman\";mso-bidi-theme-font:minor-bidi'><o:p>&nbsp;</o:p></span></p>");
            writer.WriteLine("");
            writer.WriteLine("<p><span style='font-size:10.0pt;color:gray;background:white'>Este correo");
            writer.WriteLine("electrónico y, en su caso, cualquier fichero anexo al mismo, contiene");
            writer.WriteLine("información de carácter confidencial exclusivamente dirigida a su destinatario");
            writer.WriteLine("o destinatarios. Si no es vd. el destinatario indicado, queda notificado que la");
            writer.WriteLine("lectura, utilización, divulgación y/o copia sin autorización está prohibida en");
            writer.WriteLine("virtud de la legislación vigente. En el caso de haber recibido este correo");
            writer.WriteLine("electrónico por error, se ruega notificar inmediatamente esta circunstancia");
            writer.WriteLine("mediante reenvío a la dirección electrónica del remitente. &nbsp;Evite imprimir");
            writer.WriteLine("este mensaje si no es estrictamente necesario.</span></p>");
            writer.WriteLine("");

            writer.WriteLine("<p><span style='font-size:10.0pt;color:gray;background:white'>This email and");
            writer.WriteLine("any file attached to it (when applicable) contain(s) confidential information");
            writer.WriteLine("that is exclusively addressed to its recipient(s). If you are not the indicated");
            writer.WriteLine("recipient, you are informed that reading, using, disseminating and/or copying");
            writer.WriteLine("it without authorisation is forbidden in accordance with the legislation in");
            writer.WriteLine("effect. If you have received this email by mistake, please immediately notify");
            writer.WriteLine("the sender of the situation by resending it to their email address.&nbsp;Avoid");
            writer.WriteLine("printing this message if it is not absolutely necessary.</span></p>");
            writer.WriteLine("");
            writer.WriteLine("</div>");
            writer.WriteLine("");
            writer.WriteLine("</body>");
            writer.WriteLine("");
            writer.WriteLine("</html>");

            writer.Close();
        }

    }
}
