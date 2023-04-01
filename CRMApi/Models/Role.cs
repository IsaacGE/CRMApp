using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public ICollection<User> Users { get; set;} = new List<User>();

}
