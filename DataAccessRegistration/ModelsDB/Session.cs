using System;
using System.Collections.Generic;

namespace DataAccessRegistration.ModelsDB;

public partial class Session
{
    public string IdOfSession { get; set; } = null!;

    public string IdOfDevice { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string Token { get; set; } = null!;

    public virtual FingerPrinting IdOfDeviceNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
