using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookLibrary.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }

    [DisplayName("Image Name")]
    public string? Image { get; set; } = null!;

    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }

    public double? Price { get; set; }

    public string? Status { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; } = null!;

    public virtual ICollection<OrderDetail>? OrderDetails { get; } = new List<OrderDetail>();
}
