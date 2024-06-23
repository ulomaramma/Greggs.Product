using Greggs.Products.Application.Interfaces.Helpers;
using Greggs.Products.Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Helpers
{
    public class CurrencyConversionHelper : ICurrencyConversionHelper
    {
        public decimal ConvertGBP(decimal amountInPounds, decimal conversionRate)
        {          
            var convertedAmount = amountInPounds * conversionRate;
            return Math.Round(convertedAmount, 2);
        }
      
    }
}
