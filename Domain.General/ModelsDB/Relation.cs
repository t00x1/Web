﻿using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Relation
{
    public string IdOfPost { get; set; } = null!;

    public string IdOfUser { get; set; } = null!;

    public DateTime? Watched { get; set; }

    public short UserScore { get; set; }

    public bool? Access { get; set; }

    public virtual Post IdOfPostNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
