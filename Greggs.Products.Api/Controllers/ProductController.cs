using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greggs.Products.Api.Models;
using Greggs.Products.Application.DTOs;
using Greggs.Products.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;

    }

    //private static readonly string[] Products = new[]
    //{
    //    "Sausage Roll", "Vegan Sausage Roll", "Steak Bake", "Yum Yum", "Pink Jammie"
    //};

    //[HttpGet]
    //public IEnumerable<Product> Get(int pageStart = 0, int pageSize = 5)
    //{
    //    if (pageSize > Products.Length)
    //        pageSize = Products.Length;

    //    var rng = new Random();
    //    return Enumerable.Range(1, pageSize).Select(index => new Product
    //    {
    //        PriceInPounds = rng.Next(0, 10),
    //        Name = Products[rng.Next(Products.Length)]
    //    })
    //        .ToArray();
    //}

    [HttpGet]
    public async Task<IActionResult> GetLatestProducts(int pageStart = 0, int pageSize = 10, string orderBy = "CreatedDate")
    {
        try
        {
            var products = await _productService.GetLatestProducts(pageStart, pageSize, orderBy);
            if (products == null || !products.Any())
            {
                var response = new ApiResponse<IEnumerable<ProductDTO>>(false, StatusCodes.Status404NotFound, null, "No products found.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<IEnumerable<ProductDTO>>(true, StatusCodes.Status200OK, products);
            return Ok(successResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while retrieving latest product.");
            var response = new ApiResponse<IEnumerable<ProductDTO>>(false, StatusCodes.Status500InternalServerError, null, "An unexpected error occurred while retrieving latest product.");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    //[HttpGet("InEuros")]
    //public async Task<IActionResult> GetWithPricesInEuros(int pageStart = 0, int pageSize = 10)
    //{
    //    try
    //    {
    //        var products = await _productService.ListWithPricesInEuros(pageStart, pageSize);
    //        return Ok(products);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    [HttpGet("PricesByLocation")]
    public async Task<IActionResult> GetProductPricesByLocation(int pageStart = 0, int pageSize = 10, string countryCode = "EU")
    {
        try
        {
            var products = await _productService.ListWithConvertedPrices(pageStart, pageSize, countryCode);
            if (products == null || !products.Any())
            {
                var response = new ApiResponse<IEnumerable<ProductDTO>>(false, StatusCodes.Status404NotFound, null, "No products found.");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<IEnumerable<ProductDTO>>(true, StatusCodes.Status200OK, products);
            return Ok(successResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while retrieving products with converted prices.");
            var response = new ApiResponse<IEnumerable<ProductDTO>>(false, StatusCodes.Status500InternalServerError, null, "An unexpected error occurred while retrieving products with converted prices.");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

   
}