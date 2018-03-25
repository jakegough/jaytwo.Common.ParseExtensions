using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseDateTimeExtensions
    {
        public static DateTime ParseDateTime(this string value)
        {
            return DateTime.Parse(value);
        }

        public static DateTime ParseDateTime(this string value, DateTimeStyles styles)
        {
            return value.ParseDateTime(Defaults.DefaultCultureInfo, styles);
        }

        public static DateTime ParseDateTime(this string value, IFormatProvider provider)
        {
            return DateTime.Parse(value, provider, DateTimeStyles.None);
        }

        public static DateTime ParseDateTime(this string value, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.Parse(value, provider, styles);
        }

        public static DateTime? ParseDateTimeOrNull(this string value)
        {
            return (DateTime.TryParse(value, out DateTime parsedValue))
                ? parsedValue
                : (DateTime?)null;
        }

        public static DateTime? ParseDateTimeOrNull(this string value, DateTimeStyles styles)
        {
            return value.ParseDateTimeOrNull(Defaults.DefaultCultureInfo, styles);
        }

        public static DateTime? ParseDateTimeOrNull(this string value, IFormatProvider provider)
        {
            return value.ParseDateTimeOrNull(provider, DateTimeStyles.None);
        }

        public static DateTime? ParseDateTimeOrNull(this string value, IFormatProvider provider, DateTimeStyles styles)
        {
            return (DateTime.TryParse(value, provider, styles, out DateTime parsedValue))
                ? parsedValue
                : (DateTime?)null;
        }
    }
}
