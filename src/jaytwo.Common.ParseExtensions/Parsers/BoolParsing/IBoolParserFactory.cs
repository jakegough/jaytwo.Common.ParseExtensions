using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal interface IBoolParserFactory
    {
        IBoolParser GetParser(BoolStyles styles);
    }
}
