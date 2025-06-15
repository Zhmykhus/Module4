using System;
using System.Collections.Generic;

namespace Module4.DB;

public partial class ObjectClient
{
    public int ClientId { get; set; }

    public int ObjectId { get; set; }

    public DateTime? FirstDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public decimal? Paid { get; set; }

    public int StatusId { get; set; }

    public decimal Cost { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Object Object { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
