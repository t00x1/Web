using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Config
{
    public string IdOfUser { get; set; } = null!;

    public bool Notifications { get; set; }

    public bool SaveHistory { get; set; }

    public bool EveryoneSeePosts { get; set; }

    public bool DarkTheme { get; set; }

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
