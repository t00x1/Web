using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FriendRequest
{
    public long IdOfFriendRequest { get; set; }

    public long IdOfSender { get; set; }

    public long IdOfReceiver { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime Updated { get; set; }

    public virtual User IdOfReceiverNavigation { get; set; } = null!;

    public virtual User IdOfSenderNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
