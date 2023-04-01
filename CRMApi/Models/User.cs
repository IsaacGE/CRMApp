using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class User
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

    public int RoleId { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<Configuration> Configurations { get; } = new List<Configuration>();

    public virtual ICollection<Promotion> Promotions { get; } = new List<Promotion>();

    public virtual ICollection<Provider> Providers { get; } = new List<Provider>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
