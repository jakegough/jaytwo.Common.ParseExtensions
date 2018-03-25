using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class YesNoBoolParser : BoolParserBase, IBoolParser
    {
        public override bool Parse(string value)
        {
            if (string.Equals(value, "Yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(value, "No", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            throw new FormatException($"Cannot value: {value}");
        }
    }
}
