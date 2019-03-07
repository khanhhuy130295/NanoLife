using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Common
{
   public  class MailHelper
    {
        public void SendMail(string toEmail,string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var SMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var SMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enableSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            string body = content;

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmail));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = SMTPHost;
            client.Port = !string.IsNullOrEmpty(SMTPPort) ? Convert.ToInt32(SMTPPort) : 0;
            client.EnableSsl = enableSSL;

            try
            {
                client.Send(message);
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: {0}", e.StatusCode);
            }


        }
    }
}
