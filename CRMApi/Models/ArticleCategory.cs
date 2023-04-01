using System;
using System.Collections.Generic;

namespace CRMApi.Models;

public partial class ArticleCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();

    public virtual ICollection<Promotion> Promotions { get; } = new List<Promotion>();
}
