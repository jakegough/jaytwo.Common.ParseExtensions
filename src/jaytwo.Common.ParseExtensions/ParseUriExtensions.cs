using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseUriExtensions
    {
        public static Uri ParseUri(this string value, UriKind uriKind)
        {
            return new Uri(value, uriKind);
        }

        public static Uri ParseUri(this string value)
        {
            return new Uri(value);
        }

        public static Uri ParseUriOrNull(this string value, UriKind uriKind)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    return new Uri(value, uriKind);
                }
                catch
                {
                }
            }

            return null;
        }

        public static Uri ParseUriOrNull(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    return new Uri(value);
                }
                catch
                {
                }
            }

            return null;
        }
    }
}
