using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static partial class ParseIntExtensions
    {
        public static int? ParseIntOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (int.TryParse(value, styles, provider, out int parsedValue))
                ? parsedValue
                : (int?)null;
        }

        public static int? ParseIntOrNull(this string value)
        {
            return value.ParseIntOrNull(Defaults.DefaultNumberStyles);
        }

        public static int ParseInt(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return int.Parse(value, styles, provider);
        }

        public static int ParseInt(this string value)
        {
            return value.ParseInt(Defaults.DefaultNumberStyles);
        }
    }
}
