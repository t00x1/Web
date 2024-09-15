using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Notification
{
    public long IdOfNotification { get; set; }

    public long? IdOfUser { get; set; }

    public long? IdOfSession { get; set; }

    public long? IdOfFriendRequest { get; set; }

    public virtual FriendRequest? IdOfFriendRequestNavigation { get; set; }

    public virtual Session? IdOfSessionNavigation { get; set; }

    public virtual User? IdOfUserNavigation { get; set; }
}
