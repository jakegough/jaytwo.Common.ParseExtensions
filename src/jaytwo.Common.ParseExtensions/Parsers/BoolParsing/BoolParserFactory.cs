using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions.Parsers.BoolParsing
{
    internal class BoolParserFactory : IBoolParserFactory
    {
        private readonly IList<Tuple<Func<BoolStyles, bool>, IBoolParser>> _parsers;

        public BoolParserFactory()
        {
            _parsers = new List<Tuple<Func<BoolStyles, bool>, IBoolParser>>()
            {
                new Tuple<Func<BoolStyles, bool>, IBoolParser>(styles => (styles == BoolStyles.Default) || ((styles & BoolStyles.TrueFalse) > 0), new DefaultBoolParser()),
                new Tuple<Func<BoolStyles, bool>, IBoolParser>(styles => ((styles & BoolStyles.TF) > 0), new TFBoolParser()),
                new Tuple<Func<BoolStyles, bool>, IBoolParser>(styles => ((styles & BoolStyles.YesNo) > 0), new YesNoBoolParser()),
                new Tuple<Func<BoolStyles, bool>, IBoolParser>(styles => ((styles & BoolStyles.YN) > 0), new YNBoolParser()),
                new Tuple<Func<BoolStyles, bool>, IBoolParser>(styles => ((styles & BoolStyles.OneZero) > 0), new OneZeroBoolParser()),
            };
        }
        
        public IBoolParser GetParser(BoolStyles styles)
        {
            var selectedParsers = _parsers
                .Where(x => x.Item1.Invoke(styles))
                .Select(x => x.Item2)
                .ToList();

            if (!selectedParsers.Any())
            {
                throw new ArgumentException($"No parsers available for styles: {styles}");
            }
            else if (selectedParsers.Count == 1)
            {
                return selectedParsers.Single();
            }
            else
            {
                return new BoolMultiParser(selectedParsers);
            }
        }
    }
}
