using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseShortExtensions
    {
        public static short? ParseShortOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (short.TryParse(value, styles, provider, out short parsedValue))
                ? parsedValue
                : (short?)null;
        }

        public static short? ParseShortOrNull(this string value)
        {
            return value.ParseShortOrNull(Defaults.DefaultNumberStyles);
        }

        public static short ParseShort(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return short.Parse(value, styles, provider);
        }

        public static short ParseShort(this string value)
        {
            return value.ParseShort(Defaults.DefaultNumberStyles);
        }
    }
}
