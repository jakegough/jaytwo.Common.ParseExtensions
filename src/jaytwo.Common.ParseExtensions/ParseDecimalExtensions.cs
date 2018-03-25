using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseDecimalExtensions
    {
        public static decimal ParseDeciamal(this string value)
        {
            return value.ParseDeciamal(Defaults.DefaultNumberStyles);
        }

        public static decimal ParseDeciamal(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return decimal.Parse(value, styles, provider);
        }

        public static decimal? ParseDeciamalOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (decimal.TryParse(value, styles, provider, out decimal parsedValue))
               ? parsedValue
               : (decimal?)null;
        }

        public static decimal? ParseDeciamalOrNull(this string value)
        {
            return value.ParseDeciamalOrNull(Defaults.DefaultNumberStyles);
        }
    }
}
