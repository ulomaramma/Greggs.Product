using Greggs.Products.Application.Constants;
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
        private readonly IConfiguration _configuration;

        public ProductService(IProductRepository productRepository, ILocationRepository locationRepository, ICurrencyConversionHelper currencyConversionHelper, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _locationRepository = locationRepository;
            _currencyConversionHelper = currencyConversionHelper;
            _configuration = configuration;

        }

        public async Task<IEnumerable<ProductDTO>> List(int pageStart, int pageSize)
        {
            var products = await _productRepository.List(pageStart, pageSize);
            return products.Select(p => p.ToDTO());
        }

        public async Task<IEnumerable<ProductDTO>> ListWithConvertedPrices(int pageStart, int pageSize, string code)
        {
            var products = await _productRepository.List(pageStart, pageSize);
            var location = await _locationRepository.GetByLocationCodeAsync(code);
            if (location == null)
            {
                throw new Exception("Invalid country code.");
            }
            return ConvertProductPrice(products, location.ConversionRateToPounds); ;
            
        }

        public async Task<IEnumerable<ProductDTO>> ListWithPricesInEuros(int pageStart, int pageSize)
        {
            var products = await _productRepository.List(pageStart, pageSize);
            var conversionRateString = _configuration["ExchangeRates:GBPToEUR"];

            if (string.IsNullOrEmpty(conversionRateString))
            {
                throw new Exception("Conversion rate for GBP to EUR is not configured.");
            }

            if (!decimal.TryParse(conversionRateString, out var conversionRate))
            {
                throw new Exception("Invalid conversion rate value for GBP to EUR.");
            }
            return ConvertProductPrice(products, conversionRate);
        }

        private IEnumerable<ProductDTO> ConvertProductPrice(IEnumerable<Product> products, decimal conversionRate)
        {
            return products.Select(p =>
            {
                var productDTO = p.ToDTO();
                productDTO.ConvertedPrice = _currencyConversionHelper.ConvertGBP(p.PriceInPounds, conversionRate);
                productDTO.ConvertedCurrency = Currency.EUR;
                return productDTO;
            });
        }

        
    }
}
