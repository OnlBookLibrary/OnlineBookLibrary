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
        public string Id { get; set; }
        public string BookId { get; set; }
        public string OrderId { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
