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
    }
}
