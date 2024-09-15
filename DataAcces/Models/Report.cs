using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Report
{
    public long IdOfPost { get; set; }

    public long IdOfReporter { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public short Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Post IdOfPostNavigation { get; set; } = null!;

    public virtual User IdOfReporterNavigation { get; set; } = null!;
}
