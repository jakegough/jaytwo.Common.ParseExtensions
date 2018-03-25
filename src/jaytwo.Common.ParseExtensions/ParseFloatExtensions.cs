using System;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseFloatExtensions
    {
        public static float ParseFloat(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);
            return float.Parse(value, styles, provider);
        }

        public static float ParseFloat(this string value)
        {
            return value.ParseFloat(Defaults.DefaultNumberStyles);
        }

        public static float? ParseFloatOrNull(this string value, NumberStyles styles)
        {
            var provider = Defaults.GetFormatProvider(styles);

             return (float.TryParse(value, styles, provider, out float parsedValue))
                ? parsedValue
                : (float?)null;
        }

        public static float? ParseFloatOrNull(this string value)
        {
            return value.ParseFloatOrNull(Defaults.DefaultNumberStyles);
        }
    }
}
