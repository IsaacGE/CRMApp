using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class ClientsCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<Promotion> Promotions { get; } = new List<Promotion>();
}
