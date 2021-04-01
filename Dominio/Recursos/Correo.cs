using Infraestructura;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Dominio.Recursos
{
    public class Correo
    {

        public void Sencillo(string CorreoEmpresa, string ClaveEmpresa, string smtpEmpresa,
            int Port, bool EnableSsl, string CorreoUsuario, string Asunto, string Mensaje)
        {
            MailAddress fromAddress = new MailAddress("TiendaOnline@frutafresca.com.co");
            string subject = Asunto;
            string body = (" <font face=\"Verdana\">"
                        + (Mensaje + ""));
            SmtpClient smtp = new SmtpClient(smtpEmpresa);
            smtp.Port = Port;
            smtp.EnableSsl = EnableSsl;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoEmpresa, ClaveEmpresa);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoUsuario);
            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            try
            {
                smtp.Send(message);
            }
            catch (Exception Ex)
            {
                var Respuesta = Ex.Message.ToString();
            }
        }

        public void Adjunto(string CorreoUsuario, string Asunto, string Mensaje, string RutaArchivos)
        {
            MailAddress fromAddress = new MailAddress(Configuraciones.CorreoEmpresa);
            string subject = Asunto;
            string body = (" <font face=\"Verdana\">"
                        + (Mensaje + ""));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Configuraciones.CorreoEmpresa, Configuraciones.ClaveEmpresa);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoUsuario);
            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            string[] Archivos = Directory.GetFiles(RutaArchivos);
            foreach (string Archivo in Archivos)
            {
                Attachment ArchAdjunto = new Attachment(Archivo);
                message.Attachments.Add(ArchAdjunto);
            }

            try
            {
                smtp.Send(message);
            }
            catch (Exception Ex)
            {
                var Respuesta = Ex.Message.ToString();
            }
        }

        public void Banner(string CorreoUsuario, string Asunto, string Mensaje, string RutaBanner)
        {
            MailAddress fromAddress = new MailAddress(Configuraciones.CorreoEmpresa);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Configuraciones.CorreoEmpresa, Configuraciones.ClaveEmpresa);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoUsuario);
            message.From = fromAddress;
            message.Subject = Asunto;
            message.IsBodyHtml = true;

            //Cuerpo del mensaje con imagen
            string html = "<h2>" + Mensaje + "</h2> <img src='cid:imagen' />";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
            LinkedResource img = new LinkedResource(@"" + RutaBanner + "", MediaTypeNames.Image.Jpeg);
            img.ContentId = "imagen";
            htmlView.LinkedResources.Add(img);
            message.AlternateViews.Add(htmlView);

            try
            {
                smtp.Send(message);
            }
            catch (Exception Ex)
            {
                var Respuesta = Ex.Message.ToString();
            }
        }
    }
}
