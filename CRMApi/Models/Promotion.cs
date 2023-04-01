using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double DiscountPercentage { get; set; }

    public decimal Amount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public string? CityApply { get; set; }

    public int RegisteringUser { get; set; }

    public int? Article { get; set; }

    public int? Category { get; set; }

    public int? ClientCategory { get; set; }

    public virtual Article? ArticleNavigation { get; set; }

    public virtual ArticleCategory? CategoryNavigation { get; set; }

    public virtual ClientsCategory? ClientCategoryNavigation { get; set; }

    public virtual User RegisteringUserNavigation { get; set; } = null!;
}
