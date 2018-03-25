using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static partial class ParseLongExtensions
    {
        public static long? ParseLongOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (long.TryParse(value, styles, provider, out long parsedValue))
                ? parsedValue
                : (long?)null;
        }

        public static long? ParseLongOrNull(this string value)
        {
            return value.ParseLongOrNull(Defaults.DefaultNumberStyles);
        }

        public static long ParseLong(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return long.Parse(value, styles, provider);
        }

        public static long ParseLong(this string value)
        {
            return value.ParseLong(Defaults.DefaultNumberStyles);
        }
    }
}
