using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public int RegisteringUser { get; set; }
    public string Password { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();

    public virtual User RegisteringUserNavigation { get; set; } = null!;
}
