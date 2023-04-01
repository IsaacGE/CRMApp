using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class SalesProcess
{
    public int Id { get; set; }

    public string ProcessName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<SalesTracking> SalesTrackings { get; } = new List<SalesTracking>();
}
