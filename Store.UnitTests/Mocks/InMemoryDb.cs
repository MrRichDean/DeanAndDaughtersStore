using Microsoft.EntityFrameworkCore;
using Store.Entities.Context;
using Store.Entities.Models;

namespace Store.UnitTests.Mocks
{
    public static class InMemoryRecycleDb
    {
        public static StoreContext GetData(string databaseName)
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
              .UseInMemoryDatabase(databaseName: databaseName)
              .Options;

            var dbContext = new StoreContext(options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();


            dbContext.Books.Add(new Book { Id = 1, Author = "A. A. Milne", Title = "Winnie-the-Pooh", Price = 19.25 });
            dbContext.Books.Add(new Book { Id = 2, Author = "Jane Austen", Title = "Pride and Prejudice", Price = 5.49 });
            dbContext.Books.Add(new Book { Id = 3, Author = "William Shakespeare", Title = "Romeo and Juliet", Price = 6.95 });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
