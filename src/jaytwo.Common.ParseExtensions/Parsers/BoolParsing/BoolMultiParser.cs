using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class BoolMultiParser : IBoolParser
    {
        private readonly IList<IBoolParser> _parsers;

        public BoolMultiParser(IList<IBoolParser> parsers)
        {
            _parsers = parsers;
        }

        public bool Parse(string value)
        {
            if (TryParse(value, out bool result))
            {
                return result;
            }

            throw new FormatException($"Could not parse value: {value}");
        }

        public bool TryParse(string value, out bool result)
        {
            foreach (var parser in _parsers)
            {
                if (parser.TryParse(value, out result))
                {
                    return true;
                }
            }

            result = false;
            return false;
        }
    }
}
