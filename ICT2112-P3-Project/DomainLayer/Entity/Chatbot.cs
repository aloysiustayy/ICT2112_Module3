using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Chatbot
{
    public long ChatId { get; set; }

    public string Timestamp { get; set; } = null!;

    public string Prompt { get; set; } = null!;

    public string Response { get; set; } = null!;

    public string GptapikeyId { get; set; } = null!;

    public long ToggleGpt { get; set; }

    public string Userinput { get; set; } = null!;
}
