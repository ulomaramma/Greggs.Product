using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Interfaces.Helpers
{
    public interface ICurrencyConversionHelper
    {
        decimal Convert(decimal amountInPounds, decimal conversionRate);
    }
}
