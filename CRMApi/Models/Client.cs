using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int Category { get; set; }

    public int RegisteringUser { get; set; }
    public string Password { get; set; } = null!;

    public virtual ClientsCategory CategoryNavigation { get; set; } = null!;

    public virtual User RegisteringUserNavigation { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
