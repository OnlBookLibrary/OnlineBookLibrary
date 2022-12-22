using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBookLibrary.Models
{
    [PrimaryKey(nameof(Id))]
    public class Book
    {
        public string Id { get; set; }
        
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string status { get; set; }

        public string GenreId { get; set; }
        public Genre? Genre { get; set; }

        public ICollection<OrderDetails> orderDetails { get; set; }
    }
}
