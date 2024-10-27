using System;
using System.Net;
using System.Net.Mail;

namespace SMTPMailSender
{
    class Program
    {
        static void Main()
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587; 
            string smtpUser = "sadeval2011@gmail.com"; 
            string smtpPass = "soab pnyc ilsn sgnh"; 

            string fromEmail = "sadeval2011@gmail.com";
            string subject = "Test Email";
            string body = "Это тестовое письмо для нескольких получателей";

            string[] recipients = new string[]
            {
                "recipient1@gmail.com",
                "recipient2@gmail.com",
                "recipient3@gmail.com"
            };

            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    client.EnableSsl = true; 

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(fromEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    foreach (var recipient in recipients)
                    {
                        mailMessage.To.Add(recipient);
                    }

                    client.Send(mailMessage);
                    Console.WriteLine("Email successfully sent to all recipients.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
