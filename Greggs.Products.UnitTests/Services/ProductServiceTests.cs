using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Application.Services;
using Greggs.Products.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ILocationRepository> _locationRepositoryMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _locationRepositoryMock = new Mock<ILocationRepository>();
            _configurationMock = new Mock<IConfiguration>();
            _productService = new ProductService(_productRepositoryMock.Object, _locationRepositoryMock.Object, _configurationMock.Object);
        }

        private List<Product> GetSampleProducts()
        {
            return new List<Product>
               {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Sausage Roll",
                    PriceInPounds = 1.0m,
                    CategoryID = 1,
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
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Vegan Sausage Roll",
                    PriceInPounds = 1.1m,
                    CategoryID = 1,
                    Description = "Vegan Sausage Roll",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    Category = new Category { CategoryID = 1, Name = "Breakfast" },
                    NutritionalInformations = new List<NutritionalInformation>
                    {
                        new NutritionalInformation
                        {
                            NutritionID = 2,
                            NutrientID = 2,
                            Measurement = 100,
                            NutritionalValue = 30,
                            Nutrient = new Nutrient { NutrientID = 2, Name = "Fat", Unit = "g" }
                        }
                    }
                }
            };
        }


        [Fact]
        public async Task List_ShouldReturnProductDTOs()
        {
            // Arrange
            var products = GetSampleProducts();
            _productRepositoryMock.Setup(repo => repo.List(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);

            // Act
            var result = await _productService.List(0, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Sausage Roll", result.First().ProductName);
        }

        [Fact]
        public async Task ListWithPricesInEuros_ShouldReturnConvertedPrices()
        {
            // Arrange
            var products = GetSampleProducts();

            _productRepositoryMock.Setup(repo => repo.List(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);
            _configurationMock.Setup(config => config["ExchangeRates:GBPToEUR"]).Returns("1.11");

            // Act
            var result = await _productService.ListWithPricesInEuros(0, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1.11m, result.First().ConvertedPrice);
            Assert.Equal(1.22m, result.Last().ConvertedPrice);
            Assert.All(result, r => Assert.Equal("EUR", r.ConvertedCurrency));
        }

        [Fact]
        public async Task ListWithPricesInEuros_ShouldThrowException_WhenConversionRateIsNotConfigured()
        {
            // Arrange
            _configurationMock.Setup(config => config["ExchangeRates:GBPToEUR"]).Returns((string)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _productService.ListWithPricesInEuros(0, 10));
        }

        [Fact]
        public async Task ListWithPricesInEuros_ShouldThrowException_WhenConversionRateIsInvalid()
        {
            // Arrange
            _configurationMock.Setup(config => config["ExchangeRates:GBPToEUR"]).Returns("invalid");

            // Act & Assert
            await Assert.ThrowsAsync<FormatException>(() => _productService.ListWithPricesInEuros(0, 10));
        }

        [Fact]
        public async Task ListWithConvertedPrices_ShouldConvertPrices()
        {
            // Arrange
            var products = GetSampleProducts();
            var location = new Location { LocationId = 1, Code = "EUR", ExchangeRateToPounds = 1.11m, Currency = "EUR" };

            _productRepositoryMock.Setup(repo => repo.List(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);
            _locationRepositoryMock.Setup(repo => repo.GetByLocationCodeAsync(It.IsAny<string>())).ReturnsAsync(location);

            // Act
            var result = await _productService.ListWithConvertedPrices(0, 10, "EUR");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1.11m, result.First().ConvertedPrice);
            Assert.Equal(1.22m, result.Last().ConvertedPrice);
            Assert.All(result, r => Assert.Equal("EUR", r.ConvertedCurrency));
        }

        [Fact]
        public async Task ListWithConvertedPrices_ShouldThrowException_WhenLocationIsNull()
        {
            // Arrange
            var products = GetSampleProducts();

            _productRepositoryMock.Setup(repo => repo.List(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);
            _locationRepositoryMock.Setup(repo => repo.GetByLocationCodeAsync(It.IsAny<string>())).ReturnsAsync((Location)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _productService.ListWithConvertedPrices(0, 10, "EUR"));
        }
    }
}
