using Greggs.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "BREAKFAST" },
                new Category { CategoryID = 2, Name = "HOT FOOD" },
                new Category { CategoryID = 3, Name = "SAVOURIES & BAKES" },
                new Category { CategoryID = 4, Name = "DRINKS & SNACKS" },
                new Category { CategoryID = 5, Name = "SANDWICHES & SALADS" },
                new Category { CategoryID = 6, Name = "SWEET TREATS" }

            );
            modelBuilder.Entity<Nutrient>().HasData(
                new Nutrient { NutrientID = 1, Name = "Carbohydrates", Unit = "g" },
                new Nutrient { NutrientID = 2, Name = "Protein", Unit = "g" },
                new Nutrient { NutrientID = 3, Name = "Fats", Unit = "g" },
                new Nutrient { NutrientID = 4, Name = "Energy kJ", Unit = "kcal" },
                new Nutrient { NutrientID = 5, Name = "Energy kcal", Unit = "kJ" },
                new Nutrient { NutrientID = 6, Name = "Sugars", Unit = "g" },
                new Nutrient { NutrientID = 7, Name = "Salt", Unit = "g" },
                new Nutrient { NutrientID = 8, Name = "of which Saturates", Unit = "g" },
                new Nutrient { NutrientID = 9, Name = "of which Sugars", Unit = "g" }

            );

            var products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Sausage Roll",
                    PriceInPounds = 1m,
                    CategoryID = 3,
                    Description = "A delicious sausage roll.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Vegan Sausage Roll",
                    PriceInPounds = 1.1m,
                    CategoryID = 3,
                    Description = "A tasty vegan sausage roll.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Steak Bake",
                    PriceInPounds = 1.2m,
                    CategoryID = 3,
                    Description = "A savory steak bake.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Yum Yum",
                    PriceInPounds = 0.7m,
                    CategoryID = 6,
                    Description = "A sweet treat.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Pink Jammie",
                    PriceInPounds = 0.5m,
                    CategoryID = 6,
                    Description = "A delicious pink jammie.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Mexican Baguette",
                    PriceInPounds = 2.1m,
                    CategoryID = 5,
                    Description = "A spicy Mexican baguette.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Bacon Sandwich",
                    PriceInPounds = 1.95m,
                    CategoryID = 1,
                    Description = "A delicious bacon sandwich.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Coca Cola",
                    PriceInPounds = 1.2m,
                    CategoryID = 4,
                    Description = "A refreshing Coca Cola.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                }
            };

            modelBuilder.Entity<Product>().HasData(products);

            var nutritionalInformations = new List<NutritionalInformation>
            {
                new NutritionalInformation
                {
                    NutritionID = 1,
                    ProductID = 1,
                    NutrientID = 1,
                    Measurement = 100,
                    NutritionalValue = 30
                },
                new NutritionalInformation
                {
                    NutritionID = 2,
                    ProductID = 1,
                    NutrientID = 2,
                    Measurement = 100,
                    NutritionalValue = 12
                },
                new NutritionalInformation
                {
                    NutritionID = 3,
                    ProductID = 1,
                    NutrientID = 3,
                    Measurement = 100,
                    NutritionalValue = 15
                },
                new NutritionalInformation
                {
                    NutritionID = 4,
                    ProductID = 1,
                    NutrientID = 4,
                    Measurement = 100,
                    NutritionalValue = 300
                },
                new NutritionalInformation
                {
                    NutritionID = 5,
                    ProductID = 1,
                    NutrientID = 5,
                    Measurement = 100,
                    NutritionalValue = 1256
                },
                new NutritionalInformation
                {
                    NutritionID = 6,
                    ProductID = 1,
                    NutrientID = 6,
                    Measurement = 100,
                    NutritionalValue = 3
                },
                new NutritionalInformation
                {
                    NutritionID = 7,
                    ProductID = 1,
                    NutrientID = 7,
                    Measurement = 100,
                    NutritionalValue = 1.5m
                },


                new NutritionalInformation
                {
                    NutritionID = 8,
                    ProductID = 2,
                    NutrientID = 1,
                    Measurement = 100,
                    NutritionalValue = 28
                },
                new NutritionalInformation
                {
                    NutritionID = 9,
                    ProductID = 2,
                    NutrientID = 2,
                    Measurement = 100,
                    NutritionalValue = 10
                },
                new NutritionalInformation
                {
                    NutritionID = 10,
                    ProductID = 2,
                    NutrientID = 3,
                    Measurement = 100,
                    NutritionalValue = 14
                },
                new NutritionalInformation
                {
                    NutritionID = 11,
                    ProductID = 2,
                    NutrientID = 4,
                    Measurement = 100,
                    NutritionalValue = 280
                },
                new NutritionalInformation
                {
                    NutritionID = 12,
                    ProductID = 2,
                    NutrientID = 5,
                    Measurement = 100,
                    NutritionalValue = 1172
                },
                new NutritionalInformation
                {
                    NutritionID = 13,
                    ProductID = 2,
                    NutrientID = 6,
                    Measurement = 100,
                    NutritionalValue = 2.5m
                },
                new NutritionalInformation
                {
                    NutritionID = 14,
                    ProductID = 2,
                    NutrientID = 7,
                    Measurement = 100,
                    NutritionalValue = 1.2m
                },

                new NutritionalInformation
                {
                    NutritionID = 15,
                    ProductID = 3,
                    NutrientID = 1,
                    Measurement = 100,
                    NutritionalValue = 29
                },
                new NutritionalInformation
                {
                    NutritionID = 16,
                    ProductID = 3,
                    NutrientID = 2,
                    Measurement = 100,
                    NutritionalValue = 11
                },
                new NutritionalInformation
                {
                    NutritionID = 17,
                    ProductID = 3,
                    NutrientID = 3,
                    Measurement = 100,
                    NutritionalValue = 18
                },
                new NutritionalInformation
                {
                    NutritionID = 18,
                    ProductID = 3,
                    NutrientID = 4,
                    Measurement = 100,
                    NutritionalValue = 290
                },
                new NutritionalInformation
                {
                    NutritionID = 19,
                    ProductID = 3,
                    NutrientID = 5,
                    Measurement = 100,
                    NutritionalValue = 1215
                },
                new NutritionalInformation
                {
                    NutritionID = 20,
                    ProductID = 3,
                    NutrientID = 6,
                    Measurement = 100,
                    NutritionalValue = 3
                },
                new NutritionalInformation
                {
                    NutritionID = 21,
                    ProductID = 3,
                    NutrientID = 7,
                    Measurement = 100,
                    NutritionalValue = 1.7m
                }
            };

            modelBuilder.Entity<NutritionalInformation>().HasData(nutritionalInformations);


            // Seed Location Data

            modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, Name = "Europe", Code = "EU", Currency = "EUR", ExchangeRateToPounds = 1.11m }
            );
        }
    }
}
