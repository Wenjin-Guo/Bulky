using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        //create "Categories" table from category.cs - - ->then in package Manager console add-migration , update-database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    Category = "Baby",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                },
                new Product
                {
                    Id = 2,
                    Title = "Bike",
                    Description = "xcvwert3rsdf",
                    UPCode = "SWD999902",
                    Category = "Sport",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                },

                new Product
                {
                    Id = 3,
                    Title = "Rice cooker",
                    Description = "e56cdzcwer5tdsfgdf",
                    UPCode = "SWD999903",
                    Category = "Kitchen",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                },

                new Product
                {
                    Id = 4,
                    Title = "T shirt",
                    Description = "sdafgrtuyrejs",
                    UPCode = "SWD999904",
                    Category = "Cloth",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 15,
                    Price100 = 13,
                }

            );


        }
    }
}
