A simple service to handle Emails communicates via AzureServiceBus and expects the following format:

</ul>
<li>
public List<String> Recipients { get; set; } = [];  
</li>

<li>
public string Subject { get; set; } = null!;
</li>  

<li>  
public string HtmlContent { get; set; } = null!;
</li>

<li>
public string PlainTextContent { get; set; } = null!;
</li>
<ul>
  
