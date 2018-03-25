using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class BoolParserFactoryTests
    {
        [Theory]
        [InlineData(BoolStyles.YesNo, typeof(YesNoBoolParser))]
        [InlineData(BoolStyles.YN, typeof(YNBoolParser))]
        [InlineData(BoolStyles.TrueFalse, typeof(DefaultBoolParser))]
        [InlineData(BoolStyles.TF, typeof(TFBoolParser))]
        [InlineData(BoolStyles.TF | BoolStyles.TrueFalse, typeof(BoolMultiParser))]
        void GetParser_returns_parser_for_style(BoolStyles styles, Type expectedParserType)
        {
            // arrange
            var factory = new BoolParserFactory();

            // act
            var parser = factory.GetParser(styles);

            // assert
            Assert.IsType(expectedParserType, parser);
        }

        [Fact]
        void GetParser_returns_correct_composite_parsers_for_multiple_styles()
        {
            // arrange
            var factory = new BoolParserFactory();

            // act
            var parser = factory.GetParser(BoolStyles.YesNo | BoolStyles.YN);

            // assert
            Assert.IsType<BoolMultiParser>(parser);
            Assert.True(parser.Parse("Y")); // validates that it includes the YN parser
            Assert.True(parser.Parse("Yes")); // validates that it includes the YesNo parser
            Assert.Throws<FormatException>(() => parser.Parse("true")); // validates that it doesn't include the TrueFalse parser
        }
    }
}
