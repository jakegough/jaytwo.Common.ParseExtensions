using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseBoolExtensions
    {
        private static Lazy<IBoolParserFactory> _factory = new Lazy<IBoolParserFactory>(() => new BoolParserFactory());

        public static bool ParseBool(this string value)
        {
            return value.ParseBool(BoolStyles.Default);
        }

        public static bool ParseBool(this string value, BoolStyles styles)
        {
            var parser = _factory.Value.GetParser(styles);
            return parser.Parse(value);
        }

        public static bool? ParseBoolOrNull(this string value)
        {
            return value.ParseBoolOrNull(BoolStyles.Default);
        }

        public static bool? ParseBoolOrNull(this string value, BoolStyles styles)
        {
            var parser = _factory.Value.GetParser(styles);
            if (parser.TryParse(value, out bool result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
