A simple service to handle Emails communicates via AzureServiceBus and expects the following format:
public List<String> Recipients { get; set; } = [];
public string Subject { get; set; } = null!;
public string HtmlContent { get; set; } = null!;
public string PlainTextContent { get; set; } = null!;
