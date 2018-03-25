using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseGuidExtensions
    {
        public static Guid ParseGuid(this string value)
        {
            return new Guid(value);
        }

        public static Guid? ParseGuidOrNull(this string value)
        {
            try
            {
                return new Guid(value);
            }
            catch
            {
                return null;
            }
        }
    }
}
