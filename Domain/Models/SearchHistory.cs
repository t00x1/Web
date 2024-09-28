using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SearchHistory
{
    public long IdOfQuery { get; set; }

    public DateTime CreatedAt { get; set; }

    public long IdOfUser { get; set; }

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
