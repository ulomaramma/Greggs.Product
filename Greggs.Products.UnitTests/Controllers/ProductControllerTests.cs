using Greggs.Products.Api.Controllers;
using Greggs.Products.Api.Models;
using Greggs.Products.Application.DTOs;
using Greggs.Products.Application.Interfaces.Services;
using Greggs.Products.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<ILogger<ProductController>> _mockLogger;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            _controller = new ProductController(_mockProductService.Object, _mockLogger.Object);
        }

        private List<ProductDTO> GetSampleProducts()
        {
            return new List<ProductDTO>
               {
                new ProductDTO
                {
                    ProductID = 1,
                    ProductName = "Sausage Roll",
                    PriceInPounds = 1.0m,
                    CategoryID = 1,
                    Description = "Sausage Roll",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Category = new CategoryDTO { CategoryID = 1, Name = "Breakfast" },
                    NutritionalInformations = new List<NutritionalInformationDTO>
                    {
                        new NutritionalInformationDTO
                        {
                            NutritionID = 1,
                            NutrientID = 1,
                            Measurement = 100,
                            NutritionalValue = 50,
                            Nutrient = new NutrientDTO { NutrientID = 1, Name = "Protein", Unit = "g" }
                        }
                    }
                },
                new ProductDTO
                {
                    ProductID = 2,
                    ProductName = "Vegan Sausage Roll",
                    PriceInPounds = 1.1m,
                    CategoryID = 1,
                    Description = "Vegan Sausage Roll",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Category = new CategoryDTO { CategoryID = 1, Name = "Breakfast" },
                    NutritionalInformations = new List<NutritionalInformationDTO>
                    {
                        new NutritionalInformationDTO
                        {
                            NutritionID = 2,
                            NutrientID = 2,
                            Measurement = 100,
                            NutritionalValue = 30,
                            Nutrient = new NutrientDTO { NutrientID = 2, Name = "Fat", Unit = "g" }
                        }
                    }
                }
            };
        }

        [Fact]
        public async Task GetLatestProducts_ReturnsOkResult_WhenProductsExist()
        {
            // Arrange

            var products = GetSampleProducts();
            _mockProductService.Setup(ps => ps.GetLatestProducts(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                               .ReturnsAsync(products);

            // Act
            var result = await _controller.GetLatestProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal(StatusCodes.Status200OK, apiResponse.Code);
            Assert.Equal(products, apiResponse.Data);
        }

        [Fact]
        public async Task GetLatestProducts_ReturnsNotFoundResult_WhenNoProductsExist()
        {
            // Arrange
            _mockProductService.Setup(ps => ps.GetLatestProducts(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                               .ReturnsAsync(Enumerable.Empty<ProductDTO>());

            // Act
            var result = await _controller.GetLatestProducts();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal(StatusCodes.Status404NotFound, apiResponse.Code);
            Assert.Null(apiResponse.Data);
        }

        [Fact]
        public async Task GetLatestProducts_ReturnsInternalServerErrorResult_WhenExceptionIsThrown()
        {
            // Arrange
            _mockProductService.Setup(ps => ps.GetLatestProducts(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                               .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetLatestProducts();

            // Assert
            var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, internalServerErrorResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(internalServerErrorResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Null(apiResponse.Data);
        }

        [Fact]
        public async Task GetLatestProductsPricesByLocation_ReturnsOkResult_WhenProductsExist()
        {
            // Arrange
            var products = GetSampleProducts();

            _mockProductService.Setup(ps => ps.GetLatestProductsPricesByLocation(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                               .ReturnsAsync(products);

            // Act
            var result = await _controller.GetLatestProductsPricesByLocation();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal(StatusCodes.Status200OK, apiResponse.Code);
            Assert.Equal(products, apiResponse.Data);
        }

        [Fact]
        public async Task GetLatestProductsPricesByLocation_ReturnsNotFoundResult_WhenNoProductsExist()
        {
            // Arrange
            _mockProductService.Setup(ps => ps.GetLatestProductsPricesByLocation(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                               .ReturnsAsync(Enumerable.Empty<ProductDTO>());

            // Act
            var result = await _controller.GetLatestProductsPricesByLocation();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal(StatusCodes.Status404NotFound, apiResponse.Code);
            Assert.Null(apiResponse.Data);
        }

        [Fact]
        public async Task GetLatestProductsPricesByLocation_ReturnsInternalServerErrorResult_WhenExceptionIsThrown()
        {
            // Arrange
            _mockProductService.Setup(ps => ps.GetLatestProductsPricesByLocation(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                               .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetLatestProductsPricesByLocation();

            // Assert
            var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, internalServerErrorResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<ProductDTO>>>(internalServerErrorResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Null(apiResponse.Data);
        }
    }
}
