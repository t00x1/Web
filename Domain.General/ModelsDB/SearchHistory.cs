using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class SearchHistory
{
    public string IdOfQuery { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string IdOfUser { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
