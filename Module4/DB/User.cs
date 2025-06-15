using System;
using System.Collections.Generic;

namespace Module4.DB;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime? EnterData { get; set; }

    public DateTime? LastData { get; set; }

    public bool? IsBlocked { get; set; }

    public virtual Role Role { get; set; } = null!;
}
