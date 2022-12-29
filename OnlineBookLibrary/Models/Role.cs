using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AdminStaff> AdminStaffs { get; } = new List<AdminStaff>();
}
