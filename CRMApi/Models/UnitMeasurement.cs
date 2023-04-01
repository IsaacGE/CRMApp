using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class UnitMeasurement
{
    public int Id { get; set; }

    public string UnitKey { get; set; } = null!;

    public string UnitValue { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();
}
