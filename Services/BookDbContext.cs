using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<DbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.Category });

            modelBuilder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
