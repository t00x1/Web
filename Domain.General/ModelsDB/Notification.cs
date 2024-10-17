using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Notification
{
    public string IdOfNotification { get; set; } = null!;

    public string? IdOfUser { get; set; }

    public string? IdOfSession { get; set; }

    public string? IdOfFriendRequest { get; set; }

    public virtual FriendRequest? IdOfFriendRequestNavigation { get; set; }

    public virtual Session? IdOfSessionNavigation { get; set; }

    public virtual User? IdOfUserNavigation { get; set; }
}
