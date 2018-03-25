using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal interface IBoolParser
    {
        bool Parse(string value);
        bool TryParse(string value, out bool result);
    }
}
