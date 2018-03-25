using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class OneZeroBoolParser : BoolParserBase, IBoolParser
    {
        public override bool Parse(string value)
        {
            if (string.Equals(value, "1", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(value, "0", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            throw new FormatException($"Cannot value: {value}");
        }
    }
}
