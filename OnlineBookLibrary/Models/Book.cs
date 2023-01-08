using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OnlineBookLibrary.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Description { get; set; }
    [DisplayName("Image Name")]
    public string? Image { get; set; }
    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }
    public double? Price { get; set; }

    public string? Status { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
