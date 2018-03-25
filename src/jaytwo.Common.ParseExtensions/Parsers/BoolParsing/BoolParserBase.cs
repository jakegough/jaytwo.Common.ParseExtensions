using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal abstract class BoolParserBase : IBoolParser
    {

        public abstract bool Parse(string value);

        public bool TryParse(string value, out bool result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch
            {
                result = false;
                return false;
            }
        }
    }
}
