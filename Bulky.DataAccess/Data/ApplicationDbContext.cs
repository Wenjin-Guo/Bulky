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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 }, 
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Horri", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }
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
