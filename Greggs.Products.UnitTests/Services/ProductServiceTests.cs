using Greggs.Products.Application.Interfaces.Helpers;
using Greggs.Products.Application.Interfaces.QueryBuilder;
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
        private readonly Mock<ICurrencyConversionHelper> _currencyConversionHelperMock;
        private readonly ProductService _productService;
        private readonly Mock<IProductQueryBuilder> _productQueryBuilderMock;


        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _locationRepositoryMock = new Mock<ILocationRepository>();
            _currencyConversionHelperMock = new Mock<ICurrencyConversionHelper>();
            _productQueryBuilderMock = new Mock<IProductQueryBuilder>();
            _productService = new ProductService(_productRepositoryMock.Object, _locationRepositoryMock.Object, _currencyConversionHelperMock.Object);
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
        public async Task GetLatestProducts_Returns_ProductDTOs()
        {
            // Arrange
            var products = GetSampleProducts();

            _productQueryBuilderMock.Setup(qb => qb.GetPagedProducts(It.IsAny<int>(), It.IsAny<int>()))
                           .ReturnsAsync(products);

            _productRepositoryMock.Setup(pr => pr.GetLatestProducts(It.IsAny<string>()))
                                  .Returns(_productQueryBuilderMock.Object);
            // Act
            var result = await _productService.GetLatestProducts(0, 10, "CreatedDate");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Sausage Roll", result.First().ProductName);
        }

        [Fact]
        public async Task GetLatestProductsPricesByLocation_Returns_ProdutsWithConvertedPrices()
        {
            // Arrange
            var products = GetSampleProducts();
            var location = new Location { Code = "EUR", ExchangeRateToPounds = 1.11M };

            _productQueryBuilderMock.Setup(qb => qb.GetPagedProducts(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);
            _productRepositoryMock.Setup(pr => pr.GetLatestProducts(It.IsAny<string>())).Returns(_productQueryBuilderMock.Object);
            _locationRepositoryMock.Setup(lr => lr.GetByLocationCodeAsync(It.IsAny<string>())).ReturnsAsync(location);
            _currencyConversionHelperMock.Setup(cch => cch.Convert(It.IsAny<decimal>(), It.IsAny<decimal>()))
                         .Returns((decimal amount, decimal rate) => Math.Round(amount * rate, 2));

            // Act
            var result = await _productService.GetLatestProductsPricesByLocation(0, 10, "CreatedDate", "EUR");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1.11m, result.First().ConvertedPrice);
            Assert.Equal(1.22m, result.Last().ConvertedPrice);
            Assert.All(result, r => Assert.Equal("EUR", r.ConvertedCurrency));
        }

        [Fact]
        public async Task GetLatestProductsPricesByLocation_ThrowsException_WhenInvalidLocationCode()
        {
            // Arrange
            var products = GetSampleProducts();
            _productQueryBuilderMock.Setup(qb => qb.GetPagedProducts(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(products);
            _productRepositoryMock.Setup(pr => pr.GetLatestProducts(It.IsAny<string>())).Returns(_productQueryBuilderMock.Object);
            _locationRepositoryMock.Setup(lr => lr.GetByLocationCodeAsync(It.IsAny<string>()))
                                   .ReturnsAsync((Location)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _productService.GetLatestProductsPricesByLocation(0, 10, "CreatedDate", "InvalidCode"));
        }





    }
}
