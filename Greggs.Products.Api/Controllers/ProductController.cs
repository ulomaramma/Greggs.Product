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

    

    [HttpGet("latestproduct")]
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

    // prices by location
    [HttpGet("pricesbylocation")]
    public async Task<IActionResult> GetLatestProductsPricesByLocation(int pageStart = 0, int pageSize = 10, string orderBy = "CreatedDate", string countryCode = "EU")
    {
        try
        {
            var products = await _productService.GetLatestProductsPricesByLocation(pageStart, pageSize, orderBy, countryCode);
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