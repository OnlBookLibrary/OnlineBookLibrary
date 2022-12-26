using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookLibrary.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book>? books { get; set; }
    }
}
