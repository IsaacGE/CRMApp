using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class Sale
{
    public int Id { get; set; }

    public double TotalQuantity { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal TotalCost { get; set; }

    public decimal TotalSaleTax { get; set; }

    public DateTime SaleDate { get; set; }

    public int Client { get; set; }

    public int SellerUser { get; set; }

    public string Folio { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; } = new List<SaleDetail>();

    public virtual ICollection<SalesTracking> SalesTrackings { get; } = new List<SalesTracking>();

    public virtual User SellerUserNavigation { get; set; } = null!;
}
