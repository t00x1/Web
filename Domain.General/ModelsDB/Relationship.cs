using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Relationship
{
    public string IdOfSender { get; set; } = null!;

    public string IdOfReceiver { get; set; } = null!;

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User IdOfReceiverNavigation { get; set; } = null!;

    public virtual User IdOfSenderNavigation { get; set; } = null!;
}
