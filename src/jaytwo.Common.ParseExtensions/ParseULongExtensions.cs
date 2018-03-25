using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static partial class ParseULongExtensions
    {
        public static ulong? ParseULongOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (ulong.TryParse(value, styles, provider, out ulong parsedValue))
                ? parsedValue
                : (ulong?)null;
        }

        public static ulong? ParseULongOrNull(this string value)
        {
            return value.ParseULongOrNull(Defaults.DefaultNumberStyles);
        }

        public static ulong ParseULong(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return ulong.Parse(value, styles, provider);
        }

        public static ulong ParseULong(this string value)
        {
            return value.ParseULong(Defaults.DefaultNumberStyles);
        }
    }
}
