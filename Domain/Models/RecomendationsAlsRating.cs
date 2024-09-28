using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RecomendationsAlsRating
{
    public long IdOfPost { get; set; }

    public long IdOfUser { get; set; }

    public short ExpectedScore { get; set; }

    public virtual Post IdOfPostNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
