using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Article
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Cost { get; set; }

    public double Count { get; set; }

    public bool Status { get; set; }

    public DateTime RegisterDate { get; set; }

    public int Provider { get; set; }

    public int Category { get; set; }

    public int UnitMeasurement { get; set; }

    public int RegisteringUser { get; set; }

    public virtual ArticleCategory CategoryNavigation { get; set; } = null!;

    public virtual ICollection<Promotion> Promotions { get; } = new List<Promotion>();

    public virtual Provider ProviderNavigation { get; set; } = null!;

    public virtual User RegisteringUserNavigation { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; } = new List<SaleDetail>();

    public virtual UnitMeasurement UnitMeasurementNavigation { get; set; } = null!;
}
