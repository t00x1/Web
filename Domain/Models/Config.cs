using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Config
{
    public long IdOfUser { get; set; }

    public bool Notifications { get; set; }

    public bool SaveHistory { get; set; }

    public bool EveryoneSeePosts { get; set; }

    public bool DarkTheme { get; set; }

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
