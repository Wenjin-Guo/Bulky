using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        //create "Categories" table from category.cs - - ->then in package Manager console add-migration , update-database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 }, 
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Horri", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Solution", StreetAddress="123 Tech St", City="Tech City",
                    PostalCode="M3N3C6", Province="ON", PhoneNumber="123523234"},
                new Company
                {
                    Id = 2,
                    Name = "Vivi Data",
                    StreetAddress = "999 Vivi St",
                    City = "Vivi City",
                    PostalCode = "M5W3C6",
                    Province = "ON",
                    PhoneNumber = "4645645688"
                },
                new Company
                {
                    Id = 3,
                    Name = "Tundra Club",
                    StreetAddress = "878 Main St",
                    City = "Lala Land",
                    PostalCode = "E3N3C6",
                    Province = "AL",
                    PhoneNumber = "310284872"
                },
                new Company
                {
                    Id = 4,
                    Name = "Wasabi Solution",
                    StreetAddress = "235 Wasabi St",
                    City = "Wasa City",
                    PostalCode = "D5O2V5",
                    Province = "MB",
                    PhoneNumber = "103765537"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Baby sope",
                    Description = "Absolutely the best baby soap",
                    UPCode = "SWD999901",
                    Manufacturer = "Delta",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                    CategoryId = 1,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 2,
                    Title = "Bike",
                    Description = "xcvwert3rsdf",
                    UPCode = "SWD999902",
                    Manufacturer = "Adidas",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                    CategoryId = 1,
                    ImageUrl = "",
                },

                new Product
                {
                    Id = 3,
                    Title = "Rice cooker",
                    Description = "e56cdzcwer5tdsfgdf",
                    UPCode = "SWD999903",
                    Manufacturer = "Spicy Pot",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                    CategoryId = 2,
                    ImageUrl = "",
                },

                new Product
                {
                    Id = 4,
                    Title = "T shirt",
                    Description = "sdafgrtuyrejs",
                    UPCode = "SWD999904",
                    Manufacturer = "Yiwu",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                    CategoryId = 3,
                    ImageUrl = "",
                }

            );


        }
    }
}
