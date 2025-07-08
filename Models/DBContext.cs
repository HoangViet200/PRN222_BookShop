using Microsoft.EntityFrameworkCore;
using PRN222_DreamsCar.Models;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace PRN222_BookShop.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.SubCategory)
                .WithMany(sc => sc.Books)
                .HasForeignKey(b => b.SubCategoryID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}