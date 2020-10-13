using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;

namespace Shop.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Role> Roles {get;set;}
        public DbSet<UserRole> UserRoles {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Lastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Login).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Password).IsRequired();
            builder.Entity<User>().HasAlternateKey(x => x.Login);
            builder.Entity<User>().HasMany(x => x.UserRoles).WithOne(x => x.User);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x => x.Name).IsRequired();
            builder.Entity<Role>().HasAlternateKey(x => x.Name);
            builder.Entity<Role>().HasMany(x => x.UserRoles).WithOne(x => x.Role);

            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId});


            Role sa = new Role {Id = 1000, Name = "SuperAdmin"};
            Role admin = new Role {Id = 2000, Name = "Admin"};
            Role user = new Role {Id = 3000, Name = "User"};

            User u1 = new User
            {
                Id = 777,
                Name = "Serg",
                Lastname = "Yarosh",
                Login = "yaroshthebest",
                Password = "ilovecsharp"
            };
            User u2 = new User
            {
                Id = 771,
                Name = "V",
                Lastname = "S",
                Login = "Vitaliabetterthanserg",
                Password = "sergdno"
            };

            UserRole ur1 = new UserRole {UserId = 777, RoleId = 1000};
            UserRole ur2 = new UserRole {UserId = 777, RoleId = 2000};
            UserRole ur3 = new UserRole {UserId = 771, RoleId = 3000};

            builder.Entity<Role>().HasData(sa, admin, user);
            builder.Entity<User>().HasData(u1,u2);
            builder.Entity<UserRole>().HasData(ur1,ur2,ur3);



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
            builder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(x => x.ProductId);
            builder.Entity<Product>().Property(x => x.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(x => x.ProductCount).IsRequired();





            builder.Entity<Category>().HasData
            (
                new Category { CategoryId = 1000, CategoryName = "Notebook" },
                new Category { CategoryId = 1001, CategoryName = "Smartphone" },
                new Category { CategoryId = 1002, CategoryName = "Printer" },
                new Category { CategoryId = 1003, CategoryName = "TV" },
                new Category { CategoryId = 1004, CategoryName = "Headphones" },
                new Category { CategoryId = 1005, CategoryName = "Tablet" },
                new Category { CategoryId = 1006, CategoryName = "Camera" },
                new Category { CategoryId = 1007, CategoryName = "EBook Reader" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(x => x.ProductId);
            builder.Entity<Product>().Property(x => x.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(x => x.ProductCount).IsRequired();
            
            builder.Entity<Product>().HasData
            (
                new Product
                {
                    ProductId = 1001,
                    ProductName = "Dell ChromeBook Laptop NoteBook PC",
                    ProductCount = 1,
                    CategoryId = 1000
                },
                new Product
                {
                    ProductId = 1002,
                    ProductName = "Acer Aspire 5 Slim Laptop",
                    ProductCount = 13,
                    CategoryId = 1000
                },
                new Product
                {
                    ProductId = 1003,
                    ProductName = "HP 14in High Performance Laptop",
                    ProductCount = 12,
                    CategoryId = 1000
                },
                new Product
                {
                    ProductId = 1004,
                    ProductName = "ASUS VivoBook 15 Thin and Light Laptop",
                    ProductCount = 10,
                    CategoryId = 1000
                },
                new Product
                {
                    ProductId = 1005,
                    ProductName = "Lenovo 100E Chromebook 2ND Gen Laptop",
                    ProductCount = 10,
                    CategoryId = 1000
                },
                new Product
                {
                    ProductId = 1006,
                    ProductName = "Xiaomi Redmi Note 8",
                    ProductCount = 5,
                    CategoryId = 1001
                },
                new Product
                {
                    ProductId = 1007,
                    ProductName = "Samsung Galaxy A10",
                    ProductCount = 44,
                    CategoryId = 1001
                },
                new Product
                {
                    ProductId = 1008,
                    ProductName = "Brother Monochrome Black/White Laser Printer",
                    ProductCount = 2,
                    CategoryId = 1002
                },
                new Product
                {
                    ProductId = 1009,
                    ProductName = "HP LaserJet Pro M15w Wireless Laser Printer",
                    ProductCount = 8,
                    CategoryId = 1002
                },
                new Product
                {
                    ProductId = 1010,
                    ProductName = "TCL 32S325 32 Inch 720p Roku Smart LED TV",
                    ProductCount = 3,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1011,
                    ProductName = "VIZIO D-Series 24 Class Smart TV",
                    ProductCount = 10,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1012,
                    ProductName = "Westinghouse 50 4K Ultra HD Smart Roku TV",
                    ProductCount = 10,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1013,
                    ProductName = "LG OLED55B9PUA B9 Series 55 4K Ultra HD Smart OLED TV",
                    ProductCount = 11,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1014,
                    ProductName = "Samsung Electronics UN32J4001 32-Inch 720p LED TV",
                    ProductCount = 11,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1015,
                    ProductName = "VIZIO SmartCast D-Series 32-inch Class Smart Full-Array LED TV",
                    ProductCount = 12,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1016,
                    ProductName = "LG Electronics 22LJ4540 22-Inch 1080p IPS LED TV",
                    ProductCount = 50,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1017,
                    ProductName = "Hisense 32H5500F 32-Inch Android Smart TV",
                    ProductCount = 54,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1018,
                    ProductName = "LG Electronics 24LH4830-PU 24-Inch Smart LED TV",
                    ProductCount = 78,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1019,
                    ProductName = "Samsung Electronics UN32M4500BFXZA 720P Smart LED TV",
                    ProductCount = 90,
                    CategoryId = 1003
                },
                new Product
                {
                    ProductId = 1020,
                    ProductName = "Sony MDRZX110/BLK ZX Series Stereo Headphones",
                    ProductCount = 14,
                    CategoryId = 1004
                },
                new Product
                {
                    ProductId = 1021,
                    ProductName = "Bose QuietComfort 35 II Wireless Bluetooth Headphones",
                    ProductCount = 90,
                    CategoryId = 1004
                },
                new Product
                {
                    ProductId = 1022,
                    ProductName = "Samsung Galaxy Tab A 8.0 Wifi Android 9.0 Pie Tablet Black",
                    ProductCount = 20,
                    CategoryId = 1005
                },
                new Product
                {
                    ProductId = 1023,
                    ProductName = "Premium High Performance RCA Voyager Pro Touchscreen Tablet",
                    ProductCount = 20,
                    CategoryId = 1005
                },
                new Product
                {
                    ProductId = 1024,
                    ProductName = "Lenovo Tab M10 HD Android Tablet",
                    ProductCount = 95,
                    CategoryId = 1005
                },
                new Product
                {
                    ProductId = 1025,
                    ProductName = "Canon PowerShot SX420 Digital Camera",
                    ProductCount = 10,
                    CategoryId = 1006
                },
                 new Product
                 {
                     ProductId = 1026,
                     ProductName = "Kodak PIXPRO Friendly Zoom FZ53-BK 16MP Digital Camera",
                     ProductCount = 9,
                     CategoryId = 1006
                 },
                 new Product
                 {
                     ProductId = 1027,
                     ProductName = "Canon PowerShot ELPH 180 Digital Camera",
                     ProductCount = 40,
                     CategoryId = 1006
                 },
                 new Product
                 {
                     ProductId = 1028,
                     ProductName = "Canon PowerShot SX620 Digital Camera ",
                     ProductCount = 14,
                     CategoryId = 1006
                 },
                new Product
                {
                    ProductId = 1029,
                    ProductName = "Polaroid Originals OneStep 2 VF Instant Film Camera",
                    ProductCount = 15,
                    CategoryId = 1006
                },
                 new Product
                 {
                     ProductId = 1030,
                     ProductName = "Kobo Clara HD Carta E Ink Touchscreen E-Reader",
                     ProductCount = 10,
                     CategoryId = 1007
                 }
            );

        }
    }
}