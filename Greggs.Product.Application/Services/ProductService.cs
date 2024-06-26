﻿using Greggs.Products.Application.Constants;
using Greggs.Products.Application.DTOs;
using Greggs.Products.Application.Helpers;
using Greggs.Products.Application.Interfaces.Helpers;
using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Application.Interfaces.Services;
using Greggs.Products.Application.Mappings;
using Greggs.Products.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICurrencyConversionHelper _currencyConversionHelper;

        public ProductService(IProductRepository productRepository, ILocationRepository locationRepository, ICurrencyConversionHelper currencyConversionHelper)
        {
            _productRepository = productRepository;
            _locationRepository = locationRepository;
            _currencyConversionHelper = currencyConversionHelper;

        }

        public async Task<IEnumerable<ProductDTO>> GetLatestProducts(int pageStart, int pageSize, string orderBy)
        {
            var products = await _productRepository.GetLatestProducts(orderBy).GetPagedProducts(pageStart, pageSize);
            return products.Select(p => p.ToDTO());
        }

        public async Task<IEnumerable<ProductDTO>> GetLatestProductsPricesByLocation(int pageStart, int pageSize, string orderBy, string code)
        {
            var products = await _productRepository.GetLatestProducts(orderBy).GetPagedProducts(pageStart, pageSize);
            var location = await _locationRepository.GetByLocationCodeAsync(code);
            if (location == null)
            {
                throw new Exception("Invalid country code.");
            }
            return products.Select(p =>
            {
                var productDTO = p.ToDTO();
                productDTO.ConvertedPrice = _currencyConversionHelper.Convert(p.PriceInPounds, location.ExchangeRateToPounds);
                productDTO.ConvertedCurrency = Currency.EUR;
                return productDTO;
            });
        }

        

        
    }
}
