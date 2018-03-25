using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseDoubleExtensions
    {
        public static double? ParseDoubleOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (double.TryParse(value, styles, provider, out double parsedValue))
                ? parsedValue
                : (double?)null;
        }

        public static double? ParseDoubleOrNull(this string value)
        {
            return value.ParseDoubleOrNull(Defaults.DefaultNumberStyles);
        }

        public static double ParseDouble(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return double.Parse(value, styles, provider);
        }

        public static double ParseDouble(this string value)
        {
            return value.ParseDouble(Defaults.DefaultNumberStyles);
        }
    }
}
