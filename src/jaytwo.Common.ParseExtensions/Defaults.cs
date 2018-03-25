using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions
{
    internal class Defaults
    {
        internal static CultureInfo DefaultCultureInfo = new CultureInfo("en-US");
        internal static NumberStyles DefaultNumberStyles = NumberStyles.Any;

        internal static IFormatProvider GetFormatProvider(NumberStyles styles)
        {
            var result = ((styles & NumberStyles.AllowCurrencySymbol) > 0)
                ? DefaultCultureInfo
                : CultureInfo.InvariantCulture;

            return result;
        }
    }
}
