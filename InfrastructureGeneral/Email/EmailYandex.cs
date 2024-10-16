using DomainGeneral;
using System;
using System.Net;
using System.Net.Mail;

namespace InfrastructureGeneral
{
    public class EmailYandex : ICodeEmail
    {
        private string _emailOut;
        private string _password;

        public EmailYandex(string emailOut, string password)
        {
            _emailOut = emailOut;
            _password = password;
        }

        public void SendCode( string emailIn,  string html,  string subject)
        {
            if (string.IsNullOrWhiteSpace(emailIn) || string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentException("Email address or HTML content cannot be null or empty.");
            }

            using (var smtpClient = new SmtpClient("smtp.yandex.ru")
            {
                Port = 587,
                Credentials = new NetworkCredential(_emailOut, _password),
                EnableSsl = true,
                Timeout = 10000
            })
            {
                try
                {
                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(_emailOut);
                        mailMessage.Subject = subject;
                        mailMessage.Body = html;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(emailIn);

                        smtpClient.Send(mailMessage);
                    }
                }
                catch (SmtpException smtpEx)
                {
                    Console.WriteLine($"SMTP Error: {smtpEx.Message}");
                    throw new InvalidOperationException("Failed to send email.", smtpEx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    throw new InvalidOperationException("An error occurred while sending the email.", ex);
                }
            }
        }
    }
}
