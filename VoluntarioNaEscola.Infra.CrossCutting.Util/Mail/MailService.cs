using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VoluntarioNaEscola.Infra.CrossCutting.Util.Mail
{
    public class MailService
    {
        private string smtpAddress;
        private int portNumber;
        private bool enableSSL = true;
        private string emailFrom = "silva.pucrs@gmail.com";
        private string password = "lapro203";

        public MailService(string smtpAddress = "smtp.live.com", int portNumber = 587, bool enableSSL = true)
        {
            this.smtpAddress = smtpAddress;
            this.portNumber = portNumber;
            this.enableSSL = enableSSL;
        }

        //public void SendMail(string emailTo, string subject, string body)
        //{

        //    using (MailMessage mail = new MailMessage())
        //    {
        //        mail.From = new MailAddress(emailFrom);
        //        mail.To.Add(emailTo);
        //        mail.Subject = subject;
        //        mail.Body = body;
        //        mail.IsBodyHtml = true;
        //        // Can set to false, if you are sending pure text.

        //       // mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
        //       // mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

        //        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        //        {
        //            smtp.Credentials = new NetworkCredential(emailFrom, password);
        //            smtp.EnableSsl = enableSSL;
        //            smtp.Send(mail);
        //        }
        //    }
        //}

        public async Task SendEmail(string toEmailAddress, string emailSubject, string emailMessage)
        {
            var message = new MailMessage();
            message.To.Add(toEmailAddress);
            message.From = new MailAddress(emailFrom);
            message.Subject = emailSubject;
            message.Body = emailMessage;
            message.IsBodyHtml = true;
         

            using (var smtpClient = new SmtpClient()
            {
                Host = smtpAddress,
                Port = portNumber,
                EnableSsl = enableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailFrom, password)
            })
            {

                await smtpClient.SendMailAsync(message);
            }
        }



    }
}
