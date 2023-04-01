using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class SaleDetail
{
    public int Id { get; set; }

    public decimal SalePrice { get; set; }

    public decimal AaleTax { get; set; }

    public string JsonArticlePromotion { get; set; } = null!;

    public string JsonArticleDetail { get; set; } = null!;

    public int Article { get; set; }

    public int Sale { get; set; }

    public virtual Article ArticleNavigation { get; set; } = null!;

    public virtual Sale SaleNavigation { get; set; } = null!;
}
