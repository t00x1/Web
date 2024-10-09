using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Report
{
    public string IdOfPost { get; set; } = null!;

    public string IdOfReporter { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public short Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Post IdOfPostNavigation { get; set; } = null!;

    public virtual User IdOfReporterNavigation { get; set; } = null!;
}
