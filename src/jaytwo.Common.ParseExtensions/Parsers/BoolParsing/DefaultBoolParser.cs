using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class DefaultBoolParser : IBoolParser
    {
        public bool Parse(string value)
        {
            return bool.Parse(value);
        }

        public bool TryParse(string value, out bool result)
        {
            return bool.TryParse(value, out result);
        }
    }
}
