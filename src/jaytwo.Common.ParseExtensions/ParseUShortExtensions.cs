using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseUShortExtensions
    {
        public static ushort? ParseUShortOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (ushort.TryParse(value, styles, provider, out ushort parsedValue))
                ? parsedValue
                : (ushort?)null;
        }

        public static ushort? ParseUShortOrNull(this string value)
        {
            return value.ParseUShortOrNull(Defaults.DefaultNumberStyles);
        }

        public static ushort ParseUShort(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return ushort.Parse(value, styles, provider);
        }

        public static ushort ParseUShort(this string value)
        {
            return value.ParseUShort(Defaults.DefaultNumberStyles);
        }
    }
}
