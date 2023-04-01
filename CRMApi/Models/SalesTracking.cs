using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class SalesTracking
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int SaleId { get; set; }

    public int SaleStatusId { get; set; }

    public int SaleProcessId { get; set; }

    public string Folio { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;

    public virtual SalesProcess SaleProcess { get; set; } = null!;

    public virtual SalesStatus SaleStatus { get; set; } = null!;
}
