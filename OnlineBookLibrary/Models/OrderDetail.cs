using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int OrderId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
