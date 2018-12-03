using System.Net;
using System.Net.Mail;
namespace HeuristicAnalysis.Infrastructure.Services
{
    public class EmailService
    {
        public static void SendEmail(EmailModel model)
        {
            var smtpServer = SetSmtp();
            var mail = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress("ipmistask@gmail.com"),
                Subject = "Welcome to heuristic evaluation application"
            };

            var bodyHtml = $"Welcome {model.Username}. Your current password is: {model.Password}. Please log in and change your password immediatelly.";

            mail.Body = bodyHtml;
            mail.To.Add(new MailAddress(model.MailTo));
            smtpServer.Send(mail);
        }

        private static SmtpClient SetSmtp()
        {
            var smtpServer = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("ipmistask@gmail.com", "IpmisTask1"),
                EnableSsl = true
            };
            return smtpServer;
        }
    }
}
