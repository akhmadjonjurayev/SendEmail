
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CSRF_zaifligi.Service
{
    public class EmailSender : IEmailSender
    {
        private string host;
        private int port;
        private bool enableSSl;
        private string userName { get; set; }
        private string password { get; set; }
        public EmailSender(string host,int port,bool enableSSl,string userName,string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSl = enableSSl;
            this.userName = userName;
            this.password = password;
        }
        public Task SendEmail(string email,string subject,string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSl
            };
            return client.SendMailAsync(new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true });
        }
    }
    public interface IEmailSender
    {
        Task SendEmail(string email, string subject, string htmlMessage);
    }
}
