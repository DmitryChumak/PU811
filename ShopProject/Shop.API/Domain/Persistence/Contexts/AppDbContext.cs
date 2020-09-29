using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;

namespace Shop.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x => x.CategoryId);
            builder.Entity<Category>()
                    .Property(x => x.CategoryId)
                        .IsRequired()
                            .ValueGeneratedOnAdd();
            builder.Entity<Category>()
                        .Property(x => x.CategoryName)
                            .IsRequired()
                                .HasMaxLength(30);
            builder.Entity<Category>()
                    .HasMany(x => x.Products)
                        .WithOne(x => x.Category)
                            .HasForeignKey(x => x.CategoryId);


            builder.Entity<Category>().HasData
            (
                new Category
                {
                    CategoryId = 100,
                    CategoryName = "Smartphone"   
                },
                new Category
                {
                    CategoryId = 200,
                    CategoryName = "Laptop"
                }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(x => x.ProductId);
            builder.Entity<Product>().Property(x => x.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(x => x.ProductCount).IsRequired();
            


        }
    }
}