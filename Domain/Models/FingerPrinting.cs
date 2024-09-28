using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FingerPrinting
{
    public long Id { get; set; }

    public string? UserAgent { get; set; }

    public int? ScreenWidth { get; set; }

    public int? ScreenHeight { get; set; }

    public int? Timezone { get; set; }

    public bool? JavaScriptEnabled { get; set; }

    public string? Plugins { get; set; }

    public string? Os { get; set; }

    public string? DeviceType { get; set; }

    public string? Language { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
