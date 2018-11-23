using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using DevExpress.XtraEditors;

namespace CapaDeDatos
{

    public class CLS_Email : ConexionBase
    {
        public string EmailRemitente { get; set; }
        public string EmailUsuario { get; set; }
        public string EmailPass { get; set; }
        public string EmailServidorSalida { get; set; }
        public string EmailServidorEntrada { get; set; }
        public int EmailPuerto { get; set; }
        public string EmailDestino { get; set; }
        public string EmailAsunto { get; set; }
        public string EmailMensaje { get; set; }
        public Boolean EmailSSL { get; set; }
        public string UnSoloEmail { get; set; }
        public string Elementos { get; set; }

        public void Enviar_Email()
        {
            MailMessage objMail = new MailMessage();
            string Servidor = EmailServidorSalida;
            objMail.From = new MailAddress(EmailRemitente); //Remitente
            objMail.To.Add(EmailDestino.Trim()); //Email a enviar 
            objMail.Subject = EmailAsunto;
            objMail.IsBodyHtml = true; //Formato Html del email
            objMail.Body = EmailMensaje;
            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Host = Servidor; //el nombre del servidor de correo
            SmtpMail.EnableSsl = EmailSSL;
            SmtpMail.Port = EmailPuerto; //asignamos el numero de puerto
            SmtpMail.UseDefaultCredentials = false;
            SmtpMail.Credentials = new System.Net.NetworkCredential(EmailUsuario, EmailPass);
            SmtpMail.Send(objMail); //Enviamos el correo
        }

        public void MtdEnvioCorreo(string body, string correoDestinatario)
        {
            this.Exito = true;

            CLS_Correos ParmGen = new CLS_Correos();
            ParmGen.MtdSeleccionar();
            
            if (ParmGen.Exito)
            {
                EmailRemitente = ParmGen.Datos.Rows[0][0].ToString();
                EmailUsuario = ParmGen.Datos.Rows[0][1].ToString();
                EmailPass =ParmGen.Datos.Rows[0][2].ToString();
                EmailPuerto = Convert.ToInt32(ParmGen.Datos.Rows[0][6].ToString());
                EmailServidorSalida = ParmGen.Datos.Rows[0][3].ToString();
                EmailServidorEntrada = ParmGen.Datos.Rows[0][4].ToString();
                EmailSSL = Convert.ToBoolean(ParmGen.Datos.Rows[0][5].ToString());
                EmailDestino = correoDestinatario;
                EmailMensaje = body;
                EmailAsunto = EmailAsunto;
                Enviar_Email();
            }
        } 

        public void SendMailPrueba()
        {
            EmailMensaje = "Configuracion Correcta de los Datos";
            CLS_Correos ParmGen = new CLS_Correos();
            ParmGen.MtdSeleccionar();
            this.Exito = true;
            if (ParmGen.Exito)
            {
                EmailRemitente = ParmGen.Datos.Rows[0][0].ToString();
                EmailUsuario = ParmGen.Datos.Rows[0][1].ToString();
                EmailPass = ParmGen.Datos.Rows[0][2].ToString();
                EmailPuerto = Convert.ToInt32(ParmGen.Datos.Rows[0][6].ToString());
                EmailServidorSalida = ParmGen.Datos.Rows[0][3].ToString();
                EmailServidorEntrada = ParmGen.Datos.Rows[0][4].ToString();
                EmailSSL = Convert.ToBoolean(ParmGen.Datos.Rows[0][5].ToString());
            }
            // se define la lista de destinatarios
            //
            CLS_Correos emailboletin = new CLS_Correos();
            //se selecciona el listado de usuarios a los cuales se les envía el correo
            emailboletin.MtdSeleccionarCorreosDestino();
            List<string> destinatarios = new List<string>();
            if (emailboletin.Exito)
            {
                if (emailboletin.Datos.Rows.Count > 0)
                {
                    for (int x = 0; x < emailboletin.Datos.Rows.Count; x++)
                    {
                        destinatarios.Add(emailboletin.Datos.Rows[x][0].ToString());
                    }
                }
            }
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(EmailRemitente),
                Subject = "Prueba Configuracion Backup",
                IsBodyHtml = true
            };
            mail.Body = EmailMensaje;
            //
            // se asignan los destinatarios
            //
            foreach (string item in destinatarios)
            {
                mail.To.Add(new MailAddress(item));
            }
            //
            // se define el smtp
            //
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = EmailServidorSalida;
                smtp.Port = EmailPuerto;
                smtp.EnableSsl = EmailSSL;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(EmailUsuario, EmailPass);
                smtp.Send(mail);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void SendMailError()
        {
            CLS_Correos ParmGen = new CLS_Correos();
            ParmGen.MtdSeleccionar();
            this.Exito = true;
            if (ParmGen.Exito)
            {
                EmailRemitente = ParmGen.Datos.Rows[0][0].ToString();
                EmailUsuario = ParmGen.Datos.Rows[0][1].ToString();
                EmailPass = ParmGen.Datos.Rows[0][2].ToString();
                EmailPuerto = Convert.ToInt32(ParmGen.Datos.Rows[0][6].ToString());
                EmailServidorSalida = ParmGen.Datos.Rows[0][3].ToString();
                EmailServidorEntrada = ParmGen.Datos.Rows[0][4].ToString();
                EmailSSL = Convert.ToBoolean(ParmGen.Datos.Rows[0][5].ToString());
            }
            // se define la lista de destinatarios
            //
            CLS_Correos emailboletin = new CLS_Correos();
            //se selecciona el listado de usuarios a los cuales se les envía el correo
            emailboletin.MtdSeleccionarCorreosDestino();
            List<string> destinatarios = new List<string>();
            if (emailboletin.Exito)
            {
                if (emailboletin.Datos.Rows.Count > 0)
                {
                    for (int x = 0; x < emailboletin.Datos.Rows.Count; x++)
                    {
                        destinatarios.Add(emailboletin.Datos.Rows[x][0].ToString());
                    }
                }
            }
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(EmailRemitente),
                Subject = "Agent Backup DB",
                IsBodyHtml = true
            };
            mail.Body = EmailMensaje;
            //
            // se asignan los destinatarios
            //
            int i = 0;
            foreach (string item in destinatarios)
            {
                i++;
                mail.To.Add(new MailAddress(item));
            }
            //
            // se define el smtp
            //
            SmtpClient smtp = new SmtpClient();
            smtp.Host = EmailServidorSalida;
            smtp.Port = EmailPuerto;
            smtp.EnableSsl = EmailSSL;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailUsuario, EmailPass);
            if (i > 0)
            {
                smtp.Send(mail);
            }
        }
    }
}
