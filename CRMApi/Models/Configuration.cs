using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Configuration
{
    public int Id { get; set; }

    public string ConfigKey { get; set; } = null!;

    public string ConfigValue { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public int RegisteringUser { get; set; }

    public virtual User RegisteringUserNavigation { get; set; } = null!;
}
