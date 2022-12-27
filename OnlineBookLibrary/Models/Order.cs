using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();

    public virtual User User { get; set; } = null!;
}
