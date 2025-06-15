using System;
using System.Collections.Generic;

namespace Module4.DB;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();
}
