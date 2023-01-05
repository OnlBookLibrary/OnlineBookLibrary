using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
