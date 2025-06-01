using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Presentation.Functions;

public class SendEmail
{
    private readonly ILogger<SendEmail> _logger;
    private readonly string _busConnection = Environment.GetEnvironmentVariable("AzureServiceBus") ?? "";
    public SendEmail(ILogger<SendEmail> logger)
    {
        _logger = logger;
    }

    [Function(nameof(SendEmail))]
    public async Task Run(
        [ServiceBusTrigger("myqueue", Connection = "${_busConnection}")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}