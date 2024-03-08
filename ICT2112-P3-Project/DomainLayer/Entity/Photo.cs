using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Photo
{
    public long PhotoId { get; set; }

    public byte[] PhotoImage { get; set; } = null!;
}
