using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.API.Database.Entities;
using OnlineBookstore.API.Models.UserModels;

namespace OnlineBookstore.API.Database.Context
{
    public class OnlineBookstoreContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public OnlineBookstoreContext(DbContextOptions<OnlineBookstoreContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
