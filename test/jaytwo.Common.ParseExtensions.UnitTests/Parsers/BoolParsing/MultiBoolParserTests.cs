using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class MultiBoolParserTests
    {
        [Theory]
        [InlineData("y", true)]
        [InlineData("yes", true)]
        [InlineData("n", false)]
        [InlineData("no", false)]
        void Parse_happy_path(string value, bool expected)
        {
            // arrange
            var parsers = new[]
            {
                (IBoolParser)new YesNoBoolParser(),
                (IBoolParser)new YNBoolParser(),
            };

            var parser = new BoolMultiParser(parsers);

            // act
            var result = parser.Parse(value);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("y", true, true)]
        [InlineData("yes", true, true)]
        [InlineData("n", true, false)]
        [InlineData("no", true, false)]
        [InlineData("z", false, false)]
        void TryParse_happy_path(string value, bool expectedSuccess, bool expectedResult)
        {
            // arrange
            var parsers = new[]
            {
                (IBoolParser)new YesNoBoolParser(),
                (IBoolParser)new YNBoolParser(),
            };

            var parser = new BoolMultiParser(parsers);

            // act
            var success = parser.TryParse(value, out bool result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}
