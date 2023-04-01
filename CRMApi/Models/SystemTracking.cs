using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class SystemTracking
{
    public int Id { get; set; }

    public string TkType { get; set; } = null!;

    public string TkDescription { get; set; } = null!;

    public string TkJsonbefore { get; set; } = null!;

    public string TkJsonafter { get; set; } = null!;
}
