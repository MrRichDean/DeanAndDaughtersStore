using Microsoft.EntityFrameworkCore;
using Store.Entities.Models;

namespace Store.Entities.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasKey(ba => new {
                ba.Id
            });

            base.OnModelCreating(modelBuilder);
        }

       

    }
}
