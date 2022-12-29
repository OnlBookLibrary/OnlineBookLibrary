using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class AdminStaff
{
    public int AccountId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
