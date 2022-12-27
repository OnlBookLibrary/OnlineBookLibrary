using System;
using System.Collections.Generic;

namespace OnlineBookLibrary.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public double Price { get; set; }

    public string? Status { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();
}
