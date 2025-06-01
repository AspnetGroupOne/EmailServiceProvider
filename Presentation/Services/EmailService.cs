using Microsoft.Extensions.Hosting.Internal;
using Azure.Communication.Email;
using Presentation.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics;



namespace Presentation.Services;

public class EmailService
{
    private readonly string _connectionString; 
    private readonly EmailClient _emailClient;
    private readonly string _fromEmailAddress;
    public EmailService()
    {
        _connectionString = Environment.GetEnvironmentVariable("AzureCommunicationServices") ?? "";
        _emailClient = new EmailClient(_connectionString);
        _fromEmailAddress = Environment.GetEnvironmentVariable("FromEmailAddress") ?? "";
    }

    public async Task<bool> SendEmail(SendEmailRequestForm request)
    {
        if(request == null) throw new ArgumentNullException(nameof(request));

        try
        {
            var content = new EmailContent(request.Subject)
            {
                PlainText = request.PlainTextContent,
                Html = request.HtmlContent,
            };

            

            List<EmailAddress> emailAddresses = new List<EmailAddress>();
                
            foreach (string EmailAddress in request.Recipients)
            {
                EmailAddress temp = new EmailAddress(EmailAddress);
                emailAddresses.Add(temp);
            }

            var recipients = new EmailRecipients(emailAddresses);

            var message = new EmailMessage(
                _fromEmailAddress,
                recipients, 
                content);

            var emailSendOperation = await _emailClient.SendAsync(Azure.WaitUntil.Completed, message);
            return true;
        }

        catch (Exception ex) 
        {
            Debug.WriteLine($"Email not sent error message: {ex.Message}");
            return false;
        }
    }
}
