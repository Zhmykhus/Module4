using System;
using System.Collections.Generic;

namespace Module4.DB;

public partial class Object
{
    public int Id { get; set; }

    public string Adress { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
