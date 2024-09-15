using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Relation
{
    public long IdOfPost { get; set; }

    public long IdOfUser { get; set; }

    public DateTime? Watched { get; set; }

    public short UserScore { get; set; }

    public bool? Access { get; set; }

    public virtual Post IdOfPostNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
