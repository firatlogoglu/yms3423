using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.COMMON.MyTools
{
    public class MailSender
    {
        public static void Send(string receiver, string body="Deneme", string subject="Test", string sender="web@ramx.net",string password="PYoe45N5")
        {

            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            SmtpClient smtp = new SmtpClient
            {
                Host = "mail.ramx.net",
                Port = 587,
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            var message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }
    }
}
