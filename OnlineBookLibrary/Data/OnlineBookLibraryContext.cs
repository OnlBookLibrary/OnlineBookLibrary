using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;

namespace OnlineBookLibrary.Data
{
    public class OnlineBookLibraryContext : DbContext
    {
        public OnlineBookLibraryContext (DbContextOptions<OnlineBookLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineBookLibrary.Models.User> User { get; set; } = default!;

        public DbSet<OnlineBookLibrary.Models.Genre> Genre { get; set; } = default!;

        public DbSet<OnlineBookLibrary.Models.Book> Book { get; set; } = default!;

        public DbSet<OnlineBookLibrary.Models.Order>  Order { get; set; } = default!;

        public DbSet<OnlineBookLibrary.Models.OrderDetails> OrderDetails { get; set; } = default!;
    }
}
