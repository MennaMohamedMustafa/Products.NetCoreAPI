using CourseLibrary.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseLibrary.API.DbContexts
{
    public class PracticeProductsContext : DbContext
    {
        public PracticeProductsContext(DbContextOptions<PracticeProductsContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            // seed the database with dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Chips",
                    Price = 5,
                    Quantity = 2,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Shrimp",
                    Price = 300,
                    Quantity = 1,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 3,
                    Name = "Potato",
                    Price = 15,
                    Quantity = 10,
                    CategoryId = 3
                },
               new Product()
               {
                   Id = 4,
                   Name = "Apple",
                   Price = 15,
                   Quantity = 10,
                   CategoryId = 4
               },
                 new Product()
                 {
                     Id = 5,
                     Name = "Cheese",
                     Price = 200,
                     Quantity = 2,
                     CategoryId = 5
                 }
                );

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Snacks"
               },
               new Category
               {
                   Id = 2,
                   Name = "Fish and Meat"
               },
               new Category
               {
                   Id = 3,
                   Name = "Vegetables"
               },
               new Category
               {
                   Id = 4,
                   Name = "Fruits"
               },

                new Category
                {
                    Id = 5,
                    Name = "Cheese and Diary"
                },

                new Category
                {
                    Id = 6,
                    Name = "Cosmetics"
                }
               );
        }
    }
}
