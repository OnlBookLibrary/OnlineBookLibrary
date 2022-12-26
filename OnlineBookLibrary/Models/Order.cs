using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace OnlineBookLibrary.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public User? User { get; set; }

        public ICollection<OrderDetails>? orderDetails { get; set; }
    }
}
