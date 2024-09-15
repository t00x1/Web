using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Relationship
{
    public long IdOfSender { get; set; }

    public long IdOfReceiver { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User IdOfReceiverNavigation { get; set; } = null!;

    public virtual User IdOfSenderNavigation { get; set; } = null!;
}
