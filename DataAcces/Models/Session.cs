using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Session
{
    public long IdOfSession { get; set; }

    public long IdOfDevice { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Token { get; set; } = null!;

    public virtual FingerPrinting IdOfDeviceNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
