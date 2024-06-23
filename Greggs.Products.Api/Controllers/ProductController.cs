﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greggs.Products.Api.Models;
using Greggs.Products.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    //private static readonly string[] Products = new[]
    //{
    //    "Sausage Roll", "Vegan Sausage Roll", "Steak Bake", "Yum Yum", "Pink Jammie"
    //};

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

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
    public async Task<IActionResult> Get(int pageStart = 0, int pageSize = 10)
    {
        var products = await _productService.List(pageStart, pageSize);
        return Ok(products);
    }

    [HttpGet("WithConvertedPrices")]
    public async Task<IActionResult> GetWithConvertedPrices(int pageStart = 0, int pageSize = 10, string countryCode = "EU")
    {
        try
        {
            var products = await _productService.ListWithConvertedPrices(pageStart, pageSize, countryCode);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("InEuros")]
    public async Task<IActionResult> GetWithPricesInEuros(int pageStart = 0, int pageSize = 10)
    {
        try
        {
            var products = await _productService.ListWithPricesInEuros(pageStart, pageSize);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}