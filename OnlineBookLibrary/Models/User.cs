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
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [DisplayName("Login Name")]
        public string LoginName { get; set; }

        public string Password { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
