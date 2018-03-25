using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static partial class ParseUIntExtensions
    {
        public static uint? ParseUIntOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

            return (uint.TryParse(value, styles, provider, out uint parsedValue))
                ? parsedValue
                : (uint?)null;
        }

        public static uint? ParseUIntOrNull(this string value)
        {
            return value.ParseUIntOrNull(Defaults.DefaultNumberStyles);
        }

        public static uint ParseUInt(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return uint.Parse(value, styles, provider);
        }

        public static uint ParseUInt(this string value)
        {
            return value.ParseUInt(Defaults.DefaultNumberStyles);
        }
    }
}
