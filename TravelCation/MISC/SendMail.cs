using System;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{
    private const string SMTP_SERVER_HOST = "smtp.gmail.com";
    private const int SMTP_SERVER_PORT = 587;
    private const string SMTP_USERNAME = "travelcation.developer@gmail.com";
    private const string SMTP_PASSWORD = "travelcation123";

    public void send(string toEmail, string subject, string body)
    {
        try
        {
            MailMessage msg = new MailMessage(SMTP_USERNAME, toEmail);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body = body;

            SmtpClient client = new SmtpClient(SMTP_SERVER_HOST, SMTP_SERVER_PORT);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = SMTP_USERNAME,
                Password = SMTP_PASSWORD
            };
            client.EnableSsl = true;
            client.Send(msg);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
    }
}