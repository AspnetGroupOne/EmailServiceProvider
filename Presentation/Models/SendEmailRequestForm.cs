namespace Presentation.Models;

public class SendEmailRequestForm
{
    public List<String> Recipients { get; set; } = [];
    public string Subject { get; set; } = null!;
    public string HtmlContent { get; set; } = null!;
    public string PlainTextContent { get; set; } = null!;
}
