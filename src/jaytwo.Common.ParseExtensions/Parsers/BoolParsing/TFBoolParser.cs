using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class TFBoolParser : BoolParserBase, IBoolParser
    {
        public override bool Parse(string value)
        {
            if (string.Equals(value, "T", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(value, "F", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            throw new FormatException($"Cannot value: {value}");
        }
    }
}
