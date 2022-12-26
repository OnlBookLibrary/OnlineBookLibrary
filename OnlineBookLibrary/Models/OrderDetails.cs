using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OnlineBookLibrary.Models
{
    [PrimaryKey(nameof(Id))]
    public class OrderDetails
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }

        public Order? Order { get; set; }
        public Book? Book { get; set; }
    }
}
