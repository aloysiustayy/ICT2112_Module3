using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Message
{
    public long MessageId { get; set; }

    public long ChatId { get; set; }

    public long SenderId { get; set; }

    public string Dialog { get; set; } = null!;

    public string Timestamp { get; set; } = null!;
}
