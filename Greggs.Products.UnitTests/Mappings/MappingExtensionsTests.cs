using Greggs.Products.Application.Mappings;
using Greggs.Products.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests.Mappings
{
    public class MappingExtensionsTests
    {
        [Fact]
        public void ToDTO_ShouldMapProductToProductDTO()
        {
            // Arrange
            var product = new Product
            {
                ProductID = 1,
                ProductName = "Sausage Roll",
                PriceInPounds = 1.0m,
                Description = "Sausage Roll",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false,
                Category = new Category { CategoryID = 1, Name = "Breakfast" },
                NutritionalInformations = new List<NutritionalInformation>
            {
                new NutritionalInformation
                {
                    NutritionID = 1,
                    NutrientID = 1,
                    Measurement = 100,
                    NutritionalValue = 50,
                    Nutrient = new Nutrient { NutrientID = 1, Name = "Protein", Unit = "g" }
                }
            }
            };

            // Act
            var productDTO = product.ToDTO();

            // Assert
            Assert.Equal(product.ProductID, productDTO.ProductID);
            Assert.Equal(product.ProductName, productDTO.ProductName);
            Assert.Equal(product.PriceInPounds, productDTO.PriceInPounds);
            Assert.Equal(product.Description, productDTO.Description);
            Assert.Equal(product.UpdatedDate, productDTO.UpdatedDate);
            Assert.Equal(product.CreatedDate, productDTO.CreatedDate);
            Assert.Equal(product.Category.Name, productDTO.Category.Name);
            Assert.Equal(product.Category.CategoryID, productDTO.Category.CategoryID);

            var nutritionalInfoDTO = productDTO.NutritionalInformations.First();
            Assert.Equal(product.NutritionalInformations.First().NutritionID, nutritionalInfoDTO.NutritionID);
            Assert.Equal(product.NutritionalInformations.First().NutritionalValue, nutritionalInfoDTO.NutritionalValue);
            Assert.Equal(product.NutritionalInformations.First().Measurement, nutritionalInfoDTO.Measurement);
            Assert.Equal(product.NutritionalInformations.First().Nutrient.NutrientID, nutritionalInfoDTO.Nutrient.NutrientID);
            Assert.Equal(product.NutritionalInformations.First().Nutrient.Name, nutritionalInfoDTO.Nutrient.Name);
            Assert.Equal(product.NutritionalInformations.First().Nutrient.Unit, nutritionalInfoDTO.Nutrient.Unit);
        
        }
    }
}
