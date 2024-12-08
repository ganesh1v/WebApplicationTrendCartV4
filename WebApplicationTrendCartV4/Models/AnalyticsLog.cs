using System;
using System.Collections.Generic;

namespace WebApplicationTrendCartV4.Models;

public partial class AnalyticsLog
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string? EventType { get; set; } = null!;

    public string? Details { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; } = null!;
}
