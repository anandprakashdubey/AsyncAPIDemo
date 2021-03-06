using AsyncAPIDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPIDemo.Context
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("47e57a40-323d-4253-a788-b96025013e50"),
                    FirstName = "Agatha",
                    LastName = "Kristie"
                },
                 new Author()
                 {
                     Id = Guid.Parse("a33a9a0f-98f8-45da-b4d2-08d95c406cb5"),
                     FirstName = "Paulo",
                     LastName = "Cohelo"
                 }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("098a5bbf-4783-4c6d-8097-e0ff0f33c205"),
                    AuthorId = Guid.Parse("47e57a40-323d-4253-a788-b96025013e50"),
                    Title = "Murder of Rozer Ackward",
                    Description = "Some Book",

                },
                 new Book()
                 {
                     Id = Guid.Parse("bd479151-9426-49c1-b827-267a076164a8"),
                     AuthorId = Guid.Parse("a33a9a0f-98f8-45da-b4d2-08d95c406cb5"),
                     Title = "Alchemist",
                     Description = "Fiction Book",

                 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
